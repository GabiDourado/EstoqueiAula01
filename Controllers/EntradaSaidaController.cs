using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Analista_Aula01.Models;

namespace Analista_Aula01.Controllers
{
    public class EntradaSaidaController : Controller
    {
        private readonly Contexto _context;

        public EntradaSaidaController(Contexto context)
        {
            _context = context;
        }

        // GET: EntradaSaida
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EntradaSaida.Include(e => e.Produto).Include(e => e.TipoMovimentacao);
            return View(await contexto.ToListAsync());
        }

        // GET: EntradaSaida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaSaida == null)
            {
                return NotFound();
            }

            var entradaSaida = await _context.EntradaSaida
                .Include(e => e.Produto)
                .Include(e => e.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.EntradaSaidaId == id);
            if (entradaSaida == null)
            {
                return NotFound();
            }

            return View(entradaSaida);
        }

        // GET: EntradaSaida/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome");
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "TipoMovimentacaoId", "NomeTipoMovimentacao");
            return View();
        }

        // POST: EntradaSaida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntradaSaidaId,ProdutoId,QntdMovimentacao,TipoMovimentacaoId,DataMovimentacao")] EntradaSaida entradaSaida)
        {
            if (ModelState.IsValid)
            {
                entradaSaida.DataMovimentacao = DateTime.Now;
                var produto = await _context.Produto.FindAsync(entradaSaida.ProdutoId);
                if(entradaSaida.TipoMovimentacaoId == 1)
                     produto.QntdEstoque = produto.QntdEstoque + entradaSaida.QntdMovimentacao;
                else
                    produto.QntdEstoque = produto.QntdEstoque - entradaSaida.QntdMovimentacao;

                _context.Update(produto);
                _context.Add(entradaSaida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", entradaSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "TipoMovimentacaoId", "NomeTipoMovimentacao", entradaSaida.TipoMovimentacaoId);
            return View(entradaSaida);
        }

        // GET: EntradaSaida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaSaida == null)
            {
                return NotFound();
            }

            var entradaSaida = await _context.EntradaSaida.FindAsync(id);
            if (entradaSaida == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", entradaSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "TipoMovimentacaoId", "NomeTipoMovimentacao", entradaSaida.TipoMovimentacaoId);
            return View(entradaSaida);
        }

        // POST: EntradaSaida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntradaSaidaId,ProdutoId,QntdMovimentacao,TipoMovimentacaoId,DataMovimentacao")] EntradaSaida entradaSaida)
        {
            if (id != entradaSaida.EntradaSaidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaSaida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaSaidaExists(entradaSaida.EntradaSaidaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", entradaSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "TipoMovimentacaoId", "NomeTipoMovimentacao", entradaSaida.TipoMovimentacaoId);
            return View(entradaSaida);
        }

        // GET: EntradaSaida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaSaida == null)
            {
                return NotFound();
            }

            var entradaSaida = await _context.EntradaSaida
                .Include(e => e.Produto)
                .Include(e => e.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.EntradaSaidaId == id);
            if (entradaSaida == null)
            {
                return NotFound();
            }

            return View(entradaSaida);
        }

        // POST: EntradaSaida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaSaida == null)
            {
                return Problem("Entity set 'Contexto.EntradaSaida'  is null.");
            }
            var entradaSaida = await _context.EntradaSaida.FindAsync(id);
            if (entradaSaida != null)
            {
                _context.EntradaSaida.Remove(entradaSaida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaSaidaExists(int id)
        {
          return (_context.EntradaSaida?.Any(e => e.EntradaSaidaId == id)).GetValueOrDefault();
        }
    }
}
