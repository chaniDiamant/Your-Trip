using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourTrip.Models;

namespace YourTrip.Controllers
{
    public class TerminalsController : Controller
    {
        private readonly YourTripContext _context;

        public TerminalsController(YourTripContext context)
        {
            _context = context;
        }

        // GET: Terminals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Terminal.ToListAsync());
        }

        // GET: Terminals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .SingleOrDefaultAsync(m => m.Name == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // GET: Terminals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terminals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terminal);
        }

        // GET: Terminals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal.SingleOrDefaultAsync(m => m.Name == id);
            if (terminal == null)
            {
                return NotFound();
            }
            return View(terminal);
        }

        // POST: Terminals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] Terminal terminal)
        {
            if (id != terminal.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminalExists(terminal.Name))
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
            return View(terminal);
        }

        // GET: Terminals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .SingleOrDefaultAsync(m => m.Name == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // POST: Terminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var terminal = await _context.Terminal.SingleOrDefaultAsync(m => m.Name == id);
            _context.Terminal.Remove(terminal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminalExists(string id)
        {
            return _context.Terminal.Any(e => e.Name == id);
        }
    }
}
