using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGarage2.Models;

namespace MvcGarage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly MvcGarage2Context _context;

        public ParkedVehiclesController(MvcGarage2Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index(string sortOrder)
        {
           
            ViewData["RegSortParm"] = String.IsNullOrEmpty(sortOrder) ? "reg_desc" : "Reg";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["BrandSortParam"] = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewData["VehicleModelSortParam"] = sortOrder == "VehicleModel" ? "vehiclesModel_desc" : "VehicleModel";
            var vehicles = from s in _context.ParkedVehicle
                           select s;
            switch (sortOrder)
            {

                case "Brand":
                    vehicles = vehicles.OrderBy(s => s.Brand);
                    break;
                case "brand_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Brand);
                    break;
                case "VehicleModel":
                    vehicles = vehicles.OrderBy(s => s.VehicleModel);
                    break;
                case "vehiclesModel_desc":
                    vehicles = vehicles.OrderByDescending(s => s.VehicleModel);
                    break;
                case "reg_desc":
                    vehicles = vehicles.OrderByDescending(s => s.RegistrationNumber);
                    break;
                case "Reg":
                    vehicles = vehicles.OrderBy(s => s.RegistrationNumber);
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(s => s.StartTime);
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(s => s.StartTime);
                    break;
                default:
                    vehicles = vehicles.OrderBy(s => s.RegistrationNumber);
                    break;
            }
          
            return View(await vehicles.AsNoTracking().ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            var parkedVehicleCost = new VehiclePriceViewModel();
            parkedVehicleCost.ParkedVehicle = parkedVehicle;
            parkedVehicleCost.CurrentPrice = $"{CalculateParkingCost(parkedVehicle.StartTime):C2}";
            return View(parkedVehicleCost);
        }
  







        private double CalculateParkingCost(DateTime startTime)
        {
            /* Currently implemented as cost per minute, should maybe charge for each start hour/half hour etc */
            const double pricePerHour = 10.0;
            var pricePerMinute = pricePerHour / 60.0;
            TimeSpan spentTime = DateTime.Now - startTime;
            return (spentTime.TotalMinutes * pricePerMinute);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {

            var vehicleParking = new ParkedVehicle();
            return View(vehicleParking);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationNumber,Brand,VehicleModel,NumberOfWheels,VehicleType,Color")] ParkedVehicle parkedVehicle)
        {
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
                TempData["AlertMsg"] = $"Fordonet med registreringsnumret {parkedVehicle.RegistrationNumber} har parkerats";
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
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
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationNumber,Brand,VehicleModel,NumberOfWheels,StartTime,VehicleType,Color")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            // assumption: You can edit the registratration number (but not to something that already exists)
            if (_context.ParkedVehicle.Any(v => v.RegistrationNumber == parkedVehicle.RegistrationNumber.ToUpper() && v.Id != parkedVehicle.Id))
            {
                ModelState.AddModelError("RegistrationNumber", "Detta fordon finns redan på en annan plats!");
                return View(parkedVehicle); //TODO: error, edited reg-number to existing! 
            }

            if (ModelState.IsValid)
            {


                parkedVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber.ToUpper();
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
                TempData["AlertMsg"] = $"Fordonet med registreringsnumret {parkedVehicle.RegistrationNumber} har redigerats";

                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            var parkedVehicleCost = new VehiclePriceViewModel();
            parkedVehicleCost.ParkedVehicle = parkedVehicle;
            parkedVehicleCost.CurrentPrice = $"{CalculateParkingCost(parkedVehicle.StartTime):C2}";
            return View(parkedVehicleCost);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle;

            parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            var parkedVehicleCost = new VehiclePriceViewModel();
            parkedVehicleCost.ParkedVehicle = parkedVehicle;
            parkedVehicleCost.CurrentPrice = $"{CalculateParkingCost(parkedVehicle.StartTime):C2}";

            return View("Receipt", parkedVehicleCost); //doesn't currently work while reloading
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }




        // Search ##################################################
        
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search([Bind("RegistrationNumber")] ParkedVehicle searchData)
        {
            ParkedVehicle vehicle = null;

            if (!string.IsNullOrEmpty(searchData.RegistrationNumber))
            {
                vehicle = _context.ParkedVehicle
                    .FirstOrDefault(v => v.RegistrationNumber == searchData.RegistrationNumber);

                if (vehicle != null && vehicle.NumberOfWheels > 0)
                {
                    // Träff på fordon
                    searchData = vehicle;
                }
            }

            return View(searchData);
        }
    }
}
