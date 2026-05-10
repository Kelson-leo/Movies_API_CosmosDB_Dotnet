using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The movie title is required")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "The movie genre is required")]
    [MaxLength(50, ErrorMessage = "The genre length cannot exceed 50 characters")]
    public required string Genre { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}