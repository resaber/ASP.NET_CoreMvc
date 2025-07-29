using System.ComponentModel;

namespace prjCatCoffe.Models.Wrap
{
    public class CCafeMealWrap
    {
        private CafeMeal _meal;

        public CafeMeal meal
        {
            get { return _meal; }
            set { _meal = value; }
        }

        public CCafeMealWrap()
        {
            _meal = new CafeMeal();
        }

        public int MealId
        {
            get { return _meal.MealId; }
            set { _meal.MealId = value; }
        }

        public int CafeId
        {
            get { return _meal.CafeId; }
            set { _meal.CafeId = value; }
        }

        public int TypeId
        {
            get { return _meal.TypeId; }
            set { _meal.TypeId = value; }
        }

        public string MealName
        {
            get { return _meal.MealName; }
            set { _meal.MealName = value; }
        }

        public int Price
        {
            get { return _meal.Price; }
            set { _meal.Price = value; }
        }

        public string Description
        {
            get { return _meal.Description; }
            set { _meal.Description = value; }
        }

        public string? ImageUrl
        {
            get { return _meal.ImageUrl; }
            set { _meal.ImageUrl = value; }
        }

        public bool IsActive
        {
            get { return _meal.IsActive; }
            set { _meal.IsActive = value; }
        }

        public DateTime CreatedAt
        {
            get { return _meal.CreatedAt; }
            set { _meal.CreatedAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return _meal.UpdatedAt; }
            set { _meal.UpdatedAt = value; }
        }

        // ✅ 上傳圖片用欄位
        [DisplayName("餐點封面照上傳")]
        public IFormFile? photo { get; set; }
    }
}