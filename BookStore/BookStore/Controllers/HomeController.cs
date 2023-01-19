using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("[controller]/[action]")]
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
