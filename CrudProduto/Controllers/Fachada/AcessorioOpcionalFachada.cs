using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class AcessorioOpcionalFachada : IFachada
    {
        private readonly CrudProdutoContext _context;

        public AcessorioOpcionalFachada(CrudProdutoContext context)
        {
            _context = context;
        }
        public void alterar(EntidadeDominio entidadeDominio)
        {
            
        }

        public void inativar(int id)
        {
           
        }

        public ICollection<EntidadeDominio> Listar()
        {
            return null;
        }

        public void salvar(EntidadeDominio entidadeDominio)
        {
            AcessorioOpcionalDal aDal = new AcessorioOpcionalDal(_context);
            aDal.Salvar(entidadeDominio);
        }

        public ICollection<string> ValidarAcessorioOpcional(Acessorio acessorio)
        {
            ValidarDadosAcessorioOpcional vAcessorio = new ValidarDadosAcessorioOpcional();
            ICollection<string> validacoes = vAcessorio.processar(acessorio);
            return validacoes;
        }
    }
}
