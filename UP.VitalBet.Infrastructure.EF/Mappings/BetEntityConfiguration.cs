using System.Data.Entity.ModelConfiguration;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF.Mappings
{
    public class BetEntityConfiguration: EntityTypeConfiguration<Bet>
    {
        public BetEntityConfiguration()
        {
            this.ToTable("Bets")
                .HasKey<int>(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            this.HasMany(x => x.Odds)
                .WithOptional()
                .HasForeignKey(t => t.BetId)
                ;
        }
    }
}
