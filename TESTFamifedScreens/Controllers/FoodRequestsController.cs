using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESTFamifedScreens.DAL.Context;
using TESTFamifedScreens.DAL.Entities;

namespace TESTFamifedScreens.WEB.Controllers
{
    public class FoodRequestsController : Controller
    {
        private readonly FamifedDatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FoodRequestsController(FamifedDatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: FoodRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodRequests.ToListAsync());
        }

        // GET: FoodRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRequest = await _context.FoodRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodRequest == null)
            {
                return NotFound();
            }

            return View(foodRequest);
        }

        // GET: FoodRequests/Create
        public IActionResult Create()
        {
            FoodOption opties = new FoodOption();
            ViewData["Opties"] = opties;
            //ViewData["Naam"] = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["Naam"] = "[userName]";
            return View();
        }

        // POST: FoodRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsThirsty,FlowStatusId,FoodOptionId,TimeOfReview,TimeOfOrder,Remark,RequestBy")] FoodRequest foodRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodRequest);
        }

        // GET: FoodRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRequest = await _context.FoodRequests.FindAsync(id);
            if (foodRequest == null)
            {
                return NotFound();
            }
            return View(foodRequest);
        }

        // POST: FoodRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsThirsty,FlowStatusId,TimeOfReview,TimeOfOrder,Remark")] FoodRequest foodRequest)
        {
            if (id != foodRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodRequestExists(foodRequest.Id))
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
            return View(foodRequest);
        }

        // GET: FoodRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodRequest = await _context.FoodRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodRequest == null)
            {
                return NotFound();
            }

            return View(foodRequest);
        }

        // POST: FoodRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodRequest = await _context.FoodRequests.FindAsync(id);
            _context.FoodRequests.Remove(foodRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodRequestExists(int id)
        {
            return _context.FoodRequests.Any(e => e.Id == id);
        }
    }
}
