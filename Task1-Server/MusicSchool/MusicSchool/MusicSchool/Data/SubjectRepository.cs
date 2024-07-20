using Dapper;
using MusicSchool.Models;
using System.Data;

namespace MusicSchool.Data
{
    public class SubjectRepository
    {
        private readonly IDbConnection _dbConnection;

        public SubjectRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            var sql = "SELECT * FROM Subjects";
            return await _dbConnection.QueryAsync<Subject>(sql);
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            var sql = "SELECT * FROM Subjects WHERE SubjectId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Subject>(sql, new { Id = id });
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            var sql = "INSERT INTO Subjects (Name, Description) VALUES (@Name, @Description)";
            await _dbConnection.ExecuteAsync(sql, subject);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            var sql = "UPDATE Subjects SET Name = @Name, Description = @Description WHERE SubjectId = @SubjectId";
            await _dbConnection.ExecuteAsync(sql, subject);
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var sql = "DELETE FROM Subjects WHERE SubjectId = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
