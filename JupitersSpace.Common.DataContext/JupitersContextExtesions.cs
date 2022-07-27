using Microsoft.EntityFrameworkCore; //UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace JupitersSpace.Shared;

public static class JupitersContextExtensions
{
    public static IServiceCollection AddJupitersContext(
        this IServiceCollection services, string relativePath = ".."
    ){
        string databasePath = Path.Combine(relativePath, "JupitersStuff.db");

        services.AddDbContext<JupitersContext>(options => options.UseSqlite($"Data Source={databasePath}"));

        return services;
    }
}
