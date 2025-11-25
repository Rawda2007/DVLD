using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DVLD_DataAccess
{
    public class clsRenewLicense
    {
        public static void AddNewApplication(int OldLicenseID, int AppFees, int UserID, ref int AppID,int AppTypeID)
        {
            int NewApplicationID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"  insert into  Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                          values
                          ((select App.ApplicantPersonID from Applications as App
                        inner join Licenses on Licenses.ApplicationID=App.ApplicationID
                        where Licenses.LicenseID=@LicenseID),GETDATE(),@AppType,3,GETDATE(),@AppFees,@UserID);
                        select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", OldLicenseID);

                cmd.Parameters.AddWithValue("@AppFees", AppFees);
                cmd.Parameters.AddWithValue("@AppType", AppTypeID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                NewApplicationID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            AppID = NewApplicationID;

        }

        public static int AddReNewLicense(int OldLicenseID, ref int AppID, DateTime ExpDate, string Notes, int TFees, int UserID,int IssueReason)
        {
            int LicenseID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"INSERT INTO Licenses 
                (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                 Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
            SELECT 
                @AppID,
                DriverID,
                LicenseClass,
                GETDATE(),
                @ExpDate,
                @Notes,
                @Fees,
                1,
                @IssueReason,
                @UserID
            FROM Licenses
            WHERE LicenseID = @LicenseID;
            select SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(Query, conn);
                command.Parameters.AddWithValue("@LicenseID", OldLicenseID);
                command.Parameters.AddWithValue(parameterName: "@AppID", AppID);
                command.Parameters.AddWithValue("@ExpDate", ExpDate);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@Fees", TFees);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@UserID", UserID);
                LicenseID = Convert.ToInt32(command.ExecuteScalar());
                return LicenseID;
            }
        }
    }
}