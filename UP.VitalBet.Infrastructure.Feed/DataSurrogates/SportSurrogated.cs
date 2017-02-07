using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.DataSurrogates
{
    public class SportSurrogated: IDataSurrogate<Sport>
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("Event")]
        public List<EventSurrogated> Events { get; set; }

        public SportSurrogated()
        {
            this.Events = new List<EventSurrogated>();
        }

        public Sport GetDeserializedObject(int parentId = 0)
        {
            Sport obj = new Sport();
            obj.Id = Id;
            obj.Name = Name;
            obj.Events = Events.Select(x => x.GetDeserializedObject(Id)).ToList();
            return obj;
        }
    }
}
