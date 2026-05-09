using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();

    [HttpPost]

    public void AddMovie([FromBody] Movie movie)
    {
        movies.Add(movie);
        Console.WriteLine(movie.Title);
        Console.WriteLine(movie.Duration);
        Console.WriteLine(movie.Genre);
    }

}