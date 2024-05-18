using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;
using ProniaTask.Models;

namespace ProniaTask.Controllers
{
    public class ShopController:Controller
    {
        private readonly ProniaContext _context;

        public ShopController(ProniaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page =0, int? categoryId=null)
        {
            //ViewBag.MaxPage = Math.Ceiling((double)(await _context.Products.CountAsync() / 3));
            //var products = await _context.Products.Skip(3).Take(3).ToListAsync();
            //return View(products);
          
            //query-ni category-ye daxil edirik.
           IQueryable<Product> query= _context.Products.Include(p=>p.ProductCategories);


            if (categoryId != null)
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.CategoryId== categoryId));
            }


            double max = query.Count();

            ViewBag.CurrentCategory = categoryId;
            ViewBag.MaxPage = Math.Ceiling((double)max / 3);
            ViewBag.CurrentPage = page + 1;

            query = query.Skip(3 * page).Take(3);

           ViewBag.Categories = await _context.Categories.Include(p => p.ProductCategories).ToListAsync();


           return View(await query.ToListAsync());

          //  return View(/*await query.ToLi*/);
            //query
        }
    }
}








