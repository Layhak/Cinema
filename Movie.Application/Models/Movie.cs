using System.Text.RegularExpressions;

namespace Movie.Application.Models;

public partial class Movie
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public string Slug => GenerateSlug();

    private string GenerateSlug()
    {
        string sluggedTitle = SlugRegex().Replace(Title, "").ToLower().Replace(" ", "-");
        return $"{sluggedTitle}-{YearOfRelease}";
    }

    public required int YearOfRelease { get; set; }
    public required List<string> Genres { get; set; } = [];

    [GeneratedRegex(@"[^a-zA-Z0-9\s-]",RegexOptions.NonBacktracking,5)]
    private static partial Regex SlugRegex();
}