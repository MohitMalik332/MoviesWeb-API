using MoviesWebAPI.Models;
using MoviesWebAPI.Repository;

namespace MoviesWebAPI.Service
{
    public class MoviesService
    {
        private readonly MoviesRepository _repository;

        public MoviesService(MoviesRepository repository)
        {
            _repository = repository;
        }

        public List<Movies> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }
    }
}
