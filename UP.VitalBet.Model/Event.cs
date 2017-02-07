using System.Collections.Generic;

namespace UP.VitalBet.Model
{
    public class Event: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsCategory { get; set; }
        public int SportId { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

        public Event()
        {
            this.Matches = new List<Match>();
        }
    }
}
