using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;

namespace ProniaTask.Controllers
{
    public class ShopController:Controller
    {
        private readonly ProniaContext _context;

        public ShopController(ProniaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page =0)
        {
            //ViewBag.MaxPage = Math.Ceiling((double)(await _context.Products.CountAsync() / 3));
            //var products = await _context.Products.Skip(3).Take(3).ToListAsync();
            //return View(products);

           double max = await _context.Products.CountAsync();
           ViewBag.MaxPage = Math.Ceiling((double)max/3);
           ViewBag.CurrentPage = page + 1;

           var products = await _context.Products.Skip(3* page).Take(3).ToListAsync();
           return View(products);
        }
    }
}








