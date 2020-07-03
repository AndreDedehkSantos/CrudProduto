using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
    public class AcessorioViewModel
    {
        public ICollection<Acessorio> acessorios { get; set; }
        public  ICollection<bool> ativo{ get; set; }
        public bool basico { get; set; }
    }
}
