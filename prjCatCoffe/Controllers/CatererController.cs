using Microsoft.AspNetCore.Mvc;

namespace prjCatCoffe.Controllers
{
    public class CatererController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
