using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;

namespace CrudProduto.Models
{
    public class CrudProdutoContext : DbContext
    {
        public CrudProdutoContext (DbContextOptions<CrudProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<CrudProduto.Models.AcessorioBasico> AcessorioBasico { get; set; }

        public DbSet<CrudProduto.Models.AcessorioOpcional> AcessorioOpcional { get; set; }
    }
}
