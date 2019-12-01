using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataSeed<T> : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var now = DateTime.Now;
            int id = 1;
            int playId = 1;
            for (int i = 20; i > 1; i--)
            {
                List<MatchPlay> matchPlays = new List<MatchPlay>();
                for (int j = 0; j < 5; j++)
                {
                    int rand = new Random().Next(1, 100);
                    matchPlays.Add(new MatchPlay
                    {
                        Id = playId++,
                        Login = $"login{id}_{playId}_{rand}",
                        Number = rand
                    });
                }

                context.Match.Add(new Match
                {
                    Start = now.AddMinutes(-(i * 10)),
                    End = now.AddMinutes(-((i - 1) * 10)),
                    Id = id++,
                    Plays = matchPlays
                });
            }


            base.Seed(context);
        }
    }
}
