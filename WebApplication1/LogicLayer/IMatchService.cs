using LogicLayer.Models;
using System.Collections.Generic;

namespace LogicLayer
{
    public interface IMatchService
    {
        IEnumerable<MatchModel> GetMatches();

        void Play(MatchPlayParameters parameters);

        void AddNewMatch();
    }
}
