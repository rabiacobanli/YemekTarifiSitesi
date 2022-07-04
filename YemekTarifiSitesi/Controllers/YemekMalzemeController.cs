using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace YemekTarifiSitesi.Controllers
{
    [Authorize]
    public class YemekMalzemeController : Controller
    {
        private readonly YemekTarifiSitesiContext _context;

        public YemekMalzemeController(YemekTarifiSitesiContext context)
        {
            _context = context;
        }

        // GET: YemekMalzeme
        public async Task<IActionResult> Index()
        {
            var yemekTarifiSitesiContext = _context.YemekMalzeme.Include(y => y.Malzeme).Include(y => y.Yemek);
            return View(await yemekTarifiSitesiContext.ToListAsync());
        }

        // GET: YemekMalzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekMalzeme = await _context.YemekMalzeme
                .Include(y => y.Malzeme)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yemekMalzeme == null)
            {
                return NotFound();
            }

            return View(yemekMalzeme);
        }

        // GET: YemekMalzeme/Create
        public IActionResult Create()
        {
            ViewData["MalzemeID"] = new SelectList(_context.Malzeme, "MalzemeID", "MalzemeID");
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID");
            return View();
        }

        // POST: YemekMalzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,YemekID,MalzemeID")] YemekMalzeme yemekMalzeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yemekMalzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MalzemeID"] = new SelectList(_context.Malzeme, "MalzemeID", "MalzemeID", yemekMalzeme.MalzemeID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekMalzeme.YemekID);
            return View(yemekMalzeme);
        }

        // GET: YemekMalzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekMalzeme = await _context.YemekMalzeme.FindAsync(id);
            if (yemekMalzeme == null)
            {
                return NotFound();
            }
            ViewData["MalzemeID"] = new SelectList(_context.Malzeme, "MalzemeID", "MalzemeID", yemekMalzeme.MalzemeID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekMalzeme.YemekID);
            return View(yemekMalzeme);
        }

        // POST: YemekMalzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,YemekID,MalzemeID")] YemekMalzeme yemekMalzeme)
        {
            if (id != yemekMalzeme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemekMalzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemekMalzemeExists(yemekMalzeme.ID))
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
            ViewData["MalzemeID"] = new SelectList(_context.Malzeme, "MalzemeID", "MalzemeID", yemekMalzeme.MalzemeID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekMalzeme.YemekID);
            return View(yemekMalzeme);
        }

        // GET: YemekMalzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekMalzeme = await _context.YemekMalzeme
                .Include(y => y.Malzeme)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yemekMalzeme == null)
            {
                return NotFound();
            }

            return View(yemekMalzeme);
        }

        // POST: YemekMalzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yemekMalzeme = await _context.YemekMalzeme.FindAsync(id);
            _context.YemekMalzeme.Remove(yemekMalzeme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemekMalzemeExists(int id)
        {
            return _context.YemekMalzeme.Any(e => e.ID == id);
        }
    }
}
