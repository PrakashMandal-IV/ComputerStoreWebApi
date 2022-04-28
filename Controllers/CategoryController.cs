using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
