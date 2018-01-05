using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LorensHuculak_ASP.Models;
using VehiclistTest.Models;

namespace LorensHuculak_ASP.Controllers
{
    public class CarsController : Controller
    {
        private readonly LorensHuculak_ASPContext _context;

        public CarsController(LorensHuculak_ASPContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var lorensHuculak_ASPContext = _context.Car.Include(c => c.CarType).Include(c => c.Owner);
            return View(await lorensHuculak_ASPContext.ToListAsync());
        }

        // GET: Cars
        public async Task<IActionResult> Brands()
        {
            var lorensHuculak_ASPContext = _context.Car.Include(c => c.CarType).Include(c => c.Owner);
            return View(await lorensHuculak_ASPContext.ToListAsync());
        }

        // GET: Cars
        public async Task<IActionResult> Owners()
        {
            var lorensHuculak_ASPContext = _context.Car.Include(c => c.CarType).Include(c => c.Owner);
            return View(await lorensHuculak_ASPContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarType)
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarTypeID"] = new SelectList(_context.Set<CarType>(), "CarTypeID", "CarTypeID");
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "OwnerID");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarID,Color,PurchaseDate,LicensePlate,CarTypeID,OwnerID")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarTypeID"] = new SelectList(_context.Set<CarType>(), "CarTypeID", "CarTypeID", car.CarTypeID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "OwnerID", car.OwnerID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarTypeID"] = new SelectList(_context.Set<CarType>(), "CarTypeID", "CarTypeID", car.CarTypeID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "OwnerID", car.OwnerID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarID,Color,PurchaseDate,LicensePlate,CarTypeID,OwnerID")] Car car)
        {
            if (id != car.CarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarID))
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
            ViewData["CarTypeID"] = new SelectList(_context.Set<CarType>(), "CarTypeID", "CarTypeID", car.CarTypeID);
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "OwnerID", "OwnerID", car.OwnerID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarType)
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.SingleOrDefaultAsync(m => m.CarID == id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.CarID == id);
        }
    }
}
