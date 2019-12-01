using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
            Database.SetInitializer<DataContext>(new DataSeed<DataContext>());
        }

        public DbSet<MatchConfig> MatchConfig { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<MatchPlay> MatchPlay { get; set; }
    }
}
