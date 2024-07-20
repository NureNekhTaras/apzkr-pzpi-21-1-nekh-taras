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

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            var sql = "SELECT g.*, s.Name AS SubjectName, s.Description AS SubjectDescription FROM Grades g INNER JOIN Subjects s ON g.SubjectId = s.SubjectId";
            return await _dbConnection.QueryAsync<Grade, Subject, Grade>(sql, (grade, subject) =>
            {
                grade.Subject = subject;
                return grade;
            });
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            var sql = "SELECT * FROM Grades WHERE GradeId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Grade>(sql, new { Id = id });
        }

        public async Task AddGradeAsync(Grade grade)
        {
            var sql = "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (@StudentId, @SubjectId, @GradeValue)";
            await _dbConnection.ExecuteAsync(sql, grade);
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            var sql = "UPDATE Grades SET StudentId = @StudentId, SubjectId = @SubjectId, Grade = @GradeValue WHERE GradeId = @GradeId";
            await _dbConnection.ExecuteAsync(sql, grade);
        }

        public async Task DeleteGradeAsync(int id)
        {
            var sql = "DELETE FROM Grades WHERE GradeId = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
