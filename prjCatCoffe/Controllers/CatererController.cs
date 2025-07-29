using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class CatererController : Controller
    {
        private readonly CatCafeDbContext _context;
        private readonly IWebHostEnvironment _enviro;

        public CatererController(CatCafeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviro = env;
        }

        public IActionResult List(CkeyWordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            //TCustomer
            IEnumerable<Caterer> datas = null;
            //LINQ ENtityFramework

            if (string.IsNullOrEmpty(keyword))
                //Factory 代表是TCustomer 資料表+s
                datas = from p in _context.Caterers
                        select p;
            else
                datas = _context.Caterers.Where(m => m.LegalName.Contains(keyword));

            return View(datas);
        }
    }
}