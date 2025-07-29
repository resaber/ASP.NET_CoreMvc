using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;
using prjCatCoffe.Models.Wrap;
using prjCatCoffe.ViewModels;

namespace prjCatCoffe.Controllers
{
    public class MemberController : Controller
    {
        private readonly CatCafeDbContext _context;
        private readonly IWebHostEnvironment _enviro;

        public MemberController(CatCafeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviro = env;
        }

        public IActionResult List(CkeyWordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            //TCustomer
            IEnumerable<Member> datas = null;
            //LINQ ENtityFramework

            if (string.IsNullOrEmpty(keyword))
                //Factory 代表是TCustomer 資料表+s
                datas = from p in _context.Members
                        select p;
            else
                datas = _context.Members.Where(m => m.Name.Contains(keyword));

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
        public IActionResult Create(CMemberWrap uiMember)
        {
            if (uiMember.photo != null)
            {
                string ext = Path.GetExtension(uiMember.photo.FileName); // 取得副檔名
                string photoName = Guid.NewGuid().ToString() + ext; // 產生唯一檔名

                uiMember.ImageUrl = photoName; // 將檔名設定回 Member 的欄位
                string savePath = Path.Combine(_enviro.WebRootPath, "images", "member_photos", photoName);
                using var fileStream = new FileStream(savePath, FileMode.Create);
                uiMember.photo.CopyTo(fileStream);
            }
            // ⭐ 將 uiMember 轉成 Member，存入資料庫
            _context.Members.Add(new Member
            {
                Name = uiMember.Name,
                Account = uiMember.Account,
                Password = uiMember.Password,
                Phone = uiMember.Phone,
                Gender = uiMember.Gender ?? 0, // 沒填預設為0（男生）
                Email = uiMember.Email,
                IsCaterer = uiMember.IsCaterer,
                ImageUrl = uiMember.ImageUrl,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = uiMember.Status
            });

            //儲存回資料庫
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");
            CatCafeDbContext db = new CatCafeDbContext();
            Member x = db.Members.FirstOrDefault(m => m.MemberId == id);
            if (x == null)
                return RedirectToAction("List");
            //最後移除他 並儲存 回列表
            db.Members.Remove(x);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            //傳遞資料到View
            if (id == null)
                return RedirectToAction("List");
            CatCafeDbContext db = new CatCafeDbContext();
            Member x = db.Members.FirstOrDefault(m => m.MemberId == id);
            if (x == null)
                return RedirectToAction("List");

            //給他編輯頁面的View
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(CMemberWrap uiMember)
        {
            //傳遞資料到View

            CatCafeDbContext db = new CatCafeDbContext();
            Member dbMember = db.Members.FirstOrDefault(m => m.MemberId == uiMember.MemberId);
            if (dbMember == null)
                return RedirectToAction("List");

            //處理上傳照片格式
            if (uiMember.photo != null)
            {
                // 拿到
                string ext = Path.GetExtension(uiMember.photo.FileName);
                string photoName = Guid.NewGuid().ToString() + ext;
                dbMember.ImageUrl = photoName;
                uiMember.photo.CopyTo(new FileStream(_enviro.WebRootPath + "/images/member_photos/" + photoName, FileMode.Create));
            }

            dbMember.Name = uiMember.Name;
            dbMember.Account = uiMember.Account;
            dbMember.Password = uiMember.Password;
            dbMember.Phone = uiMember.Phone;
            dbMember.Gender = uiMember.Gender;
            dbMember.Email = uiMember.Email;
            // ⭐ 加上這一行：更新時間
            dbMember.UpdatedAt = DateTime.Now;

            // ⭐ 重點：Checkbox 值（會是 true/false）
            dbMember.Status = uiMember.Status;
            dbMember.IsCaterer = uiMember.IsCaterer;

            //存回資料庫
            db.SaveChanges();

            //最後回到List Action看到原本的List_View
            return RedirectToAction("List");
        }
    }
}