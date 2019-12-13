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
    public class FlowStatusController : Controller
    {
        private readonly FamifedDatabaseContext _context;

        public FlowStatusController(FamifedDatabaseContext context)
        {
            _context = context;
        }

        // GET: FlowStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodRequests.Where(x=>x.FlowStatusId==0).ToListAsync());
        }

        // GET: FlowStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowStatus = await _context.FlowStatusMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowStatus == null)
            {
                return NotFound();
            }

            return View(flowStatus);
        }

        // GET: FlowStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlowStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Message")] FlowStatus flowStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flowStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowStatus);
        }

        // GET: FlowStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.FoodRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: FlowStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Message")] FlowStatus flowStatus)
        {
            if (id != flowStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowStatusExists(flowStatus.Id))
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
            return View(flowStatus);
        }

        // GET: FlowStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowStatus = await _context.FlowStatusMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowStatus == null)
            {
                return NotFound();
            }

            return View(flowStatus);
        }

        // POST: FlowStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flowStatus = await _context.FlowStatusMessages.FindAsync(id);
            _context.FlowStatusMessages.Remove(flowStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowStatusExists(int id)
        {
            return _context.FlowStatusMessages.Any(e => e.Id == id);
        }
    }
}
