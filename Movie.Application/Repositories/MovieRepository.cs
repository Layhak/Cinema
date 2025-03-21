namespace Movie.Application.Repositories;

using Models;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = [];

    public Task<bool> CreateAsync(Movie movie)
    {
        _movies.Add(movie);
        return Task.FromResult(true);
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = _movies.SingleOrDefault(movie => movie.Id == id);
        return Task.FromResult(movie);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = _movies.SingleOrDefault(movie => movie.Slug == slug);
        return Task.FromResult(movie);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_movies.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        var movieIndex = _movies.FindIndex(movie => movie.Id == movie.Id);
        if (movieIndex == -1)
        {
            return Task.FromResult(false);
        }
        _movies[movieIndex] = movie;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removedCount = _movies.RemoveAll(movie => movie.Id == id);
        var movieRemoved = removedCount > 0;
        return Task.FromResult(movieRemoved);
    }
}