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
    public class ProgramsController
    {
        public List<Programs> List()
        {
            using (var context = new ContextStarTED())
            {
                return context.Programs.ToList();
            }
        }
        public List<Programs> FindByID(string id)
        {
            using (var context = new ContextStarTED())
            {
                IEnumerable<Programs> results =
                    context.Database.SqlQuery<Programs>("Programs_FindBySchool @Schoolcode"
                        , new SqlParameter("Schoolcode", id));
                return results.ToList();
            }
        }
        public int Update(Programs item)
        {
            using (var context = new ContextStarTED())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            using (var context = new ContextStarTED())
            {
                var existing = context.Programs.Find(id);
                if (existing == null)
                {
                    throw new Exception("Record has been removed from database");
                }
                context.Programs.Remove(existing);
                return context.SaveChanges();
            }
        }
        public Programs FindByPKID(int id)
        {
            using (var context = new ContextStarTED())
            {
                return context.Programs.Find(id);
            }
        }
        public int Add(Programs item)
        {
            using (var context = new ContextStarTED())
            {
                context.Programs.Add(item);
                context.SaveChanges();
                return item.ProgramID;

            }
        }
    }
}
 