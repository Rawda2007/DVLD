using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            string Query = "select * from Countries";
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                SqlCommand cmd=new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dt.Load(reader);

                }
                reader.Close(); 
            }
            return dt;
        }
    }
}

