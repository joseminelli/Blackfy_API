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

            var query = new NpgsqlCommand("INSERT INTO Users (Id, Name, Email, Phone) VALUES (@id, @name, @email, @phone)", connection);

            int nextId = await GetNextId();
            Console.WriteLine(nextId);

            query.Parameters.AddWithValue("name", user.Name);
            query.Parameters.AddWithValue("id", nextId);
            query.Parameters.AddWithValue("email", user.Email);
            query.Parameters.AddWithValue("phone", user.Phone);

            var result = await query.ExecuteNonQueryAsync();

            return result > 0;
        }

        public async Task<int> GetNextId()
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            await using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var query = new NpgsqlCommand("SELECT COUNT(*) FROM Users", connection);

            var result = await query.ExecuteScalarAsync();

            int count = Convert.ToInt32(result) + 1;
            return count;
        }


        public async Task<bool> DeleteUserById(int id)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var query = new NpgsqlCommand("DELETE from Users WHERE id = @id", connection);
            query.Parameters.AddWithValue("id", id);

            var result = await query.ExecuteNonQueryAsync();

            return result > 0;
        }
        public async Task<bool> UpdateUser(User user, int id)
        {

            var connectionString = config.GetConnectionString("DefaultConnection");

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var query = new NpgsqlCommand("UPDATE Users SET Id = @id, Name = @name, Email = @email, Phone = @phone WHERE id = @id", connection);

            query.Parameters.AddWithValue("name", user.Name);
            query.Parameters.AddWithValue("email", user.Email);
            query.Parameters.AddWithValue("phone", user.Phone);
            query.Parameters.AddWithValue("id", id);

            var result = await query.ExecuteNonQueryAsync();

            return result > 0;
        }
    }
}