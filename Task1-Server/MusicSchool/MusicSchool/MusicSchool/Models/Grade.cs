namespace MusicSchool.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal GradeValue { get; set; }

        public Subject Subject { get; set; }
    }
}
