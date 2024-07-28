using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly SubjectRepository _subjectRepository;

        public IndexModel(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SubjectName { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrWhiteSpace(SubjectName))
            {
                Subjects = await _subjectRepository.GetSubjectsByNameAsync(SubjectName);
            }
            else
            {
                Subjects = await _subjectRepository.GetSubjectsAsync();
            }
        }
    }
}
