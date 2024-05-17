using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DataAccesLayer;
using ProniaTask.ViewModels.Products;

namespace ProniaTask.ViewComponents
{
    public class ProductViewComponent(ProniaContext _context):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Products
                .Select(k => new GetProductVM
                {
                    SellPrice = k.SellPrice,
                    IsStock = k.StockCount > 0,
                    Discount = k.Discount,
                    Id = k.Id,
                    ImageUrl = k.ImageUrl,
                    Name = k.Name,
                    Rating = k.Raiting,
                }).ToListAsync());
        }
    }
}
