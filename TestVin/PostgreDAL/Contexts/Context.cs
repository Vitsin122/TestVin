using Microsoft.EntityFrameworkCore;
using PostgreDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDAL.Contexts
{
    public class Context : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) { };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(e =>
                {
                    e.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);


                    e.Property(x => x.Priority)
                    .HasConversion<string>()
                    .HasMaxLength(16);
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
