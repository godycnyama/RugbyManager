using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using RugbyManager.Domain.Models;

namespace RugbyManager.Persistence
{
    public class RugbyManagerContext : DbContext
    {
        public RugbyManagerContext(DbContextOptions<RugbyManagerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}