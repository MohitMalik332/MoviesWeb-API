using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Models;
using MoviesWebAPI.Service;

namespace MoviesWebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _movieService;

        public MoviesController(MoviesService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<Movies>> GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }
    }
}
