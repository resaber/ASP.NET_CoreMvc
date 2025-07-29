using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class CafeMealController : Controller
    {
        private readonly CatCafeDbContext _context;
        private readonly IWebHostEnvironment _enviro;

        public CafeMealController(CatCafeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviro = env;
        }

        public IActionResult List(CkeyWordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            //TCustomer
            IEnumerable<CafeMeal> datas = null;
            //LINQ ENtityFramework

            if (string.IsNullOrEmpty(keyword))
                //Factory 代表是TCustomer 資料表+s
                datas = from p in _context.CafeMeals
                        select p;
            else
                datas = _context.CafeMeals.Where(m => m.MealName.Contains(keyword));

            return View(datas);
        }
    }
}