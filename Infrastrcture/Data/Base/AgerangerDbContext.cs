using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entity;

namespace Data.Base
{
    public partial class AgeRangerDbContext : DbContext
    {
        public virtual DbSet<AgeGroup> AgeGroup { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source=AgeRanger.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeGroup>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();
            });
        }
    }
}