using System.Collections.Generic;

namespace CrudProduto.Models
{
	public class LinhaProduto : EntidadeDominio
	{ 
		public string nome { get; set; }
		public ICollection<AcessorioBasico> acessorios { get; set; } = new List<AcessorioBasico>();

		public LinhaProduto()
		{

		}

		public LinhaProduto(string nome)
		{
			this.nome = nome;
		}

		public void AddAcessorio(AcessorioBasico acessorio)
		{
			acessorios.Add(acessorio);
		}

		public void RemoveAcessorio(AcessorioBasico acessorio)
		{
			acessorios.Remove(acessorio);
		}
	}
}
