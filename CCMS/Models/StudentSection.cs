using CCMS.Models.Entities;

namespace CCMS.Models
{
	public class StudentSection
	{
		public int Id { get; set; }
		public int SectionId { get; set; }
		public string SectionName { get; set; } = string.Empty;
		public string ClassCode { get; set; } = string.Empty;
		public string SectionShift { get; set; } = string.Empty;
		public string TeacherId { get; set; } = string.Empty;
		public Boolean SectionStatus { get; set; } = false;

		
	}
}
