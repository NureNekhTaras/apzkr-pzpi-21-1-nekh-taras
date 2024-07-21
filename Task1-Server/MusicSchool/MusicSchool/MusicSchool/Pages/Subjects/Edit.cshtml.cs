using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly SubjectRepository _subjectRepository;

        public EditModel(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _subjectRepository.GetSubjectByIdAsync(id);

            if (Subject == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Subject.SubjectName is null | Subject.Description is null)
            {
                return Page();
            }

            await _subjectRepository.UpdateSubjectAsync(Subject);

            return RedirectToPage("Index");
        }
    }
}
