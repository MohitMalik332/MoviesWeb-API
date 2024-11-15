using MoviesWebAPI.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MoviesWebAPI.Repository
{
    public class MoviesRepository
    {
        private readonly string _connectionString;

        public MoviesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Movies> GetAllMovies()
        {
            var movies = new List<Movies>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("getAllMovies", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fetched: {reader["act_id"]}, {reader["act_fname"]}, {reader["act_lname"]}, {reader["act_gender"]}");
                            movies.Add(new Movies
                            {
                                act_id = reader["act_id"] != DBNull.Value ? (int)reader["act_id"] : 0,
                                act_fname = reader["act_fname"] as string ?? string.Empty,
                                act_lname = reader["act_lname"] as string ?? string.Empty,
                                act_gender = reader["act_gender"] as string ?? string.Empty
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with actual logging)
                Console.WriteLine($"Error: {ex.Message}");
            }

            return movies;
        }
    }
}
