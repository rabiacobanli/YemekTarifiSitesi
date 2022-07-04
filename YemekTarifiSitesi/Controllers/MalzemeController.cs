﻿using System;
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
    public class MalzemeController : Controller
    {
        private readonly YemekTarifiSitesiContext _context;

        public MalzemeController(YemekTarifiSitesiContext context)
        {
            _context = context;
        }

        // GET: Malzeme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Malzeme.ToListAsync());
        }

        // GET: Malzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme
                .FirstOrDefaultAsync(m => m.MalzemeID == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // GET: Malzeme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Malzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MalzemeID,MalzemeAdi,MalzemeMiktar,MiktarKategori")] Malzeme malzeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(malzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(malzeme);
        }

        // GET: Malzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme.FindAsync(id);
            if (malzeme == null)
            {
                return NotFound();
            }
            return View(malzeme);
        }

        // POST: Malzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MalzemeID,MalzemeAdi,MalzemeMiktar,MiktarKategori")] Malzeme malzeme)
        {
            if (id != malzeme.MalzemeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalzemeExists(malzeme.MalzemeID))
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
            return View(malzeme);
        }

        // GET: Malzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme
                .FirstOrDefaultAsync(m => m.MalzemeID == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // POST: Malzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malzeme = await _context.Malzeme.FindAsync(id);
            _context.Malzeme.Remove(malzeme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalzemeExists(int id)
        {
            return _context.Malzeme.Any(e => e.MalzemeID == id);
        }
    }
}
