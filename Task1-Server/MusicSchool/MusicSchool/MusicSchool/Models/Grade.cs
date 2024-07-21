using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public decimal GradeValue { get; set; }

        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
