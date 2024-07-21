using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly SubjectRepository _subjectRepository;

        public CreateModel(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Subject.SubjectName is null | Subject.Description is null)
            {
                return Page();
            }

            await _subjectRepository.AddSubjectAsync(Subject);

            return RedirectToPage("Index");
        }
    }
}
