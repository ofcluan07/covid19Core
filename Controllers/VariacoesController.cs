using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RiskDegree.Models
{
    public class VariacoesController : Controller
    {
        private readonly RiskDegreeContext _context;

        public VariacoesController(RiskDegreeContext context)
        {
            _context = context;
        }

        // GET: Variacoes
        public async Task<IActionResult> Index()
        {
            var riskDegreeContext = _context.Variacoes.Include(v => v.IdpatologiaNavigation);
            return View(await riskDegreeContext.ToListAsync());
        }

        // GET: Variacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variacoes = await _context.Variacoes
                .Include(v => v.IdpatologiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variacoes == null)
            {
                return NotFound();
            }

            return View(variacoes);
        }

        // GET: Variacoes/Create
        public IActionResult Create()
        {
            ViewData["ListasPatologias"] = new SelectList(_context.Patologia, "Id", "Nome");
            return View();
        }

        // POST: Variacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idpatologia,Dia,Ano,Mes,NumeroInfectados,NumeroMortes,NumeroRecuperados")] Variacoes variacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListasPatologias"] = new SelectList(_context.Patologia, "Id", "Nome", variacoes.Idpatologia);
            return View(variacoes);
        }

        // GET: Variacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variacoes = await _context.Variacoes.FindAsync(id);
            if (variacoes == null)
            {
                return NotFound();
            }
            ViewData["ListasPatologias"] = new SelectList(_context.Patologia, "Id", "Nome", variacoes.Idpatologia);
            return View(variacoes);
        }

        // POST: Variacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idpatologia,Dia,Ano,Mes,NumeroInfectados,NumeroMortes,NumeroRecuperados")] Variacoes variacoes)
        {
            if (id != variacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariacoesExists(variacoes.Id))
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
            ViewData["ListasPatologias"] = new SelectList(_context.Patologia, "Id", "Nome", variacoes.Idpatologia);
            return View(variacoes);
        }

        // GET: Variacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variacoes = await _context.Variacoes
                .Include(v => v.IdpatologiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variacoes == null)
            {
                return NotFound();
            }

            return View(variacoes);
        }

        // POST: Variacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variacoes = await _context.Variacoes.FindAsync(id);
            _context.Variacoes.Remove(variacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariacoesExists(int id)
        {
            return _context.Variacoes.Any(e => e.Id == id);
        }
    }
}
