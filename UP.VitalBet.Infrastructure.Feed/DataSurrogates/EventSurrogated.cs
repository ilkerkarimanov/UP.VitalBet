using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.DataSurrogates
{
    public class EventSurrogated: IDataSurrogate<Event>
    { 
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("CategoryID")]
        public int CategoryId { get; set; }
        [XmlAttribute("IsLive")]
        public bool IsCategory { get; set; }
        [XmlElement("Match")]
        public List<MatchSurrogated> Matches { get; set; }

        public EventSurrogated()
        {
            this.Matches = new List<MatchSurrogated>();
        }

        public Event GetDeserializedObject(int parentRef = 0)
        {
            Event obj = new Event();
            obj.Id = this.Id;
            obj.SportId = parentRef;
            obj.Name = this.Name;
            obj.IsCategory = this.IsCategory;
            obj.Matches = Matches.Select(x => x.GetDeserializedObject(Id)).ToList();
            return obj;
        }
    }
}
