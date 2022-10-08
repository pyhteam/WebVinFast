using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Web.VinFast.Data;
using Web.VinFast.DTOs;
using Web.VinFast.Models;
using Web.VinFast.Util;

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
            var orderCar = await _context.Car.Take(10).Where(x => x.CategoryId == car.CategoryId).ToListAsync();
            ViewBag.OrderCar = orderCar;
            return View(car);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Intruduction()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<JsonResult> Register(UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Email == userRegister.Email);
                if (user != null)
                {
                    return Json(new { status = 201, message = "Email đã tồn tại" });
                }
                var newUser = new User()
                {
                    Name = userRegister.Name,
                    Email = userRegister.Email,
                    Password = Common.CreatedMD5(userRegister.Password),
                    CreatedDate = DateTime.Now
                };
                _context.User.Add(newUser);
                await _context.SaveChangesAsync();
                return Json(new { status = 200, message = "Đăng ký thành công" });
            }
            return Json(new { status = 203, message = "Đăng ký thất bại" });
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity;
                var checkExistUser = await _context.User.FirstOrDefaultAsync(x => x.Email == userLogin.Email);
                if (checkExistUser == null)
                {
                    return Json(new { status = 203, message = "Email không tồn tại" });
                }
                if (checkExistUser.Password != Common.CreatedMD5(userLogin.Password))
                {
                    return Json(new { status = 201, message = "Mật khẩu không đúng" });
                }
                var userClaims = new List<Claim>()
                 {
                    new Claim(ClaimTypes.NameIdentifier,checkExistUser.Id.ToString()),
                    new Claim(ClaimTypes.Name,checkExistUser.Name),
                    new Claim(ClaimTypes.Email,checkExistUser.Email),
                };
                identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var userPrincipal = new ClaimsPrincipal(new[] { identity });
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                         userPrincipal,
                         new AuthenticationProperties { IsPersistent = true });

                return Json(new { status = 200, message = "Đăng nhập thành công" });

            }
            else
            {
                return Json(new { status = 204, message = "Đăng nhập thất bại" });
            }

        }
    }
}