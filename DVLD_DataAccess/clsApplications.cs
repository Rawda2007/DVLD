using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplications
    {
        //ChangeStatusApplictionA
        public static void ChangeStatusAppliction(int AppID,int StatusID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  update [Applications]
  set ApplicationStatus=@StatusID
  where ApplicationID=@AppID";
                SqlCommand cmd =new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@StatusID", StatusID);
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
