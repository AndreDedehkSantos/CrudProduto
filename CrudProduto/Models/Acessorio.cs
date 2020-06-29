using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
	public class Acessorio : EntidadeDominio
	{
		public string nome { get; set; }
		public string descricao { get; set; }
		public int quantidade { get; set; }

		public Acessorio()
		{

		}

		public Acessorio(string nome, string descricao, int quantidade)
		{
			this.nome = nome;
			this.descricao = descricao;
			this.quantidade = quantidade;
		}
	}
}
