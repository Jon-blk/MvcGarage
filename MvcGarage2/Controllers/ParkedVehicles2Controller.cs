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
        public async Task<IActionResult> Index(string VehicleType, string regNbr)
        {
            ParkedVehicleViewModel parkedVehicleViewModel = new ParkedVehicleViewModel();

            var mvcGarage2Context = await _context.ParkedVehicle.Include(p => p.VehicleType).Include(p => p.Member).ToListAsync() ;

            // Filtrera på fordonstyp
            if (!string.IsNullOrEmpty(VehicleType))
            {
                mvcGarage2Context = mvcGarage2Context
                    .Where(v => v.VehicleType.Type == VehicleType)
                    .ToList();
            }

            // Filtrera på registreringsnummer
            if (!string.IsNullOrEmpty(regNbr))
            {
                //regNbr = regNbr.Trim().ToUpper();
                //parkedVehicleViewModel.RegNbr = regNbr;
                mvcGarage2Context = mvcGarage2Context.Where(p => p.RegistrationNumber.Contains(regNbr.Trim().ToUpper())).ToList();
            }

            parkedVehicleViewModel.ParkedVehicle = mvcGarage2Context;

            // Lista fordonstyper
            IEnumerable<string> vehicleTypes = from v in _context.VehicleType
                                               orderby v.Type
                                               select v.Type;

            parkedVehicleViewModel.VehicleTypes = new SelectList(vehicleTypes.Distinct());

            return View(parkedVehicleViewModel);
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
            var parkedVehicleCost = new VehiclePriceViewModel();
            parkedVehicleCost.ParkedVehicle = parkedVehicle;
            parkedVehicleCost.CurrentPrice = CalculateParkingCost(parkedVehicle.StartTime, parkedVehicle.VehicleType.ParkingPrice);
            return View(parkedVehicleCost);
        }

        private float CalculateParkingCost(DateTime startTime, float pricePerHour)
        {
            /* Currently implemented as cost per minute, should maybe charge for each start hour/half hour etc */
            var pricePerMinute = pricePerHour / 60.0;
            TimeSpan spentTime = DateTime.Now - startTime;
            return (float)(spentTime.TotalMinutes * pricePerMinute);
        }

        // GET: ParkedVehicles2/Create
        public IActionResult Create()
        {
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>().OrderBy(v => v.Type) , "Id", "Type");
            ViewData["MemberId"] = new SelectList(_context.Set<Member>().OrderBy(m => m.Name) , "Id", "Name");
            return View();
        }

        // POST: ParkedVehicles2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationNumber,Brand,VehicleModel,NumberOfWheels,StartTime,Color,MemberId,VehicleTypeId")] ParkedVehicle parkedVehicle)
        {
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", parkedVehicle.VehicleTypeId);
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "Id", "Name");

            if (_context.ParkedVehicle.Any(v => v.RegistrationNumber == parkedVehicle.RegistrationNumber.ToUpper()))
            {
                //return View(parkedVehicle);//Registration number already exists, don't add, TODO: feedback
                ModelState.AddModelError("RegistrationNumber", "Detta fordon är redan parkerat!");
                return View(parkedVehicle);
            }

            if (ModelState.IsValid)
            {
                parkedVehicle.StartTime = DateTime.Now;
                parkedVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber.ToUpper();
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", parkedVehicle.VehicleTypeId);
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "Id", "Name");
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
            // assumption: You can edit the registratration number (but not to something that already exists)
            if (_context.ParkedVehicle.Any(v => v.RegistrationNumber == parkedVehicle.RegistrationNumber.ToUpper() && v.Id != parkedVehicle.Id))
            {
                ModelState.AddModelError("RegistrationNumber", "Detta fordon finns redan på en annan plats!");
                ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", parkedVehicle.VehicleTypeId);
                ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "Id", "Name");

                return View(parkedVehicle); //TODO: error, edited reg-number to existing! 
            }

            if (ModelState.IsValid)
            {
                try
                {
                    parkedVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber.ToUpper();
                    parkedVehicle.StartTime = DateTime.Now < parkedVehicle.StartTime ? DateTime.Now : parkedVehicle.StartTime ; //don't allow setting future startdate
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
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", parkedVehicle.VehicleTypeId);
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "Id", "Name");

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
                .Include(p => p.Member)
                .FirstOrDefaultAsync(m => m.Id == id);

            var parkedVehicleCost = new VehiclePriceViewModel();

            if (parkedVehicle != null)
            {
                ViewData["Title"] = "Checkar ut fordonet";
                parkedVehicleCost.ParkedVehicle = parkedVehicle;
                parkedVehicleCost.CurrentPrice = CalculateParkingCost(parkedVehicle.StartTime, parkedVehicle.VehicleType.ParkingPrice);
            }
            else
            {
                TempData["Text"] = "Hittar inte fordonet - är det redan utcheckat?";
            }

            return View(parkedVehicleCost);
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
