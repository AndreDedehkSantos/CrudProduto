using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
    public class LinhaProdutoViewModel
    {
        public LinhaProduto linhaProduto { get; set; }
        public ICollection<Acessorio> acessorios { get; set; } 
        public Acessorio acessorio { get; set; } = new Acessorio("teste", "teste", 1);
        public bool ativo { get; set; }
    }
}
