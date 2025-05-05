using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameProjects.Model;

namespace GameProjects.Data
{
    public class GameProjectsContext : DbContext
    {
        public GameProjectsContext (DbContextOptions<GameProjectsContext> options)
            : base(options)
        {
        }

        public DbSet<GameProjects.Model.Contribution> Contribution { get; set; } = default!;
        public DbSet<GameProjects.Model.Developer> Developer { get; set; } = default!;
        public DbSet<GameProjects.Model.Game> Game { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the Contributions table

            modelBuilder.Entity<Contribution>().HasData(
                new Contribution { Id = 1, DeveloperId = 1, GameId = 4, ContributionType = "Design", 
                    ContributionDescription = "Design Doc", ContributionDate = "7/17/2024"},
                new Contribution { Id = 2, DeveloperId = 2, GameId = 4, ContributionType = "Art",
                    ContributionDescription = "Title Logo", ContributionDate = "7/17/2024"},
                new Contribution { Id = 3, DeveloperId = 1, GameId = 4, ContributionType = "Music",
                    ContributionDescription = "Menu Theme", ContributionDate = "7/25/2024"}
            );
            //Seed data for the Developers table
            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Jack Perry", Email = "perry128@mail.nmc.edu" },
                new Developer { Id = 2, Name = "Aries" }
                );

            //Seed data for the Games table
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Title = "Twin Snakes", Progress = Progress.Production, Genre = "Arcade", Platform = "Browser", Version = "0.1" },
                new Game { Id = 2, Title = "Paddles", Progress = Progress.Production, Genre = "Arcade", Platform = "Browser", Version = "0.1" },
                new Game { Id = 3, Title = "Tag", Progress = Progress.Production, Genre = "Arcade", Platform = "Browser", Version = "0.1" },
                new Game { Id = 4, Title = "Phantom's Prey", Progress = Progress.PreProduction, Genre = "Action Platformer", Platform = "PC", Version = "pre-alpha" }
            );

        }
    }
}
