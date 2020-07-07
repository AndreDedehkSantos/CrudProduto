using CrudProduto.Bussiness;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class LogFachada
    {
        private readonly CrudProdutoContext _context;

        public LogFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public Log gerarLog(string descricao, int usuarioId, bool alt, bool ins, EntidadeDominio e)
        {
            GerarLog gLog = new GerarLog();
            return gLog.Processar(descricao, usuarioId, alt, ins, e);
        }
    }
}
