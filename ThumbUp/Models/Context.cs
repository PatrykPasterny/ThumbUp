using Microsoft.EntityFrameworkCore;

namespace ThumbUp.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Localization> Localizations { get; set; }
        public DbSet<LocalizationRating> LocalizationRatings { get; set; }
    }
}
