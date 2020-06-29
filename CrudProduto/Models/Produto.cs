using System;
using System.Collections.Generic;

namespace CrudProduto.Models
{
	public class Produto : EntidadeDominio
	{
		public string nome { get; set; }
		public double valorCompra { get; set; }
		public DateTime dataCompra { get; set; }
		public int quantidade { get; set; }
		public string comprador { get; set; }
		public bool status { get; set; }
		public FichaTecnica fichaTecnica { get; set; }
		public ICollection<AcessorioOpcional> acessorios { get; set; } = new List<AcessorioOpcional>();

		public Produto()
		{

		}

		public Produto(string nome, double valorCompra, DateTime dataCompra, int quantidade, string comprador, bool status, FichaTecnica fichaTecnica)
		{
			this.nome = nome;
			this.valorCompra = valorCompra;
			this.dataCompra = dataCompra;
			this.quantidade = quantidade;
			this.comprador = comprador;
			this.status = status;
			this.fichaTecnica = fichaTecnica;
		}
	}
}
