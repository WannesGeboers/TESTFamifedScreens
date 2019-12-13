using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESTFamifedScreens.DAL.Context;
using TESTFamifedScreens.DAL.Entities;

namespace TESTFamifedScreens.WEB.Controllers
{
    public class FoodOptionsController : Controller
    {
        private readonly FamifedDatabaseContext _context;

        public FoodOptionsController(FamifedDatabaseContext context)
        {
            _context = context;
        }

        // GET: FoodOptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodOptions.ToListAsync());
        }

        // GET: FoodOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOption = await _context.FoodOptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodOption == null)
            {
                return NotFound();
            }

            return View(foodOption);
        }

        // GET: FoodOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Price")] FoodOption foodOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodOption);
        }

        // GET: FoodOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOption = await _context.FoodOptions.FindAsync(id);
            if (foodOption == null)
            {
                return NotFound();
            }
            return View(foodOption);
        }

        // POST: FoodOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Price")] FoodOption foodOption)
        {
            if (id != foodOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodOptionExists(foodOption.Id))
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
            return View(foodOption);
        }

        // GET: FoodOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOption = await _context.FoodOptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodOption == null)
            {
                return NotFound();
            }

            return View(foodOption);
        }

        // POST: FoodOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodOption = await _context.FoodOptions.FindAsync(id);
            _context.FoodOptions.Remove(foodOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodOptionExists(int id)
        {
            return _context.FoodOptions.Any(e => e.Id == id);
        }
    }
}
