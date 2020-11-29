using Kartuves.BL.Interfaces;
using Kartuves.DL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kartuves.BL
{
    public class PlayerManager : IPlayerManager
    {
        public int Add(Player entity)
        {
            int key = 0;
            using (var context = new KartuvesContext())
            {
                context.Players.Add(entity);
                context.SaveChanges();
                key = entity.PlayerId;
            }
            return key;
        }

        public void Delete(int key)
        {

            using (var contex = new KartuvesContext())
            {
                var entity = contex.Players.Find(key);
                contex.Players.Remove(entity);
                contex.SaveChanges();
            }


        }

        public Player Get(int key)
        {
            Player entity;
            using (var context = new KartuvesContext())
            {
                entity = context.Players.Where(z => z.PlayerId == key).Include(z => z.ScoreBoards).FirstOrDefault();

            }
            return entity;
        }

        public List<Player> GetAll()
        {
            List<Player> list;
            using (var context = new KartuvesContext())
            {
                list = context.Players.Include(z => z.ScoreBoards).ToList();

            }
            return list;
        }

        public void Update(Player entity)
        {
            using (var context = new KartuvesContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
        public void AddScoreBoards(ScoreBoard scoreBoard)
        {
            using (var context = new KartuvesContext())
            {
                context.ScoreBoards.Add(scoreBoard);
                context.SaveChanges();

            }
        }
        public Player GetByUserName(string userName)
        {
            Player entity;
            using (var context = new KartuvesContext())
            {
                entity = context.Players.Where(z => z.Name == userName).Include(z => z.ScoreBoards).FirstOrDefault();

            }
            return entity;
        }



    }
}
