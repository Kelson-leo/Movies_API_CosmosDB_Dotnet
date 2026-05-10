using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 0;

    [HttpPost]

    public IActionResult AddMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        movies.Add(movie);
        /*Console.WriteLine(movie.Title);
        Console.WriteLine(movie.Duration);
        Console.WriteLine(movie.Genre);*/
        return CreatedAtAction(nameof(ReadMovieById),
         new { id = movie.Id },
         movie);
    }

    [HttpGet]

    public IEnumerable<Movie> ReadMovie([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]

    public IActionResult? ReadMovieById(int id)
    {
        var movie = movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
}