using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
