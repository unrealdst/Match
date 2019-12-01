using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace LogicLayer
{
    public class MatchService : IMatchService
    {
        private IDataRepositry data;
        private const int range = 10;
        public MatchService(IDataRepositry data)
        {
            this.data = data;
        }

        public IEnumerable<MatchModel> GetMatches()
        {
            var matches = data.GetMatch().Select(x => Mapper.Map(x));

            var mainMatches = matches.Skip(matches.Count() - range).Take(range - 1);

            var result = new List<MatchModel>();
            foreach (var item in mainMatches)
            {
                item.Winners = GetWinners(item.Id);
                result.Add(item);
                if (item.End > DateTime.Now && item.Start < DateTime.Now)
                {
                    item.IsCurrent = true;
                }
            }

            return result;
        }

        private List<string> GetWinners(int matchId)
        {
            var matches = data.GetPlays(matchId).Select(x => Mapper.Map(x));
            var higgest = matches.Any() ? matches.Max(x => x.Number) : -1;
            var result = matches.Any() ? matches.Where(x => x.Number == higgest).Select(x => x.Login).ToList() : new List<string>();
            return result;

        }

        public void Play(MatchPlayParameters parameters)
        {
            var randomNumber = new Random().Next(1, 100);
            var matches = data.GetMatch().Select(x => Mapper.Map(x));
            var currentMatch = matches.FirstOrDefault(x => x.End > DateTime.Now && x.Start < DateTime.Now);
            if (currentMatch != null)
            {
                data.AddPlay(parameters.Login, randomNumber, currentMatch.Id);
            }
        }

        public void AddNewMatch()
        {
            var nextMatchConfig = Mapper.Map(data.GetMatchConfig());
            data.AddMatch(nextMatchConfig.Start, nextMatchConfig.End);
            data.RemoveConfig(nextMatchConfig.Id);
        }
    }
}
