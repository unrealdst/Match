using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class DataRepositry : IDataRepositry
    {
        DataContext context;
        public DataRepositry()
        {
            context = new DataContext();
        }

        public void AddPlay(string login, int number, int matchId)
        {
            var match = context.Match.FirstOrDefault(x => x.Id == matchId);
            match.Plays.Add(new MatchPlay()
            {
                Login = login,
                Number = number
            });

            context.SaveChanges();
        }

        public IEnumerable<Match> GetMatch()
        {
            return context.Match.ToList();
        }

        public IEnumerable<MatchPlay> GetPlays(int id)
        {
            return context.MatchPlay.Where(x => x.Id == id);
        }

        public MatchConfig GetMatchConfig()
        {
            return context.MatchConfig.FirstOrDefault();
        }

        public void RemoveConfig(int id)
        {
            var toDelete = context.MatchConfig.FirstOrDefault(x => x.Id == id);
            if (toDelete != null)
            {
                context.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
            }

            context.SaveChanges();
        }

        public void AddMatch(DateTime start, DateTime end)
        {
            context.Match.Add(new Match()
            {
                Start = start,
                End = end
            });

            context.SaveChanges();
        }
    }
}
