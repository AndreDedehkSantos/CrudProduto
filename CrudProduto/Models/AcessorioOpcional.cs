using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
    public class AcessorioOpcional:Acessorio
    {
        [Display(Name = "Linha de Produtos")]
        public int produtoId { get; set; }
    }
}
