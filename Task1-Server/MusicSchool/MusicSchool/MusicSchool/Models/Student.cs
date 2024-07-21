using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Class is required.")]
        public string Class { get; set; }
    }
}
