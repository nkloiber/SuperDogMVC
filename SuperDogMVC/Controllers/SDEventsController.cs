using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperDogMVC.Data;
using SuperDogMVC.Models;

namespace SuperDogMVC.Controllers
{
    public class SDEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SDEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SDEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: SDEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sDEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sDEvent == null)
            {
                return NotFound();
            }

            return View(sDEvent);
        }

        // GET: SDEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SDEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventName,EventCity,EventState,EventAttendance,EventDate")] SDEvent sDEvent)
        {
            if (ModelState.IsValid)
            {
                sDEvent.Created = DateTime.Now;
                _context.Add(sDEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sDEvent);
        }

        // GET: SDEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sDEvent = await _context.Events.FindAsync(id);
            if (sDEvent == null)
            {
                return NotFound();
            }
            return View(sDEvent);
        }

        // POST: SDEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,EventCity,EventState,EventAttendance,EventDate")] SDEvent sDEvent)
        {
            if (id != sDEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sDEvent.Updated = DateTime.Now;
                    _context.Update(sDEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SDEventExists(sDEvent.Id))
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
            return View(sDEvent);
        }

        // GET: SDEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sDEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sDEvent == null)
            {
                return NotFound();
            }

            return View(sDEvent);
        }

        // POST: SDEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sDEvent = await _context.Events.FindAsync(id);
            _context.Events.Remove(sDEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SDEventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
