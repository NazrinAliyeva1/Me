using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Products
{
    public class CreateProductVM
    {
        [Required] 
        public string? Name { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
        [Required]

        public int Discount { get; set; }
        [Required]

        public int StockCount { get; set; }
        [Required]

        public IFormFile ImageFile { get; set; }
        [Required]

        public int[] CategoryIds { get; set; }
        public float Raiting { get; set; }

        public IEnumerable<IFormFile> ImageFiles { get; set; }
    }
}
