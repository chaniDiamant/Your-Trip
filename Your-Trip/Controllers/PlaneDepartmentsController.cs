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
    public class PlaneDepartmentsController : Controller
    {
        private readonly YourTripContext _context;

        public PlaneDepartmentsController(YourTripContext context)
        {
            _context = context;
        }

        // GET: PlaneDepartments
        public async Task<IActionResult> Index()
        {
            var yourTripContext = _context.PlaneDepartment.Include(p => p.Department).Include(p => p.Plane);
            return View(await yourTripContext.ToListAsync());
        }

        // GET: PlaneDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment
                .Include(p => p.Department)
                .Include(p => p.Plane)
                .SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }

            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentName"] = new SelectList(_context.Department, "Name", "Name");
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "PlaneId", "PlaneId");
            return View();
        }

        // POST: PlaneDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneId,DepartmentName")] PlaneDepartment planeDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planeDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentName"] = new SelectList(_context.Department, "Name", "Name", planeDepartment.DepartmentName);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "PlaneId", "PlaneId", planeDepartment.PlaneId);
            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment.SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentName"] = new SelectList(_context.Department, "Name", "Name", planeDepartment.DepartmentName);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "PlaneId", "PlaneId", planeDepartment.PlaneId);
            return View(planeDepartment);
        }

        // POST: PlaneDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneId,DepartmentName")] PlaneDepartment planeDepartment)
        {
            if (id != planeDepartment.PlaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planeDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneDepartmentExists(planeDepartment.PlaneId))
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
            ViewData["DepartmentName"] = new SelectList(_context.Department, "Name", "Name", planeDepartment.DepartmentName);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "PlaneId", "PlaneId", planeDepartment.PlaneId);
            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment
                .Include(p => p.Department)
                .Include(p => p.Plane)
                .SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }

            return View(planeDepartment);
        }

        // POST: PlaneDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planeDepartment = await _context.PlaneDepartment.SingleOrDefaultAsync(m => m.PlaneId == id);
            _context.PlaneDepartment.Remove(planeDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneDepartmentExists(int id)
        {
            return _context.PlaneDepartment.Any(e => e.PlaneId == id);
        }
    }
}
