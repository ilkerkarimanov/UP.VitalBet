using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.DataSurrogates
{
    public class MatchSurrogated: IDataSurrogate<Match>
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }
        [XmlAttribute("MatchType")]
        public string MatchType { get; set; }
        [XmlElement("Bet")]
        public List<BetSurrogated> Bets { get; set; }

        public MatchSurrogated()
        {
            this.Bets = new List<BetSurrogated>();
        }

        public Match GetDeserializedObject(int parentRef = 0)
        {
            Match obj = new Match();
            obj.Id = Id;
            obj.EventId = parentRef;
            obj.Name = Name;
            obj.MatchType = MatchType;
            obj.StartDate = StartDate;
            obj.Bets = Bets.Select(x => x.GetDeserializedObject(Id)).ToList();
            return obj;
        }
    }
}
