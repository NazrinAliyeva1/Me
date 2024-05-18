using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ProniaTask.DataAccesLayer;
using ProniaTask.Extensions;
using ProniaTask.Models;
using ProniaTask.ViewModels.Products;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(ProniaContext _context, IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products
                .Select(p => new GetProductAdminVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    CostPrice = p.CostPrice,
                    SellPrice = p.SellPrice,
                    StockCount = p.StockCount,
                    Rating = p.Raiting,
                    Discount = p.Discount,
                    ImageUrl = p.ImageUrl,
                    Categories = p.ProductCategories.Select(pc => pc.Category.Name).Bind(','),
                    CreatedTime = p.CreateTime.ToString("dd, MMM, ddd"),
                    UpdatedTime = p.UpdateTime.Year > 1 ? p.UpdateTime.ToString("dd, MMM, ddd yyyy") : ""

                })
                .ToListAsync()); ;
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories
           .Where(s => !s.isDeleted)
            .ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM data)
        {
            if (data.ImageFile != null)
            {
                if (!data.ImageFile.IsValidType("image"))
                    ModelState.AddModelError("ImageFile", "Fayl şəkil formatında olmalıdır.");
                if (!data.ImageFile.IsValidLength(9000))
                    ModelState.AddModelError("ImageFile", "Faylın ölçüsü 900 kb-dan çox olmamalıdır.");
                //if (!ModelState.IsValid)
                //    return View(data);
            }
            bool isImageValid = true;
            StringBuilder sb = new StringBuilder();
            foreach (var img in data.ImageFiles ?? new List<IFormFile>())
            {
                if (!img.IsValidType("image"))
                {
                    sb.Append("-" + img.FileName + "faylı şəkil formatında deyil.");
                    //ModelState.AddModelError("ImageFiles", img.FileName + "faylı şəkil formatında deyil.");
                    isImageValid = false;
                }

                if (!img.IsValidLength(900))
                {
                    sb.Append("-" + img.FileName + "faylın ölçüsü 900kb-dan çox olmamalıdır.");
                    //ModelState.AddModelError("ImageFiles", img.FileName + "faylın ölçüsü 900kb-dan çox olmamalıdır.");
                    isImageValid = false;
                }

            }
            if (!isImageValid)
            {
                sb.Insert(0, "<ol>");
                sb.Append("</ol>");
                ModelState.AddModelError("ImageFiles", sb.ToString());
            }
            if (await _context.Categories.CountAsync(c => data.CategoryIds.Contains(c.Id)) != data.CategoryIds.Length)
                ModelState.AddModelError("CategoryIds", "Kategoriya tapilmadi");
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories
                .Where(s => !s.isDeleted)
                .ToListAsync();
                return View(data);
            }
            string fileName = await data.ImageFile.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));

            Product prod = new Product
            {
                Name = data.Name,
                CostPrice = data.CostPrice,
                CreateTime = DateTime.Now,
                SellPrice = data.SellPrice,
                StockCount = data.StockCount,
                Raiting = data.Raiting,
                Discount = data.Discount,
                ImageUrl = Path.Combine("imgs", "products", fileName),
                isDeleted = false,
                ProductImages = new List<ProductImage>(),
                ProductCategories = data.CategoryIds.Select(x => new ProductCategory
                {
                    CategoryId = x
                }).ToList()
            };
            foreach (var img in data.ImageFiles)
            {
                string imgName = await img.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));
                prod.ProductImages.Add(new ProductImage
                {
                    ImageUrl = Path.Combine(_env.WebRootPath, "imgs", "products"),
                    CreateTime = DateTime.Now,
                    isDeleted = false,
                });
            }
            await _context.Products.AddAsync(prod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //public async Task<IActionResult> Update(int? id)
        //{
        //    string fileName = await data.ImageFile.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));
        //    if (id == null || id < 1) return BadRequest();
        //    Product product = await _context.Products.FirstOrDefaultAsync();
        //    if (product is null) return NotFound();
        //    UpdateProductVM productVM = new UpdateProductVM
        //    {
        //        Discount = product.Discount,
        //        ImageUrl = Path.Combine("imgs", "products", fileName)
        //        SellPrice = product.SellPrice,
        //        Name = product.Name,
        //        Rating = product.Raiting,
        //        Categories = await _context.Categories.ToListAsync(),



        //    };
        //    return View(productVM);
        //}
        
        //public async Task<IActionResult> Update(int? id, UpdateProductVM productVM)
        //{
        //    if (id == null || id < 1) return BadRequest();
        //    Product existed = await _context.Products.FirstOrDefaultAsync();
        //    existed.Discount = productVM.Discount;
        //    existed.ImageUrl = productVM.ImageUrl;
        //    existed.SellPrice = productVM.SellPrice;
        //    existed.SellPrice= productVM.SellPrice;
        //    existed.ProductCategories = productVM.ProductCategories.Category.Name;


        //}
    }
}
