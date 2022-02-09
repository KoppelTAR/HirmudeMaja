using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HirmudeMaja.Data;
using HirmudeMaja.Models;

namespace HirmudeMaja.Controllers
{
    public class SeiklejasController : Controller
    {
        private readonly HirmudeMajaContext _context;

        public SeiklejasController(HirmudeMajaContext context)
        {
            _context = context;
        }

        //Kood mis kasutatakse registreerimiseks
        //GET Registeeri meetod
        public IActionResult Registeeri()
        {
            return View();
        }

        //POST Registeeri meetod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registeeri([Bind("Id,Eesnimi")] Seikleja seikleja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seikleja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Popup),seikleja);
            }
            return View(seikleja);
        }

        public async Task<IActionResult> Sisenemine()
        {
            var model = _context.Seikleja.Where(e => e.Sisenemisaeg == null);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> SisestaSeikleja(int Id)
        {
            var seikleja = await _context.Seikleja.FindAsync(Id);
            if (seikleja == null)
            {
                return NotFound();
            }
            if (seikleja.Sisenemisaeg == null)
            {
                seikleja.Sisenemisaeg = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            }
            else
            {
                return NotFound();
            }
            try
            {
                _context.Update(seikleja);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeiklejaExists(seikleja.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Sisenemine));
        }

        public async Task<IActionResult> Väljumine()
        {
            var model = _context.Seikleja.Where(e => e.Väljumisaeg == null && e.Sisenemisaeg != null);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> VäljastaSeikleja(int Id)
        {
            var seikleja = await _context.Seikleja.FindAsync(Id);
            if (seikleja == null)
            {
                return NotFound();
            }
            if (seikleja.Väljumisaeg == null && seikleja.Sisenemisaeg != null)
            {
                seikleja.Väljumisaeg = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                seikleja.Vahemik = DateTime.Parse(seikleja.Väljumisaeg).Subtract(DateTime.Parse(seikleja.Sisenemisaeg));
            }
            else
            {
                return NotFound();
            }
            try
            {
                _context.Update(seikleja);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeiklejaExists(seikleja.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Väljumine));
        }

        public async Task<IActionResult> StatistikaLeht()
        {
            return View(await _context.Seikleja.OrderByDescending(e => e.Sisenemisaeg).ThenBy(e => e.Väljumisaeg).ThenBy(e => e.Eesnimi).ToListAsync());
        }

        public async Task<IActionResult> MajasOlevadSeiklejad()
        {
            var model = _context.Seikleja.Where(e => e.Väljumisaeg == null && e.Sisenemisaeg != null);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> Popup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seikleja = await _context.Seikleja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seikleja == null)
            {
                return NotFound();
            }

            return View(seikleja);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Seikleja.ToListAsync());
        }

        // GET: Seiklejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seikleja = await _context.Seikleja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seikleja == null)
            {
                return NotFound();
            }

            return View(seikleja);
        }

        // GET: Seiklejas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seiklejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Eesnimi,Sisenemisaeg,Väljumisaeg")] Seikleja seikleja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seikleja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seikleja);
        }

        // GET: Seiklejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seikleja = await _context.Seikleja.FindAsync(id);
            if (seikleja == null)
            {
                return NotFound();
            }
            return View(seikleja);
        }

        // POST: Seiklejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eesnimi,Sisenemisaeg,Väljumisaeg")] Seikleja seikleja)
        {
            if (id != seikleja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seikleja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeiklejaExists(seikleja.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(StatistikaLeht));
            }
            return View(seikleja);
        }

        // GET: Seiklejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seikleja = await _context.Seikleja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seikleja == null)
            {
                return NotFound();
            }

            return View(seikleja);
        }

        // POST: Seiklejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seikleja = await _context.Seikleja.FindAsync(id);
            _context.Seikleja.Remove(seikleja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(StatistikaLeht));
        }

        private bool SeiklejaExists(int id)
        {
            return _context.Seikleja.Any(e => e.Id == id);
        }
    }
}
