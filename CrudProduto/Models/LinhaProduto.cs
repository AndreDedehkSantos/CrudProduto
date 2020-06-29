using System.Collections.Generic;

namespace CrudProduto.Models
{
	public class LinhaProduto : EntidadeDominio
	{ 
		public string nome { get; set; }
		public ICollection<Acessorio> acessorios { get; set; } = new List<Acessorio>();

		public LinhaProduto()
		{

		}

		public LinhaProduto(string nome)
		{
			this.nome = nome;
		}

		public void AddAcessorio(Acessorio acessorio)
		{
			acessorios.Add(acessorio);
		}

		public void RemoveAcessorio(Acessorio acessorio)
		{
			acessorios.Remove(acessorio);
		}
	}
}
