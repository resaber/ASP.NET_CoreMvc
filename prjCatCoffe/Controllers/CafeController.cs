using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjCatCoffe.Models;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class CafeController : Controller
    {
        private readonly CatCafeDbContext _context;
        private readonly IWebHostEnvironment _enviro;

        public CafeController(CatCafeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviro = env;
        }

        public IActionResult List(CkeyWordViewModel c)
        {
            //LINQ ENtityFramework
            IEnumerable<Cafe> datas;

            if (string.IsNullOrEmpty(c.txtKeyword))
            {
                datas = _context.Cafes
                    .Include(c => c.Cater) // ⭐ 一定要加這行：載入對應的業者資料
                    .ToList();
            }
            else
            {
                datas = _context.Cafes
                    .Include(c => c.Cater) // ⭐ 搜尋時也要 Include，否則 View 會無法讀取 item.Cater
                    .Where(d => d.Name.Contains(c.txtKeyword))
                    .ToList();
            }

            return View(datas);
        }

        // GET: Cafe
        public IActionResult Create()
        {
            //傳遞資料到View
            return View();
        }

    //Cafe Post 新增
    [HttpPost]
        public IActionResult Create(Cafe c)
        {
            //先去檢查CatetId view的input欄位是否有和資料表的 業者id有對上，沒對上報錯，重新載入
            if(!_context.Caterers.Any(x => x.CatererId == c.CaterId))
            {
                ModelState.AddModelError("CaterId", "找不到對應的業者編號，無法新增餐廳，請重新輸入");
                return View(c);
            }
            // ⭐ 新增餐廳 儲存回資料庫
            _context.Cafes.Add(c);
            _context.SaveChanges();

            //島回首業
            return RedirectToAction("List");
         
        }

        public IActionResult Delete(int? id)
        {
            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");
            CatCafeDbContext db = new CatCafeDbContext();
            Cafe x = db.Cafes.FirstOrDefault(m => m.CafeId == id);
            if (x == null)
                return RedirectToAction("List");
            //最後移除他 並儲存 回列表
            db.Cafes.Remove(x);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");
            CatCafeDbContext db = new CatCafeDbContext();
            Cafe x = db.Cafes.FirstOrDefault(c => c.CafeId == id);
            if (x == null)
                return RedirectToAction("List");

            //給他編輯頁面的View
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(Cafe uiCafe)
        {
            // ⭐ 驗證 CaterId 是否存在於 Caterers 資料表
            if (!_context.Caterers.Any(c => c.CatererId == uiCafe.CaterId))
            {
                ModelState.AddModelError("CaterId", "找不到對應的業者編號，無法修改餐廳，請確認輸入是否正確");
                return View(uiCafe); // 回傳原資料，顯示錯誤訊息
            }

            // 找出資料庫原始資料
            var dbCafe = _context.Cafes.FirstOrDefault(c => c.CafeId == uiCafe.CafeId);
            if (dbCafe == null)
                return RedirectToAction("List");

            // 更新內容 存回資料庫
            dbCafe.CaterId = uiCafe.CaterId; // ⭐ 別忘了 CaterId 也要更新
            dbCafe.Name = uiCafe.Name;
            dbCafe.Description = uiCafe.Description;
            dbCafe.Phone = uiCafe.Phone;
            dbCafe.Address = uiCafe.Address;
            dbCafe.UpdatedAt = DateTime.Now;
            dbCafe.Status = uiCafe.Status;

            // 儲存資料
            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}