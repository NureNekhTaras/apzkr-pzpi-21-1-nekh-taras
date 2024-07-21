using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly StudentRepository _studentRepository;

        public EditModel(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _studentRepository.GetStudentByIdAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Student.StudentName == null || Student.Class == null)
            {
                return Page();
            }

            await _studentRepository.UpdateStudentAsync(Student);

            return RedirectToPage("Index");
        }
    }
}
