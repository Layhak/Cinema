using Cinema.Mapping;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Repositories;
using Movie.Contracts.Requests;
using Movie.Contracts.Responses;

namespace Cinema.Controllers;

[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
    {
        var movie = request.MapToMovie();
        await _movieRepository.CreateAsync(movie);
        return Created($"/movies/{movie.Id}", movie);
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> GetMovieByGuid([FromRoute] string idOrSlug)
    {
        var movie = Guid.TryParse(idOrSlug, out var guid)
            ? await _movieRepository.GetByIdAsync(guid)
            : await _movieRepository.GetBySlugAsync(idOrSlug);

        if (movie == null)
            return NotFound();
        return Ok(movie.MapToMovieResponse());
    }

    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieRepository.GetAllAsync();
        if (!movies.Any())
            return NotFound();
        return Ok(movies.MapToMovieResponse());
    }

    [HttpPut(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
    {
        var movie = request.MapToMovie(id);
        var updated = await _movieRepository.UpdateAsync(movie);
        if (!updated) return NotFound(("Movie not found"));
        return Ok(movie.MapToMovieResponse());
    }

    [HttpDelete(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _movieRepository.DeleteAsync(id);
        if (!deleted) return NotFound(("Movie not found"));
        return Ok($"movie with id {id} was deleted.");
    }
}