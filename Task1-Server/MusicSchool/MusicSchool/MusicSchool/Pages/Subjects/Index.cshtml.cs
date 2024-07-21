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

        public IList<Subject> Subjects { get; private set; }

        public async Task OnGetAsync()
        {
            Subjects = (await _subjectRepository.GetSubjectsAsync()).ToList();
        }
    }
}
