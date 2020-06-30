using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudProduto.Models
{
	public class Produto : EntidadeDominio
	{
		[Display(Name = "Nome")]
		public string nome { get; set; }
		[Display(Name = "Valor de Compra")]
		public double valorCompra { get; set; }
		[Display(Name = "Data da compra")]
		public DateTime dataCompra { get; set; }
		[Display(Name = "Quantidade")]
		public int quantidade { get; set; }
		[Display(Name = "Comprador")]
		public string comprador { get; set; }
		[Display(Name = "Status")]
		public bool status { get; set; }
		public FichaTecnica fichaTecnica { get; set; }
		public LinhaProduto linhaProduto { get; set; }
		[Display(Name ="Linha Produto")]
		public int linhaprodutoid { get; set; }
		public ICollection<Acessorio> acessorios { get; set; } = new List<Acessorio>();

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

		public void AddAcessorio(Acessorio acessorio)
		{
			acessorios.Add(acessorio);
		}

		public void RemoveAcessorios(Acessorio acessorio)
		{
			acessorios.Remove(acessorio);
		}
	}
}
