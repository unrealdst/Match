using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataRepositry
    {
        IEnumerable<Match> GetMatch();
        IEnumerable<MatchPlay> GetPlays(int id);
        void AddPlay(string login, int number, int matchId);
        void RemoveConfig(int id);
        MatchConfig GetMatchConfig();
        void AddMatch(DateTime start, DateTime end);
    }
}
