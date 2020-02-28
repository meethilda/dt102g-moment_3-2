using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CdAppTwo.Data;
using CdAppTwo.Models;

namespace CdAppTwo.Controllers
{
    public class SongsController : Controller
    {
        private readonly CdContext _context;

        public SongsController(CdContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var cdContext = _context.Songs.Include(s => s.CD);
            return View(await cdContext.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .Include(s => s.CD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            //ViewData["CdId"] = new SelectList(_context.CDs, "Id", "Id");
            ViewData["CdTitle"] = new SelectList(_context.CDs, "Id", "CdTitle");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongName,Playtime,CdId")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Cd");
            }
            //ViewData["CdId"] = new SelectList(_context.CDs, "Id", "Id", songs.CdId);
            ViewData["CdTitle"] = new SelectList(_context.CDs, "Id", "CdTitle", songs.CdId);
            return View(songs);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }
            //ViewData["CdId"] = new SelectList(_context.CDs, "Id", "Id", songs.CdId);
            ViewData["CdTitle"] = new SelectList(_context.CDs, "Id", "CdTitle", songs.CdId);
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongName,Playtime,CdId")] Songs songs)
        {
            if (id != songs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsExists(songs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Cd");
            }
            //ViewData["CdId"] = new SelectList(_context.CDs, "Id", "Id", songs.CdId);
            ViewData["CdTitle"] = new SelectList(_context.CDs, "Id", "CdTitle", songs.CdId);
            return View(songs);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .Include(s => s.CD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Cd");
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
