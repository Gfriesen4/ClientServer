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
    public class TeamController
    {
        public Team FindByPKID(int id)
        {
            using (var context = new ContextFSIS())
            {
                return context.Team.Find(id);
            }
        }
        public List<Team> List()
        {
            using (var context = new ContextFSIS())
            {
                return context.Team.ToList();
            }
        }
    }
}