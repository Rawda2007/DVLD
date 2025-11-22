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
        public static void ChangeStatusAppliction(int AppID, int StatusID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  update [Applications]
  set ApplicationStatus=@StatusID
  where ApplicationID=@AppID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@StatusID", StatusID);
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.ExecuteNonQuery();

            }
        }
        public static int GetPersonIDByApplicationID(int AppID)
        {
            int PersonID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"    select ApplicantPersonID from [Applications]
  where ApplicationID=@AppID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@AppID", AppID);
                PersonID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return PersonID;
        }
        public static int InsertApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, decimal Fees, int UserID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  INSERT INTO [Applications]
           ([ApplicantPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
     VALUES
	 (@PID,@ADate,@ATID,@Status,@LastDate,@Fees,@UserID);
	 select SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@PID", ApplicantPersonID);
                cmd.Parameters.AddWithValue("@ADate", ApplicationDate);
                cmd.Parameters.AddWithValue("@ATID", ApplicationTypeID);
                cmd.Parameters.AddWithValue("@Status", ApplicationStatus);
                cmd.Parameters.AddWithValue("@LastDate", LastStatusDate);
                cmd.Parameters.AddWithValue("@Fees", Fees);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                int rows = Convert.ToInt32(cmd.ExecuteScalar());
                return rows;

            }

        }
    }
}
