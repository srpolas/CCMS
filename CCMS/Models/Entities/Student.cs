namespace CCMS.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Boolean Subscribed { get; set; }



    }
}
