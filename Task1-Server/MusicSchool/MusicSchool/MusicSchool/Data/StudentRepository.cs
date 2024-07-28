using Dapper;
using MusicSchool.Models;
using System.Data;

namespace MusicSchool.Data
{
    public class StudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var sql = "SELECT * FROM Students";
            return await _dbConnection.QueryAsync<Student>(sql);
        }

        public async Task<IEnumerable<Student>> GetStudentsBySearchTextAsync(string searchText)
        {
            var sql = "SELECT StudentId, StudentName, Class FROM Students WHERE StudentName LIKE @SearchText OR Class LIKE @SearchText";
            return await _dbConnection.QueryAsync<Student>(sql, new { SearchText = $"%{searchText}%" });
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var sql = "SELECT * FROM Students WHERE StudentId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Student>(sql, new { Id = id });
        }

        public async Task AddStudentAsync(Student student)
        {
            var sql = "INSERT INTO Students (StudentName, Class) VALUES (@StudentName, @Class)";
            await _dbConnection.ExecuteAsync(sql, student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            var sql = "UPDATE Students SET StudentName = @StudentName, Class = @Class WHERE StudentId = @StudentId";
            await _dbConnection.ExecuteAsync(sql, student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var sql = "DELETE FROM Students WHERE StudentId = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
