using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("about-us", Name ="about-us", Order = 1)]
        public ViewResult AboutUs(int id, string name)
        {
            return View();
        }

        [Route("contact-us", Name ="contact-us", Order = 1)]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
