using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using prjCatCoffe.Models;
using prjCatCoffe.Models.Wrap;
using prjCatCoffe.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            //Factory 代表是TCustomer 資料表+s
            datas = _context.CafeMeals
                    .Include(m => m.Cafe)        // 所屬餐廳關聯Cafe資料表
                    .Include(m => m.Type)        // 關聯到 MealType 資料表
                    .ToList();
            

            if (!string.IsNullOrEmpty(keyword))
            {
                datas = datas.Where(m => m.MealName.Contains(keyword)).ToList();
            }


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

            //  刪除圖檔
            if (!string.IsNullOrEmpty(x.ImageUrl))
            {
                string photoPath = Path.Combine(_enviro.WebRootPath, "images", "Meal_Singlephoto", x.ImageUrl);
                if (System.IO.File.Exists(photoPath))
                    System.IO.File.Delete(photoPath);  // ⭐ 刪除檔案
            }

            //最後移除他 並儲存 回列表
            _context.CafeMeals.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        //編輯餐點封面照
        public IActionResult Edit(int? id)
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
            CafeMeal x = _context.CafeMeals.FirstOrDefault(m => m.MealId == id);

            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");

            if (x == null)
                return RedirectToAction("List");

            //給他編輯頁面的View
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(CCafeMealWrap uiMeal)
        {
            //傳遞資料到View

            // 找出資料庫中要修改的原始資料
            CafeMeal dbMeal = _context.CafeMeals.FirstOrDefault(m => m.MealId == uiMeal.MealId);
            if (dbMeal == null)
                return RedirectToAction("List");

            // 檢查有沒有換照片，處理圖檔
            if (uiMeal.photo != null)
            {
                //  刪除舊照片 有舊照片刪掉
                if (!string.IsNullOrEmpty(dbMeal.ImageUrl))
                {
                    string oldPhotoPath = Path.Combine(_enviro.WebRootPath, "images", "Meal_Singlephoto", dbMeal.ImageUrl);
                    if (System.IO.File.Exists(oldPhotoPath))
                        System.IO.File.Delete(oldPhotoPath);  // ⭐ 刪除舊圖
                }

                //儲存新照片
                string ext = Path.GetExtension(uiMeal.photo.FileName);
                string fileName = Guid.NewGuid().ToString() + ext;
                dbMeal.ImageUrl = fileName; // 存新檔名

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

            // ✅ 更新資料庫欄位
            dbMeal.MealName = uiMeal.MealName;
            dbMeal.Description = uiMeal.Description;
            dbMeal.Price = uiMeal.Price;
            dbMeal.CafeId = uiMeal.CafeId;
            dbMeal.TypeId = uiMeal.TypeId;
            dbMeal.IsActive = uiMeal.IsActive;
            dbMeal.UpdatedAt = DateTime.Now;

            //存回資料庫
            _context.SaveChanges();

            //最後回到List Action看到原本的List_View
            return RedirectToAction("List");
        }
    }
}
