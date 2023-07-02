using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Technical_Challenge.Models;

namespace Technical_Challenge.Databases
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().Property(u => u.IsBookmark).HasDefaultValue(false);
            modelBuilder.Entity<University>().Property(u => u.Webpages).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
        }

        public DbSet<University> Universities { get; set; }
    }
}
