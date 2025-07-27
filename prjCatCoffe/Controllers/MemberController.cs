using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class MemberController : Controller
    {
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
    }
}