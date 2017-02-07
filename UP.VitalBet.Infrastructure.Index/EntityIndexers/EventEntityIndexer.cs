using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.EntityIndexers
{
    public class EventEntityIndexer : IEntityIndexer<Event>
    {
        private readonly IEventRepository _repo;
        public EventEntityIndexer(IEventRepository repo)
        {
            _repo = repo;
        }

        public void Index(IEnumerable<Event> collectionData)
        {
            IList<Event> newData = new List<Event>();
            IList<Event> existingData = new List<Event>();
            var lookupData = _repo.GetAll(true);

            newData = collectionData.Except(lookupData, new ExistingEventComparer()).ToList();

            if (lookupData.Any())
            {
                existingData = collectionData
                    .Except(lookupData, new NonModifiedEventComparer())
                    .Except(newData, new ExistingEventComparer()).ToList();
            }
            
            if (newData.Any())
                _repo.InserAll(newData);

            if (existingData.Any())
                _repo.UpdateAll(existingData);

        }

        public class NonModifiedEventComparer : IEqualityComparer<Event>
        {
            public bool Equals(Event x, Event y)
            {
                var equal = 
                    (x.Id == y.Id && x.IsCategory == y.IsCategory && x.Name == y.Name && x.CategoryId == y.CategoryId);
                return equal;
            }

            public int GetHashCode(Event obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public class ExistingEventComparer : IEqualityComparer<Event>
        {
            public bool Equals(Event x, Event y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(Event obj)
            {
                return obj.Id.GetHashCode();
            }
        }

    }
}
