using System.Collections.Generic;

namespace UP.VitalBet.Model
{
    public class Sport : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public Sport()
        {
            this.Events = new List<Event>();
        }
    }
}
