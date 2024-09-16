namespace CCMS.Models
{
    public class HeadCategory
    {
        public int Id { get; set; }
        public int HeadCategoryId { get; set; }
        public string HeadCategoryName { get; set; } = string.Empty;
        public string HeadCategoryDescription { get; set; } = string.Empty;
        public bool IsHeadCategoryActive { get; set; }


    }
}
