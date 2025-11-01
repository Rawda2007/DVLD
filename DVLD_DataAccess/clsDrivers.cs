using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDrivers
    {

        public static int AddNewDrivers(int PersonID,int UserID)
        {
            int DriverID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection)) 
                {
                  conn.Open();
                string Query = @" insert into Drivers (PersonID,CreatedByUserID,CreatedDate)
                                values (@PersonID,@UserID,GetDate()); select SCOPE_IDENTITY();";
                SqlCommand cmd=new SqlCommand (Query, conn);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@UserID",UserID);
                DriverID=Convert.ToInt32(cmd.ExecuteScalar());

            }
            return DriverID;
        }
        public static int GetDriverIDIFExistByPersonID(int PersonID)
        {
            int DriverID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" select DriverID from Drivers where PersonID=@PersonID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DriverID = Convert.ToInt32(dr["DriverID"]);
                }
                dr.Close();
            }
            return DriverID;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" select D.DriverID,P.PersonID,P.NationalNo,FullName=P.FirstName+' '+p.SecondName+' '+P.ThirdName+' ' +P.LastName,
D.CreatedDate as Date 
from Drivers as D
inner join People as P on P.PersonID=D.PersonID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dt.Load(reader);
                    reader.Close();
                }

            }
            return dt;
        }
    }
}
