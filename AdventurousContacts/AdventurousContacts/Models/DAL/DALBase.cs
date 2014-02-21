using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AdventurousContacts.Models.DAL
{
    public abstract class DALBase
    {
        private static string connectionString;

        // Skapar och returnerar en referens till ett anslutningsobjekt.
        protected SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        // Initierar connectionString genom att hämta anslutningssträngen från Web.config.
        static DALBase()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString;
        }
    }
}