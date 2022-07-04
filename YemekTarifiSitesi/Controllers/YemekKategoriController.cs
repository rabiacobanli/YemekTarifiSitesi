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
    public class YemekKategoriController : Controller
    {
        private readonly YemekTarifiSitesiContext _context;

        public YemekKategoriController(YemekTarifiSitesiContext context)
        {
            _context = context;
        }

        // GET: YemekKategori
        public async Task<IActionResult> Index()
        {
            var yemekTarifiSitesiContext = _context.YemekKategori.Include(y => y.Kategori).Include(y => y.Yemek);
            return View(await yemekTarifiSitesiContext.ToListAsync());
        }

        // GET: YemekKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekKategori = await _context.YemekKategori
                .Include(y => y.Kategori)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yemekKategori == null)
            {
                return NotFound();
            }

            return View(yemekKategori);
        }

        // GET: YemekKategori/Create
        public IActionResult Create()
        {
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "KategoriID", "KategoriID");
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID");
            return View();
        }

        // POST: YemekKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,YemekID,KategoriID")] YemekKategori yemekKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yemekKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "KategoriID", "KategoriID", yemekKategori.KategoriID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekKategori.YemekID);
            return View(yemekKategori);
        }

        // GET: YemekKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekKategori = await _context.YemekKategori.FindAsync(id);
            if (yemekKategori == null)
            {
                return NotFound();
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "KategoriID", "KategoriID", yemekKategori.KategoriID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekKategori.YemekID);
            return View(yemekKategori);
        }

        // POST: YemekKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,YemekID,KategoriID")] YemekKategori yemekKategori)
        {
            if (id != yemekKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemekKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemekKategoriExists(yemekKategori.ID))
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
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "KategoriID", "KategoriID", yemekKategori.KategoriID);
            ViewData["YemekID"] = new SelectList(_context.Yemek, "YemekID", "YemekID", yemekKategori.YemekID);
            return View(yemekKategori);
        }

        // GET: YemekKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekKategori = await _context.YemekKategori
                .Include(y => y.Kategori)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yemekKategori == null)
            {
                return NotFound();
            }

            return View(yemekKategori);
        }

        // POST: YemekKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yemekKategori = await _context.YemekKategori.FindAsync(id);
            _context.YemekKategori.Remove(yemekKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemekKategoriExists(int id)
        {
            return _context.YemekKategori.Any(e => e.ID == id);
        }
    }
}
