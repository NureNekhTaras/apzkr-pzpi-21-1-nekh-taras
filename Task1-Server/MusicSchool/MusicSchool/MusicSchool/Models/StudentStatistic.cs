namespace MusicSchool.Models
{
    public class StudentStatistic
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal AverageGrade { get; set; }
    }
}
