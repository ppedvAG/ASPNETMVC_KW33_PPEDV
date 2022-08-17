using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Controllers
{
    public class LanguageInCountriesController : Controller
    {
        private readonly GeoDbContext _context;

        public LanguageInCountriesController(GeoDbContext context)
        {
            _context = context;
        }

        // GET: LanguageInCountries
        public async Task<IActionResult> Index()
        {
            var geoDbContext = _context.LanguagesInCountry.Include(l => l.CountryRef).Include(l => l.LanguageRef);
            return View(await geoDbContext.ToListAsync());
        }

        // GET: LanguageInCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguagesInCountry
                .Include(l => l.CountryRef)
                .Include(l => l.LanguageRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            return View();
        }

        // POST: LanguageInCountries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryId,LanguageId,Percent")] LanguageInCountry languageInCountry)
        {
            //Alle Sprachen die zu einem Land gehören, lesen wir aus
            List<LanguageInCountry> allLanguagesInCountry = _context.LanguagesInCountry.Where(l => l.CountryId == languageInCountry.CountryId).ToList();

            int reservedPercent = 0;

            if (allLanguagesInCountry.Count > 0)
            {
                reservedPercent = allLanguagesInCountry.Sum(l => l.Percent);
            }


            //Wenn wir höher als 100 sind, bekommen wir einen Fehler 
            if (reservedPercent + languageInCountry.Percent > 100)
            {
                int available = 100 - reservedPercent;
                ModelState.AddModelError("Percent", $"Alle Sprachanteile dürfen nicht über 100 Prozent liegen. Aktuell Verfügbar: {available}");
            }


            if (ModelState.IsValid)
            {
                _context.Add(languageInCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguagesInCountry.FindAsync(id);
            if (languageInCountry == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // POST: LanguageInCountries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryId,LanguageId,Percent")] LanguageInCountry languageInCountry)
        {
            if (id != languageInCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageInCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageInCountryExists(languageInCountry.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguagesInCountry
                .Include(l => l.CountryRef)
                .Include(l => l.LanguageRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // POST: LanguageInCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LanguagesInCountry == null)
            {
                return Problem("Entity set 'GeoDbContext.LanguagesInCountry'  is null.");
            }
            var languageInCountry = await _context.LanguagesInCountry.FindAsync(id);
            if (languageInCountry != null)
            {
                _context.LanguagesInCountry.Remove(languageInCountry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageInCountryExists(int id)
        {
          return _context.LanguagesInCountry.Any(e => e.Id == id);
        }
    }
}
