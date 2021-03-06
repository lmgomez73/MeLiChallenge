using MeLiChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Configuration;

namespace MeliChallenge.Data
{
    public class MeliDbContext : DbContext
    {
        public MeliDbContext(DbContextOptions<MeliDbContext> options) : base(options)
        { 
        }
        public MeliDbContext()
        {

        }
        public DbSet<Satellite> Satellites { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageItem> MessageItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed for given data

            modelBuilder.Entity<Satellite>().HasData(
                new Satellite { IdSatelite = 1, Name = "Kenobi", PositionX = -500, PositionY = -200 },
                new Satellite { IdSatelite = 2, Name = "Skywalker", PositionX = 100, PositionY = -100 },
                new Satellite { IdSatelite = 3, Name = "Sato", PositionX = 500, PositionY = 100 }

                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("User ID=meliuser;Password=melipassword;Host=host.docker.internal;Port=5432;Database=melidb;");
            }
        }
    }
}
