using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentRepository _studentRepository;

        public IndexModel(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                Students = await _studentRepository.GetStudentsBySearchTextAsync(SearchText);
            }
            else
            {
                Students = await _studentRepository.GetStudentsAsync();
            }
        }
    }
}
