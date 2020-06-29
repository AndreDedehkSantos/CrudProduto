using System;

namespace CrudProduto.Models
{
	public class Log : EntidadeDominio
	{
		public DateTime dataHora { get; set; }
		public int idUsuario { get; set; }
		public string descricao { get; set; }

		public Log()
		{

		}

		public Log(DateTime dataHora, int idUsuario, string descricao)
		{
			this.dataHora = dataHora;
			this.idUsuario = idUsuario;
			this.descricao = descricao;
		}
	}
}
