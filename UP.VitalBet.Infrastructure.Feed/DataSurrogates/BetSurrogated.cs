using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.DataSurrogates
{
    public class BetSurrogated: IDataSurrogate<Bet>
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }
        [XmlElement("Odd")]
        public List<OddSurrogated> Odds { get; set; }

        public BetSurrogated()
        {
            this.Odds = new List<OddSurrogated>();
        }

        public Bet GetDeserializedObject(int parentRef = 0)
        {
            Bet obj = new Bet();
            obj.Id = Id;
            obj.Name = Name;
            obj.MatchId = parentRef;
            obj.IsLive = IsLive;
            obj.Odds = Odds.Select(x => x.GetDeserializedObject(Id)).ToList();
            return obj;
        }
    }
}
