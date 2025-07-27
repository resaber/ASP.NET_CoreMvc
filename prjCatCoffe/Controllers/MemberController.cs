using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class MemberController : Controller
    {
        private IWebHostEnvironment _enviro;

        public MemberController(IWebHostEnvironment p)
        {
            _enviro = p;
        }

        public IActionResult List(CkeyWordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            //TCustomer
            IEnumerable<Member> datas = null;
            //LINQ ENtityFramework
            CatCafeDbContext db = new CatCafeDbContext();

            if (string.IsNullOrEmpty(keyword))
                //Factory 代表是TCustomer 資料表+s
                datas = from p in db.Members
                        select p;
            else
                datas = db.Members.Where(m => m.Name.Contains(keyword));

            return View(datas);
        }

        // GET: Member
        public IActionResult Create()
        {
            //傳遞資料到View
            return View();
        }

        //Member Post 新增會員
        [HttpPost]
        public IActionResult Create(Member m)
        {
            //LINQ ENtityFramework
            CatCafeDbContext db = new CatCafeDbContext();
            db.Members.Add(m);
            //存資料庫
            db.SaveChanges();
            //傳遞資料到View
            return RedirectToAction("List");
        }
    }
}