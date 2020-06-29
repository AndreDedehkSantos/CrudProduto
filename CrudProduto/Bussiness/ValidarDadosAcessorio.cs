using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosAcessorio : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio a)
		{
			ICollection<string> erro = new List<string>();
			Acessorio acessorio = (Acessorio)a;
			if(acessorio.nome == null)
			{
				erro.Add("Nome do Acessório Inválido");
			}
			if(acessorio.descricao == null)
			{
				erro.Add("Descrição Inválida");
			}
			if(acessorio.quantidade <= 0)
			{
				erro.Add("Quantidade Inválida");
			}
			return erro;
		}
	}
}
