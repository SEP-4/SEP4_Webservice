using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.DataAccess
{
    public class GymData
    {
        public Gym GetGymByEmail(string email)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Gym>("dbo.spGym_GetByEmail @Email", new { Email = email }).First();
                return output;
            }
        }

       
    }
}
