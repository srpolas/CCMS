namespace CCMS.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public bool SubjectStatus { get; set; }
        public string ClassCode { get; set; } = string.Empty;
        public string TeacherCode { get; set; } = string.Empty;

    }
}
