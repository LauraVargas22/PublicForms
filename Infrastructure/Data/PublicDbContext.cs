using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PublicDbContext : DbContext
    {
        public PublicDbContext(DbContextOptions<PublicDbContext> options) : base(options)
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
        public DbSet<Member> Members { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<MemberRols> MemberRols { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}