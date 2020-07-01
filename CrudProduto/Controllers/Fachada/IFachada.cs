using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	interface IFachada
	{
		void salvar(EntidadeDominio EntidadeDominio);
		void alterar(EntidadeDominio EntidadeDominio);
		void listar(EntidadeDominio EntidadeDominio);
		void inativar(EntidadeDominio EntidadeDominio);
	}
}
