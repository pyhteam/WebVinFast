using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.VinFast.Data;
using Web.VinFast.DTOs;
using Web.VinFast.Models;

namespace Web.VinFast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VinFastDbContext _context;

        public HomeController(ILogger<HomeController> logger, VinFastDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 5 car with highest price
            var cars = await _context.CarCategory.Take(3)
                .Include(x => x.Cars)
                .Select(x => new CarCategoryView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cars = x.Cars.OrderByDescending(x => x.Price).Take(5).ToList()
                }).ToListAsync();
            return View(cars);
        }
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // 5 car with highest price
            var car = await _context.Car
                .Include(x => x.CarCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}