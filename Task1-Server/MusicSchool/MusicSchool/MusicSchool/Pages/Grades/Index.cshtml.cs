using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly GradeRepository _gradeRepository;

        public IndexModel(GradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public IList<Grade> Grades { get; private set; }

        public async Task OnGetAsync()
        {
            // Get all grades, including related students and subjects
            var grades = await _gradeRepository.GetGradesAsync();
            Grades = grades.ToList();
        }
    }
}
