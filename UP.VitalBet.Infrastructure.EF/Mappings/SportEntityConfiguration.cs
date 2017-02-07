using System.Data.Entity.ModelConfiguration;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF.Mappings
{
    public class SportEntityConfiguration: EntityTypeConfiguration<Sport>
    {
        public SportEntityConfiguration()
        {
            this.ToTable("Sports")
                .HasKey<int>(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            this.HasMany(x => x.Events)
                .WithOptional().
                HasForeignKey(t => t.SportId)
                ;
        }
    }
}
