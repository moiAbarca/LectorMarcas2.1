using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ZKSauroAPI
{
	public class UsuarioInformacion
	{
		public bool Activo
		{
			get;
			set;
		}

		public string Contrasenia
		{
			get;
			set;
		}

		public List<UsuarioHuella> Huellas
		{
			get;
			set;
		}

		public string Nombre
		{
			get;
			set;
		}

		public int NumeroCredencial
		{
			get;
			set;
		}

		public ZKSauroAPI.Permiso Permiso
		{
			get;
			set;
		}

		public UsuarioInformacion()
		{
		}

		public override string ToString()
		{
			return string.Concat(this.NumeroCredencial.ToString(), (this.Nombre == string.Empty ? string.Empty : string.Concat(" - ", this.Nombre)));
		}
	}
}