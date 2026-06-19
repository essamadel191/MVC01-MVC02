using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC01_MVC02.Context;

namespace MVC01_MVC02.Controllers
{
    public class PlanController : Controller
    {
        // Database Connection

        public readonly GymDbContext _context;
        public PlanController() 
        {
            _context = new GymDbContext();
        }
        // GET :: BaseUrl /Plan/Index
        public async Task<IActionResult> Index()
        {
            var plans = await _context.Plans.ToListAsync();

            return View(plans);
        }

        // GET :: BaseUrl /Plan/Details/{id}
        public async Task<IActionResult> Details(int id) 
        {
            var plan = await _context.Plans.FindAsync(id);
            if(plan == null) 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
