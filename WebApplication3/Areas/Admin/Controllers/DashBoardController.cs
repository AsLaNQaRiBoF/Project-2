using Microsoft.AspNetCore.Mvc;
using WebApplication3.DAL;

namespace WebApplication3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        private readonly AppDbContext context;

        public DashBoardController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
