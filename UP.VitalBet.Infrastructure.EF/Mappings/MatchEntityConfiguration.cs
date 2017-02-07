using System.Data.Entity.ModelConfiguration;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF.Mappings
{
    public class MatchEntityConfiguration: EntityTypeConfiguration<Match>
    {
        public MatchEntityConfiguration()
        {
            this.ToTable("Matches")
                .HasKey<int>(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            this.HasMany(x => x.Bets)
                .WithOptional()
                .HasForeignKey(t => t.MatchId)
                ;
        }
    }
}
