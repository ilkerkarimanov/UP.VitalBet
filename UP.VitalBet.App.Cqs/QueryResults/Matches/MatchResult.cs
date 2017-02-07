using System;
using UP.VitalBet.Model;

namespace UP.VitalBet.App.Cqs.QueryResults.Matches
{
    public class MatchResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string MatchType { get; set; }
    }

    public static class MatchResultFactory{
        public static MatchResult Create (Match match)
        {
            return new MatchResult()
            {
                Id = match.Id,
                Name = match.Name,
                StartDate = match.StartDate,
                MatchType = match.MatchType
            };
        }
    }
}
