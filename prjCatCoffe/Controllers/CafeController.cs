using Microsoft.AspNetCore.Mvc;

namespace prjCatCoffe.Controllers
{
    public class CafeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
