namespace prjCatCoffe.Models.Wrap
{
    public class CMemberWrap
    {
        private Member _member;

        public Member member
        {
            get { return _member; }
            set { _member = value; }
        }

        //創造紅框時 自動創造籃框
        public CMemberWrap()
        {
            _member = new Member();
        }

        public int MemberId
        {
            get { return _member.MemberId; }
            set { _member.MemberId = value; }
        }

        public string Name
        {
            get { return _member.Name; }
            set { _member.Name = value; }
        }

        public string Account
        {
            get { return _member.Account; }
            set { _member.Account = value; }
        }

        public string Password
        {
            get { return _member.Password; }
            set { _member.Password = value; }
        }

        public string Phone
        {
            get { return _member.Phone; }
            set { _member.Phone = value; }
        }

        public byte? Gender
        {
            get { return _member.Gender; }
            set { _member.Gender = value; }
        }

        public string Email
        {
            get { return _member.Email; }
            set { _member.Email = value; }
        }

        public string ImageUrl
        {
            get { return _member.ImageUrl; }
            set { _member.ImageUrl = value; }
        }

        public bool IsCaterer
        {
            get { return _member.IsCaterer; }
            set { _member.IsCaterer = value; }
        }

        public DateTime CreatedAt
        {
            get { return _member.CreatedAt; }
            set { _member.CreatedAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return _member.UpdatedAt; }
            set { _member.UpdatedAt = value; }
        }

        public bool Status
        {
            get { return _member.Status; }
            set { _member.Status = value; }
        }

        public IFormFile photo { get; set; }
    }
}