using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarsCrudWithPagination.Data;
using CarsCrudWithPagination.Models;
using X.PagedList.Extensions;

namespace CarsCrudWithPagination.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsDbContext _context;

        public CarsController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(int? page)
        {
            var cars = await _context.Cars.Include(c => c.Color).ToListAsync();

            var pageNumber = page ?? 1;
            var OnePageOfCars = cars.ToPagedList(pageNumber, 3);

            //ViewBag.OnePageOfCars = OnePageOfCars;

            return View(OnePageOfCars);
        }
        private async Task GetColors()
        {
            var colors = await _context.Colors.AsNoTracking().ToListAsync();
            ViewBag.Colors = new SelectList(colors, nameof(Colors.ColorNo), nameof(Colors.ColorName));
        }
        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarNo == id);
            if (car == null)
            {
                return NotFound();
            }

            await GetColors();

            var First = await _context.Cars.
               AsNoTracking().
               MinAsync(c => c.CarNo);

            var Previous = await _context.Cars
                    .AsNoTracking()
                    .Where(c => c.CarNo < id)
                    .OrderByDescending(c => c.CarNo)
                    .FirstOrDefaultAsync();

            var Next = await _context.Cars
                   .AsNoTracking()
                   .Where(c => c.CarNo > id)
                   .OrderBy(c => c.CarNo)
                   .FirstOrDefaultAsync();

            var Last = await _context.Cars.
               AsNoTracking().
               MaxAsync(c => c.CarNo);

            var CarDetailsViewModel = new CarDetailsViewModel()
            {
                Car = car,
                Paginition = new Paginition(First: First,
                                    Previous: (Previous?.CarNo ?? 0),
                                    Current: (int)id,
                                    Next: (Next?.CarNo ?? 0),
                                    Last: Last)
            };

            return View(CarDetailsViewModel);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            await GetColors();

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarNo,UserNo,ArName,EnName,CardNo,BeginDate,EndDate,Company,ColorNo,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = car.CarNo });
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await GetColors();

            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarNo,UserNo,ArName,EnName,CardNo,BeginDate,EndDate,Company,ColorNo,Model")] Car car)
        {
            if (id != car.CarNo)
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
                    if (!CarExists(car.CarNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = car.CarNo });
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarNo == id);
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
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarNo == id);
        }
    }
}
