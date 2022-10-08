using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Data;

namespace Web.VinFast.Controllers
{
    public class ProductController : Controller
    {
        private readonly VinFastDbContext _context;
        public ProductController(VinFastDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Car.OrderByDescending(x => x.CreatedDate).Take(20)
                .Include(x => x.CarCategory).ToListAsync();
            return View(cars);
        }
    }
}
