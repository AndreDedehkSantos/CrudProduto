using CrudProduto.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosUsuario : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio u)
		{
			Usuario usuario = (Usuario)u;
			ICollection<string> erro = new List<string>();
			if(usuario.nome == null)
			{
				erro.Add("Nome de usuário Inválido");
			}
		
			ICollection<string> erroSenha = ValidarSenha(usuario.senha1, usuario.senha2);
			if (erroSenha.Count != 0)
			{
				foreach(string item in erroSenha)
				{
					erro.Add(item);
				}
			}
			return erro;
		}

		private ICollection<string> ValidarSenha(string senha1, string senha2)
		{
			ICollection<string> erroSenha = new List<string>();
			var regexItem = new Regex("^[a-zA-Z ]*$");
			if (senha1 == null || senha1.Length < 8 || !regexItem.IsMatch(senha1))
			{
				erroSenha.Add("Senha Inválida");
			}
			if (!senha1.Equals(senha2))
			{
				erroSenha.Add("Senhas diferentes");
			}
			return erroSenha;
		}

	}
}
