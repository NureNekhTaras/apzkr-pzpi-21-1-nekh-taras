using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentRepository _studentRepository;

        public CreateModel(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Student.StudentName == null || Student.Class == null)
            {
                return Page();
            }

            await _studentRepository.AddStudentAsync(Student);

            return RedirectToPage("Index");
        }
    }
}
