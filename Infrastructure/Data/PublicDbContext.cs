using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class PublicDbContext : DbContext
    {
        public PublicDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CategoriesCatalog> CategoriesCatalog { get; set; }
        public DbSet<CategoryOptions> CategoryOptions { get; set; }
        public DbSet<OptionQuestions> OptionQuestions { get; set; }
        public DbSet<OptionsResponse> OptionsResponse { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Surveys> Surveys { get; set; }
        public DbSet<SumaryOptions> SumaryOptions { get; set; }
        public DbSet<SubQuestions> SubQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}