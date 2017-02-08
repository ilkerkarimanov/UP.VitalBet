using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Infrastructure.Feed.DataSurrogates;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed
{
    public class FeedSerializer : IFeedSerializer
    {
        public IEnumerable<Sport> SerializeFeed(Stream content)
        {
            IEnumerable<Sport> result = Enumerable.Empty<Sport>();
            using(var reader = new StreamReader(content))
            {
                var serializer = new XmlSerializer(typeof(SportsFeed));
                var serializedObj = serializer.Deserialize(reader) as SportsFeed;
                result = serializedObj.Sports
                        .Select(x => x.GetDeserializedObject())
                        .ToList();
            }
            return result;
        }
    }
}
