using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class CliptografiaSenhaUsuario 
	{
		public string processar(string senha)
		{
			senha = CliptografadaSenha(senha);
			return senha;
			
		}

		private string CliptografadaSenha(string senha)
		{
			StringBuilder senhaClip = new StringBuilder();
			for(int i = senha.Length; i >= 0; i--)
			{
				senhaClip.Append(senha[i]);
			}
			return senhaClip.ToString();
		}
	}
}
