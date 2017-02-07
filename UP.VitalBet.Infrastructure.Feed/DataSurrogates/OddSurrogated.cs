using System;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.DataSurrogates
{
    public class OddSurrogated: IDataSurrogate<Odd>
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Value")]
        public decimal Value { get; set; }
        [XmlAttribute("SpecialBetValue")]    
        public string SpecialBetValue { get; set; }

        public Odd GetDeserializedObject(int parentRef = 0)
        {

            Odd obj = new Odd();
            obj.Id = Id;
            obj.BetId = parentRef;
            obj.Name = Name;
            obj.SpecialBetValue = SpecialBetValue ?? string.Empty;
            obj.Value = Value;
            return obj;
        }
    }
}
