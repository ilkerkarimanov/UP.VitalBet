using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Infrastructure.Feed.DataSurrogates;

namespace UP.VitalBet.Infrastructure.Feed
{
    public class FeedSerializer : IFeedSerializer
    {
        public SportsFeed SerializeFeed(Stream content)
        {
            SportsFeed result = new SportsFeed();
            using(var reader = new StreamReader(content))
            {
                var serializer = new XmlSerializer(typeof(SportsFeed));
                var serializedObj = serializer.Deserialize(reader) as SportsFeed;
                result = serializedObj;
            }
            return result;
        }
    }
}
