using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
