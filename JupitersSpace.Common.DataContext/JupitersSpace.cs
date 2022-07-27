using Microsoft.EntityFrameworkCore; //DbContext, DbContextOptionsBuilder

namespace JupitersSpace.Shared;
public class JupitersSpace : DbContext
{


    // maps to tables in the database
    public DbSet<Post>? Posts { get; set; }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        string path = Path.Combine(
            Environment.CurrentDirectory, "JupitersSpace.db");
        
        optionsBuilder.UseSqlite(path);
    }
}
