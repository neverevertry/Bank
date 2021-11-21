using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Option> Options { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<OptionDescription> optionDescriptions { get; set; }
    }
}
