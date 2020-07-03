using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class AcessorioDal : IDal
    {
        private readonly CrudProdutoContext _context;

        public AcessorioDal(CrudProdutoContext context)
        {
            _context = context;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
           
        }

        public void Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EntidadeDominio> Listar()
        {
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            var lista = _context.Acessorio.ToList();
            foreach (Acessorio item in lista)
            {
                listaEnt.Add((EntidadeDominio)item);
            }
            return listaEnt;
        }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            Acessorio acessorio = (Acessorio)entidadeDominio;
            _context.Add<Acessorio>(acessorio);
            _context.SaveChanges();
        }
    }
}
