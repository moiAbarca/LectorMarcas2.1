using System;
using System.Runtime.CompilerServices;

namespace ZKSauroAPI
{
	public class MarcajeOperativo
	{
		public int NumeroDispositivo
		{
			get;
			set;
		}

		public int Operacion
		{
			get;
			set;
		}

		public int Parametro1
		{
			get;
			set;
		}

		public int Parametro2
		{
			get;
			set;
		}

		public int Parametro3
		{
			get;
			set;
		}

		public int Parametro4
		{
			get;
			set;
		}

		public MarcajeOperativo()
		{
		}

		public override string ToString()
		{
			object[] str = new object[] { this.NumeroDispositivo.ToString(), "|", this.Operacion.ToString(), "|", this.Parametro1, "|", this.Parametro2.ToString(), "|", this.Parametro3.ToString(), "|", this.Parametro4.ToString() };
			return string.Concat(str);
		}
	}
}