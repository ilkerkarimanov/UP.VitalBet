using System;
using System.Collections.Generic;

namespace UP.VitalBet.Model
{
    public class Match : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string MatchType { get; set; }
        
        public int EventId { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }

        public Match()
        {
            this.Bets = new List<Bet>();
        }
    }
}
