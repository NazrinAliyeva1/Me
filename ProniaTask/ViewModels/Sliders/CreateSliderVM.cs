using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(35, ErrorMessage = "Basliq 35 simvoldan cox ola bilmez!"), Required]
        public string Title { get; set; }

        [Range(0, 100, ErrorMessage = "Endirim 0 ile 100 arasinda olmalidir!")]
        public int Discount { get; set; }

        [MaxLength(64, ErrorMessage = "Yazi 64 simvoldan cox ola bilmez!"), Required]
        public string Subtitle { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
