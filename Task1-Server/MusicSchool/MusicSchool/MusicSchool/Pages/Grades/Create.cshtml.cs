using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Grades
{
    public class CreateModel : PageModel
    {
        private readonly GradeRepository _gradeRepository;
        private readonly StudentRepository _studentRepository;
        private readonly SubjectRepository _subjectRepository;

        public CreateModel(GradeRepository gradeRepository, StudentRepository studentRepository, SubjectRepository subjectRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        [BindProperty]
        public Grade Grade { get; set; }
        public SelectList Students { get; set; }
        public SelectList Subjects { get; set; }

        public async Task OnGetAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();
            var subjects = await _subjectRepository.GetSubjectsAsync();

            Students = new SelectList(students, "StudentId", "StudentName", Grade?.StudentId ?? students.FirstOrDefault()?.StudentId ?? 0);
            Subjects = new SelectList(subjects, "SubjectId", "SubjectName", Grade?.SubjectId ?? subjects.FirstOrDefault()?.SubjectId ?? 0);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Grade.StudentId == 0 || Grade.SubjectId == 0)
            {
                var students = await _studentRepository.GetStudentsAsync();
                var subjects = await _subjectRepository.GetSubjectsAsync();

                Students = new SelectList(students, "StudentId", "StudentName", Grade?.StudentId ?? students.FirstOrDefault()?.StudentId ?? 0);
                Subjects = new SelectList(subjects, "SubjectId", "SubjectName", Grade?.SubjectId ?? subjects.FirstOrDefault()?.SubjectId ?? 0);

                return Page();
            }

            await _gradeRepository.AddGradeAsync(Grade);

            return RedirectToPage("Index");
        }
    }
}
