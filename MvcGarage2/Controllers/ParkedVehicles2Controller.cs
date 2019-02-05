using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGarage2.Models;

namespace MvcGarage2.Controllers
{
    public class ParkedVehicles2Controller : Controller
    {
        private readonly MvcGarage2Context _context;

        public ParkedVehicles2Controller(MvcGarage2Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles2
        public async Task<IActionResult> Index()
        {
            var mvcGarage2Context = _context.ParkedVehicle.Include(p => p.VehicleType).Include(p => p.Member);
            return View(await mvcGarage2Context.ToListAsync());
        }

        // GET: ParkedVehicles2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .Include(p => p.VehicleType)
                .Include(p => p.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Create
        public IActionResult Create()
        {
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type");
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "Id", "Name");
            return View();
        }

        // POST: ParkedVehicles2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationNumber,Brand,VehicleModel,NumberOfWheels,StartTime,Color,MemberId,VehicleTypeId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationNumber,Brand,VehicleModel,NumberOfWheels,StartTime,Color,MemberId,VehicleTypeId")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
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
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .Include(p => p.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}
