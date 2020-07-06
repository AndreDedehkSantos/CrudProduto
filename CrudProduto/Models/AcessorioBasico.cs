using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
    public class AcessorioBasico:Acessorio
    {
        [Display(Name = "Linha de Produtos")]
        public int linhaprodutoId { get; set; }
    }
}
