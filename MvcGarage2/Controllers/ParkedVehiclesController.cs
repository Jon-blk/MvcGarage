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
    enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

    public class ParkedVehiclesController : Controller
    {
        private readonly MvcGarage2Context _context;

        public ParkedVehiclesController(MvcGarage2Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle.ToListAsync());
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

        private decimal CalculateParkingCost(DateTime startTime)
        {
            /* Currently implemented as cost per minute, should maybe charge for each start hour/half hour etc */
            const decimal pricePerHour = 10M;
            var pricePerMinute = pricePerHour / 60M;
            TimeSpan spentTime = DateTime.Now - startTime;
            return (spentTime.Minutes * pricePerMinute);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {

            var parkingView = new ParkedVehicleViewModel();
            //var tempArray = Enum.GetValues(typeof(VehicleType));//enum => list
            //var tempList = new List<string>();
            //foreach (string item in tempArray)
            //{
            //    tempList.Add(item as string);
            //}
            //parkingView.Types = new SelectList(tempList);


            //var tempArray2 = Enum.GetValues(typeof(Colors));//enum => list
            //var tempList2 = new List<string>();
            //foreach (string colorName in Enum.GetValues(typeof(Colors)))
            //{
            //    tempList2.Add(colorName);
            //}

            //parkingView.Colors = new SelectList(tempList2);

            parkingView.Colors = new SelectList(new string[] { "Blue", "Black", "Green" });
            parkingView.Types = new SelectList(new string[] { "Car", "Motorcycle", "Bus" });

            return View(parkingView);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationNumber,Brand,VehicleModel,NumberOfWheels,VehicleType,Color")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                parkedVehicle.StartTime = DateTime.Now;
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
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

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
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
