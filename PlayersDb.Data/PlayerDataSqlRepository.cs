using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersDb.Data
{
    public class PlayerDataSqlRepository : IPLayerDataRepository
    {
         public int AddPlayer(Player player)
        {
            using var ctx = new PlayerDbContext();
            var ent = ctx.Add(player);
            ctx.SaveChanges();
            return ent.Entity.Id;
        }

        

        public Player GetPlayersById(int id)
        {
            using var ctx = new PlayerDbContext();
            return ctx.PlayersStats.FirstOrDefault(a => a.Id == id);
        }


        public List<Player> GetPlayers()
        {
            using var ctx = new PlayerDbContext();

            return ctx.PlayersStats.ToList();

        }

        public bool UpdatePlayer(Player player)
        {
            using var ctx = new PlayerDbContext();
            var item = ctx.PlayersStats.FirstOrDefault(a => a.Id == player.Id);

            if (item != null)
            {
                item.Name = player.Name;
                item.Surname = player.Surname;
                item.Points = player.Points;
                item.Rebounds = player.Rebounds;
                item.Assists = player.Assists;

                var res = ctx.SaveChanges();
                return res > 0;

            }
            return false;
        }

       

        public void DeletePlayer(int id)
        {
            using var ctx = new PlayerDbContext();
            var item = ctx.PlayersStats.FirstOrDefault(b => b.Id == id);
            if (item != null)
            {
                ctx.PlayersStats.Remove(item);
                ctx.SaveChanges();
            }
            

        }

       

        
    }
    }

