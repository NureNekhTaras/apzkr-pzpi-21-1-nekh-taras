using Dapper;
using MusicSchool.Models;
using System.Data;

namespace MusicSchool.Data
{
    public class UserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var sql = "SELECT * FROM Users";
            return await _dbConnection.QueryAsync<User>(sql);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var sql = "SELECT * FROM Users WHERE UserId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var sql = "SELECT * FROM Users WHERE Login = @Login";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sql, new { Login = login });
        }

        public async Task AddUserAsync(User user)
        {
            // Hash the password before saving to the database
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var sql = "INSERT INTO Users (Login, Password) VALUES (@Login, @Password)";
            await _dbConnection.ExecuteAsync(sql, user);
        }

        public async Task UpdateUserAsync(User user)
        {
            // Hash the password before updating in the database
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var sql = "UPDATE Users SET Login = @Login, Password = @Password WHERE UserId = @UserId";
            await _dbConnection.ExecuteAsync(sql, user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM Users WHERE UserId = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<User> AuthenticateAsync(string login, string password)
        {
            var user = await GetUserByLoginAsync(login);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }
    }
}
