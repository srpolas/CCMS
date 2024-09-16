namespace CCMS.Models
{
	public class AddStudentViewModel
	{
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public Boolean Subscribed { get; set; }
	}
}
