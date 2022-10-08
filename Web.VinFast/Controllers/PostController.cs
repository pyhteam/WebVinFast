using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Data;

namespace Web.VinFast.Controllers
{
    public class PostController : Controller
    {
        private readonly VinFastDbContext _context;
        public PostController(VinFastDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var post = await _context.Post.OrderByDescending(x => x.Title).Take(20)
                .Include(x => x.User).ToListAsync();
            var postHot = await _context.Post.OrderByDescending(x => x.CreatedDate).Take(5)
                .Include(x => x.User).ToListAsync();
            ViewBag.PostHot = postHot;
            return View(post);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Post
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
