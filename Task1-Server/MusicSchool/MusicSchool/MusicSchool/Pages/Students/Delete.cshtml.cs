using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly StudentRepository _studentRepository;

        public DeleteModel(StudentRepository studentRepository)
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
            if (Student == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudentAsync(Student.StudentId);

            return RedirectToPage("Index");
        }
    }
}
