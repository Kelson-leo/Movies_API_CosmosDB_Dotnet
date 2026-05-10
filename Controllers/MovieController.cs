using MoviesAPI.Models;
using MoviesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private readonly MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]

    public async Task<IActionResult> AddMovie([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(ReadMovieById),
         new { id = movie.Id },
         movie);
    }

    [HttpGet]

    public async Task<IActionResult> ReadMovie([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var movies = await _context.Movies.Skip(skip).Take(take).ToListAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> ReadMovieById(string id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(string id, [FromBody] Movie movieAtualizado)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
        if (movie == null) return NotFound();

        movie.Title = movieAtualizado.Title;
        movie.Genre = movieAtualizado.Genre;
        movie.Duration = movieAtualizado.Duration;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(string id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
        if (movie == null) return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}