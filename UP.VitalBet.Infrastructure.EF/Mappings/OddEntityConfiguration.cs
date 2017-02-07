using System.Data.Entity.ModelConfiguration;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF.Mappings
{
    public class OddEntityConfiguration: EntityTypeConfiguration<Odd>
    {
        public OddEntityConfiguration()
        {
            this.ToTable("Odds")
                .HasKey<int>(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();
        }
    }
}
