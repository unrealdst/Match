using LogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class Mapper
    {
        public static IEnumerable<MatchViewModel> Map(IEnumerable<MatchModel> matches)
        {
            return matches.Select(x => new MatchViewModel
            {
                End = x.End,
                Start = x.Start,
                Winners = x.Winners != null ? x.Winners.ToList() : new List<string>() { },
                IsCurrent = x.IsCurrent
            });
        }
    }
}