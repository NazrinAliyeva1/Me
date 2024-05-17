using ProniaTask.ViewModels.Categories;
using ProniaTask.ViewModels.Sliders;

namespace ProniaTask.ViewModels.Defaults
{
    public class HomeVM
    {
        public IEnumerable<GetSliderVM> Sliders { get; set; }
        public IEnumerable<GetCategoryVM> Categories { get; set; }
    }
}
