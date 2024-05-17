using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Sliders
{
    public class UpdateSliderVM
    {

        [MaxLength(35), Required]
        public string Title { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        [MaxLength(64), Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
