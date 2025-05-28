using Npgsql;
using blackfy_API.Models;
using Dapper;

namespace blackfy_API.Services
{
    public class UserService 
    {
        private readonly IConfiguration config;

        public UserService(IConfiguration configuration)
        {
            config = configuration;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            var connection = new NpgsqlConnection(connectionString);

            var users = await connection.QueryAsync<User>("SELECT Id, Name, Email, Phone FROM Users");
            return users;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var query = new NpgsqlCommand("INSERT INTO Users (Name, Email, Phone) VALUES (@name, @email, @phone)", connection);

            query.Parameters.AddWithValue("name", user.Name);
            query.Parameters.AddWithValue("email", user.Email);
            query.Parameters.AddWithValue("phone", user.Phone);

            var result = await query.ExecuteNonQueryAsync();

            return result > 0;
        }
    }
}