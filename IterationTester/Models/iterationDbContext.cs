using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IterationTester.Models
{
    public class iterationDbContext : DbContext
    {
        public DbSet<IterationResult> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IterationTester;Trusted_Connection=True;");
        }
    }
}
