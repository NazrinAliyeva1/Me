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
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync(); 
            return View(products);
        }
    }
}
