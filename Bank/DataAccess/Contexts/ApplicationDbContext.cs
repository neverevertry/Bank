using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Option> Options { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<OptionDescription> optionDescriptions { get; set; }
    }
}
