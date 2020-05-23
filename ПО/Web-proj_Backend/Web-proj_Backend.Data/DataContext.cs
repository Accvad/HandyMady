using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasIndex(u => u.Login).IsUnique();
        }
    }
}
