using System.Data.Entity.ModelConfiguration;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.EF.Mappings
{
    public class EventEntityConfiguration: EntityTypeConfiguration<Event>
    {
        public EventEntityConfiguration()
        {
            this.ToTable("Events")
                .HasKey<int>(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            this.HasMany(x => x.Matches)
                .WithOptional()
                .HasForeignKey(t => t.EventId)
                ;
        }
    }
}
