using CrudProduto.Models;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
	public class ProdutoDal : IDal
	{
		private readonly CrudProdutoContext _context;

		public ProdutoDal(CrudProdutoContext context)
		{
			_context = context;
		}

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            Produto produto = (Produto)entidadeDominio;
            _context.Update(produto);
            _context.SaveChangesAsync();
        }

        public void Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EntidadeDominio> Listar()
        {
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<Produto> lista = _context.Produto.ToList();
            foreach(Produto item in lista)
            {
                listaEnt.Add((EntidadeDominio)item);
            }
            return listaEnt;
        }
        
        public Produto Consultar(int id)
        {
             return _context.Produto.Include(Obj => Obj.fichaTecnica).FirstOrDefault(Obj => Obj.id == id); 
        }

        public void Salvar(EntidadeDominio entidadeDominio)
		{
            Produto produto = (Produto)entidadeDominio;
			_context.Produto.Add(produto);
			_context.SaveChanges();
		}
    }
}
