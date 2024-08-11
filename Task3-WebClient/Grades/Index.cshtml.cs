using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly GradeRepository _gradeRepository;
        private readonly StudentRepository _studentRepository;
        private readonly SubjectRepository _subjectRepository;

        public IndexModel(GradeRepository gradeRepository, StudentRepository studentRepository, SubjectRepository subjectRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        [BindProperty(SupportsGet = true)]
        public int? StudentId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SubjectId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? Date { get; set; }

        public SelectList Students { get; set; }
        public SelectList Subjects { get; set; }
        public IEnumerable<Grade> Grades { get; set; }

        public async Task OnGetAsync()
        {
            Students = new SelectList(await _studentRepository.GetStudentsAsync(), "StudentId", "StudentName");
            Subjects = new SelectList(await _subjectRepository.GetSubjectsAsync(), "SubjectId", "SubjectName");

            Grades = await _gradeRepository.GetGradesAsync(StudentId, SubjectId, Date);
        }
    }
}
