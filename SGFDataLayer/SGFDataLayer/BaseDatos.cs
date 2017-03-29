using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections;

namespace SGFDataLayer
{
    public class BaseDatos
    {

        string passPhrase = "Pa55pr@se";           // can be any string
        string saltValue = "s@1tV@lue";            // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 2;                // can be any number
        string initVector = "@1B2c3D4e5F6g7H8";    // must be 16 bytes
        int keySize = 256;                         // can be 192 or 128

        private DbConnection conexion = null;
        private DbCommand comando = null;
        private DbTransaction transaccion = null;
        private string cadenaConexion;

        private static DbProviderFactory factory = null;

        /// <summary>
        /// Crea una instancia del acceso a la base de datos.
        /// </summary>
        public BaseDatos()
        {
            Configurar();
        }

        /// <summary>
        /// Configura el acceso a la base de datos para su utilización.
        /// </summary>
        /// <exception cref="BaseDatosException">Si existe un error al cargar la configuración.</exception>
        private void Configurar()
        {
            try
            {
                string server = Encriptacion.Decrypt(ConfigurationManager.AppSettings.Get("SERVER"), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                string user = Encriptacion.Decrypt(ConfigurationManager.AppSettings.Get("USERNAME"), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                string password = Encriptacion.Decrypt(ConfigurationManager.AppSettings.Get("PASSWORD"), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                // string port = Encriptacion.Decrypt(ConfigurationManager.AppSettings.Get("PORT"), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                string database = Encriptacion.Decrypt(ConfigurationManager.AppSettings.Get("DATABASE"), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);

                string proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADONET");
                // this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
                this.cadenaConexion = String.Format("Server={0};Database={1};Uid={2};Pwd={3};", server, database, user, password);
                BaseDatos.factory = DbProviderFactories.GetFactory(proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new BaseDatosException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }

        /// <summary>
        /// Permite desconectarse de la base de datos.
        /// </summary>
        public void Desconectar()
        {
            if (this.conexion.State.Equals(ConnectionState.Open))
            {
                this.conexion.Close();
                // this.conexion = null;
            }
        }

        /// <summary>
        /// Se concecta con la base de datos.
        /// </summary>
        /// <exception cref="BaseDatosException">Si existe un error al conectarse.</exception>
        public void Conectar()
        {
            if (this.conexion != null && !this.conexion.State.Equals(ConnectionState.Closed))
            {
                throw new BaseDatosException("La conexión ya se encuentra abierta.");
            }
            try
            {
                if (this.conexion == null)
                {
                    this.conexion = factory.CreateConnection();
                    this.conexion.ConnectionString = cadenaConexion;
                }
                this.conexion.Open();

            }
            catch (DataException ex)
            {
                throw new BaseDatosException("Error al conectarse a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("Error al conectarse a la base de datos.", ex);
            }

            //finally
            //{
            //    if (this.conexion != null && !conexion.State.Equals(ConnectionState.Closed)) conexion.Close(); 
            //}

        }

        /// <summary>
        /// Crea un comando en base a una sentencia SQL.
        /// Ejemplo:
        /// <code>SELECT * FROM Tabla WHERE campo1=@campo1, campo2=@campo2</code>
        /// Guarda el comando para el seteo de parámetros y la posterior ejecución.
        /// </summary>
        /// <param name="sentenciaSQL">La sentencia SQL con el formato: SENTENCIA [param = @param,]</param>
        public void CrearComando(string sentenciaSQL)
        {
            this.comando = factory.CreateCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL;
            if (this.transaccion != null)
            {
                this.comando.Transaction = this.transaccion;
            }
        }

        /// <summary>
        /// Setea un parámetro como nulo del comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro cuyo valor será nulo.</param>
        public void AsignarParametroNulo(string nombre)
        {
            AsignarParametro(nombre, "", "NULL");
        }

        /// <summary>
        /// Asigna un parámetro de tipo cadena al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroCadena(string nombre, string valor)
        {
            AsignarParametro(nombre, "'", valor);
        }

        /// <summary>
        /// Asigna un parámetro de tipo entero al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroEntero(string nombre, int valor)
        {
            AsignarParametro(nombre, "", valor.ToString());
        }

        /// <summary>
        /// Asigna un parámetro de tipo double al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroDouble(string nombre, double valor)
        {
            AsignarParametro(nombre, "", valor.ToString());
        }

        /// <summary>
        /// Asigna un parámetro al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="separador">El separador que será agregado al valor del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        private void AsignarParametro(string nombre, string separador, string valor)
        {
            int indice = this.comando.CommandText.IndexOf(nombre);
            string prefijo = this.comando.CommandText.Substring(0, indice);
            string sufijo = this.comando.CommandText.Substring(indice + nombre.Length);
            this.comando.CommandText = prefijo + separador + valor + separador + sufijo;
        }

        /// <summary>
        /// Asigna un parámetro de tipo fecha al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroFecha(string nombre, DateTime valor)
        {
            AsignarParametro(nombre, "'", valor.ToString());
        }

        /// <summary>
        /// Ejecuta el comando creado y retorna el resultado de la consulta.
        /// </summary>
        /// <returns>El resultado de la consulta.</returns>
        /// <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
        public DbDataReader EjecutarConsulta()
        {
            return this.comando.ExecuteReader();
        }

        /// <summary>
        /// Ejecuta el comando creado y retorna un escalar.
        /// </summary>
        /// <returns>El escalar que es el resultado del comando.</returns>
        /// <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
        public int EjecutarEscalar()
        {
            int escalar = 0;
            try
            {
                escalar = int.Parse(this.comando.ExecuteScalar().ToString());
            }
            catch (InvalidCastException ex)
            {
                throw new BaseDatosException("Error al ejecutar un escalar.", ex);
            }
            finally
            {

            }
            return escalar;
        }

        /// <summary>
        /// Ejecuta el comando creado.
        /// </summary>
        public void EjecutarComando()
        {
            this.comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Comienza una transacción en base a la conexion abierta.
        /// Todo lo que se ejecute luego de esta ionvocación estará 
        /// dentro de una tranasacción.
        /// </summary>
        public void ComenzarTransaccion()
        {
            if (this.transaccion == null)
            {
                this.transaccion = this.conexion.BeginTransaction();
            }
        }

        /// <summary>
        /// Cancela la ejecución de una transacción.
        /// Todo lo ejecutado entre ésta invocación y su 
        /// correspondiente <c>ComenzarTransaccion</c> será perdido.
        /// </summary>
        public void CancelarTransaccion()
        {
            if (this.transaccion != null)
            {
                this.transaccion.Rollback();
            }
        }

        /// <summary>
        /// Confirma todo los comandos ejecutados entre el <c>ComanzarTransaccion</c>
        /// y ésta invocación.
        /// </summary>
        public void ConfirmarTransaccion()
        {
            if (this.transaccion != null)
            {
                this.transaccion.Commit();
            }
        }

        public string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int keySize = dwKeySize / 8;
            byte[] bytes = Encoding.UTF32.GetBytes(inputString);

            // RSACryptoServiceProvider here;

            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[
                        (dataLength - maxLength * i > maxLength) ? maxLength :
                                                      dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0,
                                  tempBytes.Length);
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes,
                                                                          true);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }
        public string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }
            return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
        }


    }
}
