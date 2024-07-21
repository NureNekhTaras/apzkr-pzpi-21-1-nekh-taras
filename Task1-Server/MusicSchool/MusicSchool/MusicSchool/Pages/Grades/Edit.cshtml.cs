using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Grades
{
    public class EditModel : PageModel
    {
        private readonly GradeRepository _gradeRepository;
        private readonly StudentRepository _studentRepository;
        private readonly SubjectRepository _subjectRepository;

        public EditModel(GradeRepository gradeRepository, StudentRepository studentRepository, SubjectRepository subjectRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        [BindProperty]
        public Grade Grade { get; set; }
        public SelectList Students { get; set; }
        public SelectList Subjects { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (Grade == null)
            {
                return NotFound();
            }

            var students = await _studentRepository.GetStudentsAsync();
            var subjects = await _subjectRepository.GetSubjectsAsync();

            Students = new SelectList(students, "StudentId", "StudentName", Grade.StudentId);
            Subjects = new SelectList(subjects, "SubjectId", "SubjectName", Grade.SubjectId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Grade.StudentId == 0 || Grade.SubjectId == 0)
            {
                var students = await _studentRepository.GetStudentsAsync();
                var subjects = await _subjectRepository.GetSubjectsAsync();

                Students = new SelectList(students, "StudentId", "StudentName", Grade.StudentId);
                Subjects = new SelectList(subjects, "SubjectId", "SubjectName", Grade.SubjectId);

                return Page();
            }

            await _gradeRepository.UpdateGradeAsync(Grade);

            return RedirectToPage("Index");
        }
    }
}
