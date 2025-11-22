using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenses
    {
        public static DataTable GetAllDatabase()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"SELECT [InternationalLicenseID]
                      ,[ApplicationID]
                      ,[DriverID]
                      ,[IssuedUsingLocalLicenseID]
                      ,[IssueDate]
                      ,[ExpirationDate]
                      ,[IsActive]
                  FROM [InternationalLicenses]";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            return dt;
        }

        public static DataTable GetDataDriveLicenseInfoByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select Licenses.LicenseID, LicenseClasses.ClassName,ISNULL(Licenses.Notes, '') AS Notes,
                                Licenses.DriverID,Licenses.IssueDate,Licenses.ExpirationDate,Licenses.IssueReason,
                                Licenses.IsActive,
                                Name=People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName,
                                People.NationalNo ,People.ImagePath
                                from Licenses inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass
                                inner join Applications on Applications.ApplicationID=Licenses.ApplicationID
                                inner join People on People.PersonID=Applications.ApplicantPersonID
                                where Licenses. LicenseID=@LicenseID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            return dt;
        }
        public static bool IsExistLicenseIDBytLicenseID(int LID)
        {
            bool IsExist = false;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"  select count (*) from [InternationalLicenses]
  where IssuedUsingLocalLicenseID=@LID
";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LID", LID);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 1)
                {
                    IsExist = true;
                }
            }
            return IsExist;
        }

        public static int InsertInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  INSERT INTO [InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
        VALUES
         (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
            SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
               
                // Get the newly inserted ID
                NewID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return NewID;

        }

        public static DataTable GetDataInternationalToHistoryLicense(int PersonID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  select [InternationalLicenses].InternationalLicenseID as ILicenseID,[InternationalLicenses].ApplicationID as AppID,
  [InternationalLicenses].IssuedUsingLocalLicenseID as LLiceseID,[InternationalLicenses].IssueDate,[InternationalLicenses].ExpirationDate
  ,[InternationalLicenses].IsActive from [InternationalLicenses]
  inner join Applications on Applications.ApplicationID=[InternationalLicenses].ApplicationID
where Applications.ApplicantPersonID=@PersonID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
                return dt;


            }
        }
        public static DataTable GetDataInternationalByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  select * from [InternationalLicenses]
where IssuedUsingLocalLicenseID=@ID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ID", LicenseID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
                return dt;


            }


        }
    }
}
