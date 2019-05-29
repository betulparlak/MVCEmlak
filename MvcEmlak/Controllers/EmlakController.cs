using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MvcEmlak.Models;

namespace MvcEmlak.Controllers
{
    public class EmlakController : Controller
    {
        private readonly MvcEmlakContext _context;

        public EmlakController(MvcEmlakContext context)
        {
            _context = context;
        }

        // GET: Emlak
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emlak.ToListAsync());
        }

        // GET: Emlak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlak = await _context.Emlak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emlak == null)
            {
                return NotFound();
            }

            return View(emlak);
        }

        // GET: Emlak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emlak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Category,Il,Ilce,Mahalle,Price,IlanTarihi,Photo")] Emlak emlak)
        {
            Debug.WriteLine(emlak.Photo);
            if (ModelState.IsValid)
            {
                _context.Add(emlak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(emlak);
        }

        // GET: Emlak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlak = await _context.Emlak.FindAsync(id);
            if (emlak == null)
            {
                return NotFound();
            }
            return View(emlak);
        }

        // POST: Emlak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Category,Il,Ilce,Mahalle,Price,IlanTarihi,Photo")] Emlak emlak)
        {
            if (id != emlak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emlak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmlakExists(emlak.Id))
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
            return View(emlak);
        }

        // GET: Emlak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlak = await _context.Emlak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emlak == null)
            {
                return NotFound();
            }

            return View(emlak);
        }

        // POST: Emlak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emlak = await _context.Emlak.FindAsync(id);
            _context.Emlak.Remove(emlak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmlakExists(int id)
        {
            return _context.Emlak.Any(e => e.Id == id);
        }
    }
}
