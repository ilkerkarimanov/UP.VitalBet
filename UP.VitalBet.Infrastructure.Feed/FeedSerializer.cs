using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Infrastructure.Feed.DataSurrogates;

namespace UP.VitalBet.Infrastructure.Feed
{
    public class FeedSerializer : IFeedSerializer
    {
        public SportsFeedRoot SerializeFeed(Stream content)
        {
            SportsFeedRoot result = new SportsFeedRoot();
            using(var reader = new StreamReader(content))
            {
                var serializer = new XmlSerializer(typeof(SportsFeedRoot));
                var serializedObj = serializer.Deserialize(reader) as SportsFeedRoot;
                result = serializedObj;
            }
            return result;
        }
    }
}
