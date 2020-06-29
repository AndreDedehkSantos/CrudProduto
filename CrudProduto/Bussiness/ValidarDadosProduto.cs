using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosProduto : IStrategy
	{
		public string processar(EntidadeDominio p)
		{
			Produto produto = (Produto) p;
			if(produto.nome == null)
			{
				return "Nome inválido";
			}
			else if(produto.quantidade == 0)
			{
				return "Quantidade inválida";
			}
			else if (produto.dataCompra == null)
			{
				return "Data da compra inválida";
			}
			else if(produto.comprador == null)
			{
				return "Comprador inválido";
			}
			else if(produto.valorCompra == 0)
			{
				return "Valor da compra inválido";
			}
			else
			{
				return null;
			}
		}
	}
}
