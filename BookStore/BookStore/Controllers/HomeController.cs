using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [Route("about-us/test/{id?}/{name}")]
        public ViewResult AboutUs(int id, string name)
        {
            return View();
        }

        [Route("contact-us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
