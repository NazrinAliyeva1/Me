using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Products
{
    public class UpdateProductVM
    {
        [MaxLength(70)]
        public string? Name { get; set; }
        [Range(0,1000)]
        public decimal SellPrice { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public float Rating { get; set; }

        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public int StockCount { get; set; }
        [Required]
        public string Categories { get; set; }

        public IFormFile ImageFile { get; set; }
        [Required]

        public int[] CategoryIds { get; set; }

        public IEnumerable<IFormFile> ImageFiles { get; set; }


    }
    }
