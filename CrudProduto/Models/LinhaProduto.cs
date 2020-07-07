using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudProduto.Models
{
	public class LinhaProduto : EntidadeDominio
	{
		[Display(Name = "Nome")]
		public string nome { get; set; }

        public LinhaProduto()
		{

		}
		public LinhaProduto(string nome)
		{
			this.nome = nome;
		}
	}
}
