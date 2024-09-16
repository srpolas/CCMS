namespace CCMS.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public string TransactionDate { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string TransactionCategory { get; set; } = string.Empty;
        public int AccountingHeadId { get; set; }
        public string IncomeFrom { get; set; } = string.Empty;
        public int StudentId { get; set; } 
        public string ExpenseFor { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public string TransactionDescription { get; set; } = string.Empty;
        public decimal TransactionAmount { get; set; }
        public string TransactionStatus { get; set; } = string.Empty;
        public string EntryBy { get; set; } = string.Empty;
    }
}
