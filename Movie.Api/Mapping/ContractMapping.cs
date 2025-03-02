using Movie.Contracts.Requests;
using Movie.Contracts.Responses;

namespace Cinema.Mapping;

public static class ContractMapping
{
    public static Movie.Application.Models.Movie MapToMovie(this CreateMovieRequest request)
    {
        return new Movie.Application.Models.Movie()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            Genres = request.Genres.ToList()
        };
    }

    public static MovieResponse MapToMovieResponse(this Movie.Application.Models.Movie movie)
    {
        return new MovieResponse()
        {
            Id = movie.Id,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
            Genres = movie.Genres.ToList()
        };
    }

    public static MoviesResponse MapToMovieResponse(this IEnumerable<Movie.Application.Models.Movie > movies)
    {
        return new MoviesResponse()
        {
            Items = movies.Select(MapToMovieResponse)
        };
    }

}