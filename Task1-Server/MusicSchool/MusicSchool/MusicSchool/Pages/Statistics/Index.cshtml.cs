using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchool.Data;
using MusicSchool.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicSchool.Pages.Statistics
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
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        public SelectList Students { get; set; }
        public SelectList Subjects { get; set; }
        public IEnumerable<StudentStatistic> Statistics { get; set; }

        public async Task OnGetAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();
            var subjects = await _subjectRepository.GetSubjectsAsync();

            Students = new SelectList(students, "StudentId", "StudentName");
            Subjects = new SelectList(subjects, "SubjectId", "SubjectName");

            Statistics = await _gradeRepository.GetStudentStatisticsAsync(StudentId, SubjectId, StartDate, EndDate);
        }
    }
}
