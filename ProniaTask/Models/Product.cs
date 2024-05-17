using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaTask.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int StockCount { get; set; }
        public string ImageUrl { get; set; }
        public float Raiting { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }


        
    }
}
