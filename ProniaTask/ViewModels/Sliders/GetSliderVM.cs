using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Sliders
{
    public class GetSliderVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Discount { get; set; }

        public string Subtitle { get; set; }

        public string ImgUrl { get; set; }
    }
}
