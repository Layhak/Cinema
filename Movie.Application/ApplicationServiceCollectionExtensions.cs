using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Repositories;

namespace Movie.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        return services;
    }
}