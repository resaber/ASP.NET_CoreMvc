using Microsoft.AspNetCore.Mvc;
using prjCatCoffe.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjCatCoffe.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly CatCafeDbContext _context;

        public MemberApiController(CatCafeDbContext context)
        {
            _context = context;
        }

        // GET: api/<MemberApiController>
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Members
            //check true 業者 false會員
            .Select(m => m.IsCaterer == true ? "業者" : "會員")
            .Distinct()
            .ToList();

            // 加一個「全部」，插入到最前面
            roles.Insert(0, "全部");

            return Ok(roles);
        }

        [HttpGet]
        public IActionResult GetMembersByRole(string role)
        {
            //  若沒傳或傳入「全部」，回傳所有人
            if (string.IsNullOrEmpty(role) || role == "全部")
            {
                return Ok(_context.Members.ToList());
            }
            //依照 會員 還是業者 讀取資料
            var members = _context.Members
                .Where(m => (role == "會員" && !m.IsCaterer) || (role == "業者" && m.IsCaterer))
                .ToList();

            return Ok(members); // 會自動轉成 JSON
        }

        [HttpGet]
        public IActionResult SearchMembers(string keyword)
        {
            var result = _context.Members
                .Where(m => m.Name.Contains(keyword)) // 篩選名字中有 keyword 的人
                .Select(m => new
                {
                    m.MemberId,
                    m.Name,
                    m.ImageUrl,
                    m.Account,
                    m.Phone,
                    m.Gender,
                    m.Email,
                    m.IsCaterer,
                    m.CreatedAt,
                    m.UpdatedAt,
                    m.Status
                })
                .ToList();

            return Ok(result); // 回傳 JSON 格式資料
        }

        // POST api/<MemberApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MemberApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}