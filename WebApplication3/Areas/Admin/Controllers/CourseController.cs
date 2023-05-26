using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext context;

        public CourseController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.courses.Include(x=>x.teacher).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Courses courses)
        {
            if (!ModelState.IsValid) return View();
            
            await context.courses.AddAsync(courses);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await context.courses.FirstOrDefaultAsync(x => x.Id == Id));
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Edit(Courses courses)
        {
            if (!ModelState.IsValid)
                return View();
            if (courses == null)
                return NotFound();
            Courses? exist = await context.courses.FirstOrDefaultAsync(x => x.Id == courses.Id);
            exist.Title = courses.Title;
            exist.Price=courses.Price;
            exist.Time=courses.Time;
            exist.TeacherId=courses.TeacherId;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Courses exist=await context.courses.FirstOrDefaultAsync(x => x.Id == Id);
            if (exist == null)
                return NotFound();
            context.courses.Remove(exist);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
