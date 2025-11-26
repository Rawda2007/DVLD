using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccess
{
    public class clsDetainLicenses
    {
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  SELECT  [DetainID]
                  ,Licenses.LicenseID
                  ,[DetainDate]
                  ,[FineFees]
                  ,[IsReleased]
                  ,[ReleaseDate]
	              ,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as Name
	              ,People.NationalNo
                  ,[ReleaseApplicationID]
              FROM [DetainedLicenses]
              inner join Licenses on Licenses.LicenseID=DetainedLicenses.LicenseID
              inner join Applications on Licenses.ApplicationID=Applications.ApplicationID
              inner join People on People.PersonID= Applications.ApplicantPersonID
               order by DetainID desc";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public static int AddDetainLicense(int LicenseID, int Fees, int UserID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
  values
  (@LicenseID,GETDATE(),@Fees,@UserID,0);
  select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.Parameters.AddWithValue("@Fees", Fees);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                int NewID = Convert.ToInt32(cmd.ExecuteScalar());
                return NewID;
            }
        }
        public static bool DoLicenseExistInDetain(int LicenseID)
        {
            bool IsExist = false;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  select count (*) from DetainedLicenses where LicenseID=@LicenseID and IsReleased=0";
                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    IsExist = true;
                }
            }
            return IsExist;
        }
        public static DataTable GetInfoDetainedByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  select* from DetainedLicenses
                where LicenseID=@LID and IsReleased=0";
                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@LID", LicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public static void ReleaseDetainedLicenseByDentainedID(int DetainedID,int AppID,int UserID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"update DetainedLicenses 
                set IsReleased=1,ReleaseDate=GetDate(),ReleasedByUserID=@UserID,ReleaseApplicationID=@AppID
                where DetainID=@DetainID;";
                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.Parameters.AddWithValue("@DetainID", DetainedID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
