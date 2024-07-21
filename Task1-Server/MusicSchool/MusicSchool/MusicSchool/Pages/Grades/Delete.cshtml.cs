using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;
using System.Threading.Tasks;

namespace MusicSchool.Pages.Grades
{
    public class DeleteModel : PageModel
    {
        private readonly GradeRepository _gradeRepository;

        public DeleteModel(GradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [BindProperty]
        public Grade Grade { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (Grade == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (grade != null)
            {
                await _gradeRepository.DeleteGradeAsync(id);
            }

            return RedirectToPage("Index");
        }
    }
}
