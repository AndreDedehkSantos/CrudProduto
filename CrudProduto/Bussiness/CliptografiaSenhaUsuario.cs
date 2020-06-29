using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class CliptografiaSenhaUsuario : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio u)
		{
			Usuario usuario = (Usuario)u;
			ICollection<string> senha = new List<string>();
			senha.Add(CliptogradaSenha(usuario.senha1).ToString());
			senha.Add(CliptogradaSenha(usuario.senha2).ToString());
			return senha;
			
		}

		private StringBuilder CliptogradaSenha(string senha)
		{
			char[] senha2 = new char[senha.Length];
			StringBuilder senhaClip = new StringBuilder();
			for(int i = senha2.Length; i >= 0; i--)
			{
				senhaClip.Append(senha2[i].ToString());
			}
			return senhaClip;
		}
	}
}
