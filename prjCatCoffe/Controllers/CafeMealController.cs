using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using prjCatCoffe.Models;
using prjCatCoffe.Models.Wrap;
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

        // GET: Product
        public IActionResult Create()
        {
            //Step1
            //取得所有餐廳資訊
            //變成下拉選單傳到後端
            var cafes = _context.Cafes.ToList();
            var types = _context.CafeMealTypes.ToList();
            //
            //<select name="CafeId">
            //< option value = "1" > 貓咪咖啡館 </ option >
            //< option value = "2" > 貓茶屋 </ option >
            //</ select >
            ViewBag.CafeList = new SelectList(cafes, "CafeId", "Name");

            ViewBag.TypeList = new SelectList(types, "TypeId", "Name");
            //傳遞資料到View
            return View();
        }

        //  Product Post

        [HttpPost]
        public IActionResult Create(CCafeMealWrap uiMeal)
        {
            //LINQ ENtityFramework
            //上傳檔案格式
            if (uiMeal.photo != null)
            {
                string ext = Path.GetExtension(uiMeal.photo.FileName); // 副檔名
                string fileName = Guid.NewGuid().ToString() + ext;     // 唯一檔名
                uiMeal.ImageUrl = fileName;                            // 回寫到 Wrap 中

                string savePath = Path.Combine(_enviro.WebRootPath, "images", "Meal_Singlephoto", fileName);
                using var fileStream = new FileStream(savePath, FileMode.Create);
                uiMeal.photo.CopyTo(fileStream);
            }

            //先去檢查CatetId view的input欄位是否有和資料表的 業者id有對上，沒對上報錯，重新載入
            if (!_context.Cafes.Any(x => x.CafeId == uiMeal.CafeId))
            {
                ModelState.AddModelError("CafeId", "找不到對應的餐廳，無法新增餐點，請重新輸入");
                return View(uiMeal);
            }

            // 3. 建立新餐點物件
            CafeMeal meal = new CafeMeal
            {
                MealName = uiMeal.MealName,
                Description = uiMeal.Description,
                Price = uiMeal.Price,
                TypeId = uiMeal.TypeId,
                CafeId = uiMeal.CafeId,
                ImageUrl = uiMeal.ImageUrl,
                IsActive = uiMeal.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            // 4. 儲存到資料庫
            _context.CafeMeals.Add(meal);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");

            CafeMeal x = _context.CafeMeals.FirstOrDefault(c => c.MealId == id);
            if (x == null)
                return RedirectToAction("List");
            //最後移除他 並儲存 回列表
            _context.CafeMeals.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}