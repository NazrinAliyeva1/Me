using Microsoft.AspNetCore.Mvc;
using ProniaTask.DataAccesLayer;

namespace ProniaTask.ViewComponents
{
    public class HeaderViewComponent(ProniaContext _context) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
