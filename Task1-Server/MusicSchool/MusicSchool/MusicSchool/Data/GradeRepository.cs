using Dapper;
using MusicSchool.Models;
using System.Data;

namespace MusicSchool.Data
{
    public class GradeRepository
    {
        private readonly IDbConnection _dbConnection;

        public GradeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync(int? studentId, int? subjectId, DateTime? date)
        {
            var sql = @"
                SELECT g.GradeId, g.StudentId, g.SubjectId, g.GradeValue, g.DateTime, 
                       s.StudentId, s.StudentName AS StudentName, 
                       sub.SubjectId, sub.SubjectName AS SubjectName
                FROM Grades g
                JOIN Students s ON g.StudentId = s.StudentId
                JOIN Subjects sub ON g.SubjectId = sub.SubjectId
                WHERE (@StudentId IS NULL OR g.StudentId = @StudentId)
                  AND (@SubjectId IS NULL OR g.SubjectId = @SubjectId)
                  AND (@Date IS NULL OR CONVERT(date, g.DateTime) = @Date)";

            return await _dbConnection.QueryAsync<Grade, Student, Subject, Grade>(
                sql,
                (grade, student, subject) =>
                {
                    grade.Student = student;
                    grade.Subject = subject;
                    return grade;
                },
                new { StudentId = studentId, SubjectId = subjectId, Date = date },
                splitOn: "StudentId,SubjectId");
        }

        public async Task<IEnumerable<StudentStatistic>> GetStudentStatisticsAsync(int? studentId, int? subjectId, DateTime? startDate, DateTime? endDate)
        {
            var sql = @"
                SELECT s.StudentId, s.StudentName AS StudentName, 
                       sub.SubjectId, sub.SubjectName AS SubjectName,
                       AVG(g.GradeValue) AS AverageGrade
                FROM Grades g
                JOIN Students s ON g.StudentId = s.StudentId
                JOIN Subjects sub ON g.SubjectId = sub.SubjectId
                WHERE (@StudentId IS NULL OR g.StudentId = @StudentId)
                  AND (@SubjectId IS NULL OR g.SubjectId = @SubjectId)
                  AND (@StartDate IS NULL OR g.DateTime >= @StartDate)
                  AND (@EndDate IS NULL OR g.DateTime <= @EndDate)
                GROUP BY s.StudentId, s.StudentName, sub.SubjectId, sub.SubjectName";

            return await _dbConnection.QueryAsync<StudentStatistic>(
                sql,
                new { StudentId = studentId, SubjectId = subjectId, StartDate = startDate, EndDate = endDate });
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            var sql = @"
                SELECT g.GradeId, g.StudentId, g.SubjectId, g.GradeValue, g.DateTime, 
                       s.StudentId, s.StudentName AS StudentName, 
                       sub.SubjectId, sub.SubjectName AS SubjectName
                FROM Grades g
                JOIN Students s ON g.StudentId = s.StudentId
                JOIN Subjects sub ON g.SubjectId = sub.SubjectId";
            return await Task.Run(() => _dbConnection.Query<Grade, Student, Subject, Grade>(sql,
                (grade, student, subject) =>
                {
                    grade.Student = student;
                    grade.Subject = subject;
                    return grade;
                },
                splitOn: "StudentId,SubjectId"));
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            var sql = @"
                SELECT g.GradeId, g.StudentId, g.SubjectId, g.GradeValue, g.DateTime, 
                       s.StudentName AS StudentName, sub.SubjectName AS SubjectName
                FROM Grades g
                JOIN Students s ON g.StudentId = s.StudentId
                JOIN Subjects sub ON g.SubjectId = sub.SubjectId
                WHERE g.GradeId = @Id";
            var result = await Task.Run(() => _dbConnection.Query<Grade, Student, Subject, Grade>(sql,
                (grade, student, subject) =>
                {
                    grade.Student = student;
                    grade.Subject = subject;
                    return grade;
                },
                new { Id = id },
                splitOn: "StudentId,SubjectId").SingleOrDefault());

            if (result?.Subject != null)
            {
                result.SubjectId = result.Subject.SubjectId;
            }
            if (result?.Student != null)
            {
                result.StudentId = result.Student.StudentId;
            }
            return result;
        }

        public async Task AddGradeAsync(Grade grade)
        {
            var sql = "INSERT INTO Grades (StudentId, SubjectId, GradeValue, DateTime) VALUES (@StudentId, @SubjectId, @GradeValue, @DateTime)";
            await Task.Run(() => _dbConnection.Execute(sql, grade));
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            var sql = "UPDATE Grades SET StudentId = @StudentId, SubjectId = @SubjectId, GradeValue = @GradeValue, DateTime = @DateTime WHERE GradeId = @GradeId";
            await Task.Run(() => _dbConnection.Execute(sql, grade));
        }

        public async Task DeleteGradeAsync(int id)
        {
            var sql = "DELETE FROM Grades WHERE GradeId = @Id";
            await Task.Run(() => _dbConnection.Execute(sql, new { Id = id }));
        }
    }
}
