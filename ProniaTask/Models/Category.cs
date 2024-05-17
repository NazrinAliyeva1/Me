namespace ProniaTask.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        //gedir CategoryProduct yaradir eyni id'li primary key ile
        public ICollection<ProductCategory>? ProductCategories { get; set;}
    }
}
