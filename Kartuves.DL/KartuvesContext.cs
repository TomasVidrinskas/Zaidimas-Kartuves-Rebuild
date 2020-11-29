using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Kartuves.DL;

namespace Kartuves.DL
{
    public class KartuvesContext : DbContext
    {
        public KartuvesContext() : base("Kartuves")
        {
            Database.SetInitializer(new KartuvesContextInitializer());
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<ScoreBoard> ScoreBoards { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Words> Words { get; set; }






    }
}
