using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("~/")]        
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs(int id, string name)
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
