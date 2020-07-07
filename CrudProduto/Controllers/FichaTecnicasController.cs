﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Dal;
using CrudProduto.Models.ViewModels;

namespace CrudProduto.Controllers
{
    public class FichaTecnicasController : Controller
    {
        private readonly CrudProdutoContext _context;

        public FichaTecnicasController(CrudProdutoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Edit(Produto p)
        {
            FichaTecnicaFachada fichaFachada = new FichaTecnicaFachada(_context);
            FichaTecnica fichaTecnica = fichaFachada.find(p.id);
            if (fichaTecnica == null)
            {
                return NotFound();
            }
            FichaViewModel fichaVM = new FichaViewModel{ ficha = fichaTecnica, manter = fichaTecnica };
            return View(fichaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FichaViewModel fichaTecnicaVM)
        {
            if (id != fichaTecnicaVM.ficha.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try 
                {
                    FichaTecnicaFachada fichaFachada = new FichaTecnicaFachada(_context);
                    ICollection<string> validacoes = new List<string>();
                    validacoes = fichaFachada.ValidarFicha(fichaTecnicaVM.ficha);
                    if(validacoes.Count() == 0)
                    {
                        UsuarioFachada uFachada = new UsuarioFachada(_context);
                        Usuario usuario = uFachada.existe(fichaTecnicaVM.usuario);
                        if (usuario != null)
                        {
                            fichaFachada.alterar(fichaTecnicaVM.ficha);
                            LogFachada lFachada = new LogFachada(_context);
                            string descricao = "Alteração da Ficha Técnica Id: " + fichaTecnicaVM.ficha.id;
                            Log log = lFachada.gerarLog(descricao, usuario.id, true, false, fichaTecnicaVM.manter.ToString());
                            lFachada.salvar(log);
                        }
                        else
                        {
                            validacoes.Add("Usuário não encontrado");
                            return View("Error", validacoes);
                        }
                        
                    }
                    else
                    {
                        return View("Error", validacoes);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaTecnicaExists(fichaTecnicaVM.ficha.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Produtoes");
            }
            return View(fichaTecnicaVM.ficha);
        }

        private bool FichaTecnicaExists(int id)
        {
            return _context.FichaTecnica.Any(e => e.id == id);
        }
    }
}
