namespace Movie.Contracts.Responses;

public class MoviesResponse
{
    public required IEnumerable<MovieResponse> Items { get; set; } = [];
}