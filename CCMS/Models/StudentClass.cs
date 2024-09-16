namespace CCMS.Models
{
	public class StudentClass
	{
		public int Id { get; set; }
		public string ClassCode { get; set; } = string.Empty;
		public string ClassName { get; set; } = string.Empty;
		public bool ClassStatus { get; set; }

	}
}
