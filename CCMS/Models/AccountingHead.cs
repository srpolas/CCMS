namespace CCMS.Models
{
    public class AccountingHead
    {
        public int Id { get; set; }
        public int AccountingHeadId { get; set; }
        public string AccountingHeadName { get; set; } = string.Empty;
        public string HeadType { get; set; } = string.Empty;
        public string HeadCategory { get; set; } = string.Empty;        
        public string HeadDescription { get; set; } = string.Empty;
        public bool IsHeadActive { get; set; }

    }
}
