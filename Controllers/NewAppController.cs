using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using composure.Models;

namespace composure.Controllers
{
        public class NewAppController : Controller
    {
        private readonly ComposureContext _context;

        public NewAppController(ComposureContext context)
        {
            _context = context;
        }

        // GET: NewApp
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewApp.ToListAsync());
        }

        // GET: NewApp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newApp = await _context.NewApp
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newApp == null)
            {
                return NotFound();
            }

            return View(newApp);
        }

        // GET: NewApp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewApp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Class,Spec,itemLevel")] NewApp newApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newApp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(newApp);
        }

        // GET: NewApp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newApp = await _context.NewApp.SingleOrDefaultAsync(m => m.ID == id);
            if (newApp == null)
            {
                return NotFound();
            }
            return View(newApp);
        }

        // POST: NewApp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Class,Spec,itemLevel")] NewApp newApp)
        {
            if (id != newApp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewAppExists(newApp.ID))
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
            return View(newApp);
        }

        // GET: NewApp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newApp = await _context.NewApp
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newApp == null)
            {
                return NotFound();
            }

            return View(newApp);
        }

        // POST: NewApp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newApp = await _context.NewApp.SingleOrDefaultAsync(m => m.ID == id);
            _context.NewApp.Remove(newApp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewAppExists(int id)
        {
            return _context.NewApp.Any(e => e.ID == id);
        }
    }
}
