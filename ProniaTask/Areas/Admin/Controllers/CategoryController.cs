using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;
using ProniaTask.ViewModels.Categories;
using ProniaTask.ViewModels.Products;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ProniaContext _sql) : Controller
    {
        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            return View(await _sql.Categories.Select(c => new GetCategoryVM
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync());
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM vm)
        {
            if(vm.Name!=null && await _sql.Categories.AnyAsync(c => c.Name == vm.Name))
            {
                ModelState.AddModelError("Name", "Ad movcuddur.");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _sql.Categories.AddAsync(new Models.Category
            {
                CreateTime = DateTime.Now,
                isDeleted = false,
                Name = vm.Name
            });
            await _sql.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
