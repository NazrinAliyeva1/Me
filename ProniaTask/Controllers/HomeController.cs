using Microsoft.AspNetCore.Mvc;
using ProniaTask.DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProniaTask.ViewModels.Categories;
using ProniaTask.ViewModels.Sliders;
using ProniaTask.ViewModels.Defaults;
using ProniaTask.Models;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaContext _context;

        public HomeController(ProniaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //var data= await _context.Categories.Where(c=>c.Name.Length<5).ToListAsync();
            //var data= await _context.Categories.Take(5).ToListAsync();
            //var data= await _context.Categories
            //    .OrderByDescending(x=>x.Id)
            //    .Take(5)
            //    .ToListAsync();
            //return View(data);

           var sliders = await _context.Sliders
                .Where(a=>!a.isDeleted)
                .Select(y=> new GetSliderVM
                {
                    Id = y.Id,
                    Discount = y.Discount,
                    ImgUrl =y.ImgUrl,
                    Subtitle =y.Subtitle,
                    Title=y.Title
                }).ToListAsync();
            var categories = await _context.Categories
                .Where(a => !a.isDeleted)
                .Select(s => new GetCategoryVM
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToListAsync();
            return View(new HomeVM
            {
                Sliders = sliders,
                Categories = categories,
            });
        }

        public async Task<IActionResult> Test(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var cat = await _context.Categories.FindAsync(id);
            if (id == null) return NotFound();
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Content(cat.Name);
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
    }
}
