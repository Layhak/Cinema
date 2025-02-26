namespace Movie.Contracts.Requests;

public class UpdateMovieRequest
{
    public required string Title { get; set; }
    public required int YearOfRelease { get; set; }
    public required IEnumerable<string> Genres { get; set; } = [];
}