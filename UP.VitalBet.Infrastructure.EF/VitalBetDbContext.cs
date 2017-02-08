using System;
using System.Data.Entity;
using UP.VitalBet.Infrastructure.EF.Mappings;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF
{
    public class VitalBetDbContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Odd> Odds { get; set; }

        public VitalBetDbContext() : base("VitalBetDbContext") {
            Database.SetInitializer<VitalBetDbContext>(
                new CreateDatabaseIfNotExists<VitalBetDbContext>());
            Configuration.AutoDetectChangesEnabled = false;
            Database.CommandTimeout = 60;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SportEntityConfiguration());
            modelBuilder.Configurations.Add(new EventEntityConfiguration());
            modelBuilder.Configurations.Add(new MatchEntityConfiguration());
            modelBuilder.Configurations.Add(new BetEntityConfiguration());
            modelBuilder.Configurations.Add(new OddEntityConfiguration());
        }
    }
}
