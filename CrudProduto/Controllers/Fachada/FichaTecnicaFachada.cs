using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class FichaTecnicaFachada : IFachada
    {
        private readonly CrudProdutoContext _context;

        public FichaTecnicaFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public void alterar(EntidadeDominio entidadeDominio)
        {
            
        }
        public FichaTecnica find(FichaTecnica ficha)
        {
            FichaTecnicaDal fDal = new FichaTecnicaDal(_context);
            return fDal.find(ficha);

        }

        public ICollection<EntidadeDominio> Listar()
        {
            return null;
        }

        public void salvar(EntidadeDominio entidadeDominio)
        {
            FichaTecnicaDal fDal = new FichaTecnicaDal(_context);
            fDal.Salvar(entidadeDominio);
        }

        public ICollection<string> ValidarFicha(FichaTecnica fichaTecnica)
        {
            ValidarDadosFichaTecnica vFicha = new ValidarDadosFichaTecnica();
            ICollection<string> validacoes = vFicha.processar(fichaTecnica);
            return validacoes;
        }
    }
}
