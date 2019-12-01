using System;
using DataLayer.Models;
using LogicLayer.Models;


namespace DataLayer
{
    internal static class Mapper
    {
        internal static MatchModel Map(Match match)
        {
            return new MatchModel
            {
                Start = match.Start,
                End = match.End,
                Id = match.Id
            };
        }

        internal static MatchPlayModel Map(MatchPlay matchPlay)
        {
            return new MatchPlayModel
            {
                Id = matchPlay.Id,
                Login = matchPlay.Login,
                Number = matchPlay.Number
            };
        }

        internal static MatchConfigModel Map(MatchConfig matchConfig)
        {
            return new MatchConfigModel()
            {
                Id = matchConfig.Id,
                End = matchConfig.End,
                Start = matchConfig.Start
            };
        }
    }
}
