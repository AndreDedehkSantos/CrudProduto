using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
	public class EntidadeDominio
	{
		public int id { get; set; }
		public string descLog { get; set; }

		public EntidadeDominio()
		{

		}

		public EntidadeDominio(int id, string descLog)
		{
			this.id = id;
			this.descLog = descLog;
		}
	}
}
