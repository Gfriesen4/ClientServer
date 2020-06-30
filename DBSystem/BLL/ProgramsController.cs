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
    }
}