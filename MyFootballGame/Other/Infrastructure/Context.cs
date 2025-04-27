using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FootballSim;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Match Relations
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HostTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HostTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.GuestTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.GuestTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // SeasonWinner relation
            modelBuilder.Entity<Season>()
                .HasOne(s => s.SeasonWinner)
                .WithMany()
                .HasForeignKey(t => t.SeasonWinnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure primary key for IdentityUserLogin<string>
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
    }
}