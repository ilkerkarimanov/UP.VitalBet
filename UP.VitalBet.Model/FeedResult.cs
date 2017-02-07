using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP.VitalBet.Model
{
    public class FeedResult
    {
       public IEnumerable<Sport> Sports{get; set;}

        public FeedResult()
        {
            Sports = new List<Sport>();
        }
    }
}
