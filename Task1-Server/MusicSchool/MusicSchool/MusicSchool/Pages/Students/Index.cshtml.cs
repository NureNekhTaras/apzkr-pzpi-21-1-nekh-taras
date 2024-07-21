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

        public IList<Student> Students { get; private set; }

        public async Task OnGetAsync()
        {
            Students = (await _studentRepository.GetStudentsAsync()).ToList();
        }
    }
}
