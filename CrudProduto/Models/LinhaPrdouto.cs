using System.Collections.Generic;

namespace CrudProduto.Models
{
	public class LinhaPrdouto : EntidadeDominio
	{ 
		public string nome { get; set; }
		public ICollection<AcessorioBasico> acessorios { get; set; } = new List<AcessorioBasico>();

		public LinhaPrdouto()
		{

		}

		public LinhaPrdouto(string nome)
		{
			this.nome = nome;
		}
	}
}
