using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrudProduto.Controllers
{
    public class FichaTecnicasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
