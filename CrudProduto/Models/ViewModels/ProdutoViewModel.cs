using CrudProduto.Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
	public class ProdutoViewModel
	{
		public Produto produto { get; set; }

		public ICollection<LinhaProduto> lp { get; set; }

        public bool status { get; set; }
    }
}
