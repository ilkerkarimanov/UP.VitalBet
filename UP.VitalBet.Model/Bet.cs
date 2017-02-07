using System.Collections.Generic;

namespace UP.VitalBet.Model
{
    public class Bet: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLive { get; set; }
        
        public int MatchId { get; set; }
        public virtual ICollection<Odd> Odds { get; set; }

        public Bet()
        {
            this.Odds = new List<Odd>();
        }
    }
}
