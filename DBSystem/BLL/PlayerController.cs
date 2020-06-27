using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DBSystem.DAL;
using DBSystem.ENTITIES;

namespace DBSystem.BLL
{
    public class PlayerController
    {
        public Player FindByPKID(int id)
        {
            using (var context = new ContextFSIS())
            {
                return context.Player.Find(id);
            }
        }
        public List<Player> List()
        {
            using (var context = new ContextFSIS())
            {
                return context.Player.ToList();
            }
        }
        public List<Player> FindByID(int id)
        {
            using (var context = new ContextFSIS())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByTeam @ID"
                        , new SqlParameter("ID", id));
                return results.ToList();
            }
        }
        public List<Player> FindByPartialName(string partialname)
        {
            using (var context = new ContextFSIS())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByPartialPlayerName @PartialName",
                         new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        public int Add(Player item)
        {
            using (var context = new ContextFSIS())
            {
                context.Player.Add(item);
                context.SaveChanges();
                return item.PlayerID;

            }
        }
        public int Update(Player item)
        {
            using (var context = new ContextFSIS())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Delete(int productid)
        {
            using (var context = new ContextFSIS())
            {
                var existing = context.Player.Find(productid);
                if (existing == null)
                {
                    throw new Exception("Player has been removed from database");
                }
                context.Player.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
