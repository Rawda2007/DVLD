using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApps
    {
        public static DataTable GetAllDatabase()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"SELECT LocalDrivingLicenseApplicationID as LDLAppID
                      ,[ClassName]
                      ,[NationalNo]
                      ,[FullName]
                      ,[ApplicationDate]
                      ,[PassedTestCount]
                      ,[Status]
                  FROM [LocalDrivingLicenseApplications_View]";
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

        //Fill Combobox Lincence class
        public static DataTable LicenseClass()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"SELECT [LicenseClassID]
                                  ,[ClassName]
                              FROM [LicenseClasses]
                            ";
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

        public static int FeesNewLocal()
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"SELECT
                                  [ApplicationFees]
                              FROM [ApplicationTypes]
                              where ApplicationTypeID=1";
                SqlCommand cmd = new SqlCommand(Query, conn);
                i = Convert.ToInt32(cmd.ExecuteScalar());

            }
            return i;
        }

        //Check Before Save
        public static bool DoFindOrderElse(int PersonID, int ClassID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select count(*) from Applications inner join [LocalDrivingLicenseApplications]
  on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
	    where LocalDrivingLicenseApplications.LicenseClassID=@ClassID and 
		Applications.ApplicantPersonID=@PersonID and Applications.ApplicationStatus=1";

                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result > 0;//found
        }

        public static int AddNewLocal(int PersonID, string UserName, int ClassID)
        {
            int AppPersonID = 0;
            int LocalID = 0;
            int UserID = clsUsers.GetUserIDByUserName(UserName);


            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();

                // 1️⃣ إدخال في جدول Applications
                string query1 = @"INSERT INTO [Applications]
                ([ApplicantPersonID],
                 [ApplicationDate],
                 [ApplicationTypeID],
                 [ApplicationStatus],
                 [LastStatusDate],
                 [PaidFees],
                 [CreatedByUserID])
          VALUES(@PersonID ,GETDATE(),1,1,GETDATE(), @Fees,@User);
          SELECT SCOPE_IDENTITY();";

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@PersonID", PersonID);
                cmd1.Parameters.AddWithValue("@Fees", FeesNewLocal());
                cmd1.Parameters.AddWithValue("@User", UserID);

                AppPersonID = Convert.ToInt32(cmd1.ExecuteScalar());

                // 2️⃣ إدخال في جدول LocalDrivingLicenseApplications
                string query2 = @"INSERT INTO [LocalDrivingLicenseApplications]
                ([ApplicationID],
                 [LicenseClassID])
          VALUES (@AppID ,@ClassID);
          SELECT SCOPE_IDENTITY();";

                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@AppID", AppPersonID);
                cmd2.Parameters.AddWithValue("@ClassID", ClassID);

                LocalID = Convert.ToInt32(cmd2.ExecuteScalar());
            }

            return LocalID;
        }

        public static bool CancelLocalDriving(int LDLAppID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {

                conn.Open();
                string query = @"  select [ApplicationID] from [LocalDrivingLicenseApplications]
                                  where [LocalDrivingLicenseApplicationID]=@LDLAppID";
                SqlCommand cmd2 = new SqlCommand(query, conn);
                cmd2.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                int AppPersonID = Convert.ToInt32(cmd2.ExecuteScalar());

                string Query = @"Update Applications set ApplicationStatus=2
                                where ApplicationID=@PersonID";
                SqlCommand cmd1 = new SqlCommand(Query, conn);
                cmd1.Parameters.AddWithValue("@PersonID", AppPersonID);
                result = Convert.ToInt32(cmd1.ExecuteNonQuery());

            }
            return result > 0;
        }

        public static void FullControlLocalDriving(int DLAppID, ref string Class, ref int numPassed, ref int AppID,
                                                    ref string status, ref int Fees, ref string Type, ref string Name,
                                                    ref DateTime DateApp, ref DateTime StDate, ref string User)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string query = @"select * from LocalDrivingLicenseApplications_View
                                     where LocalDrivingLicenseApplicationID=@DLAppID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@DLAppID", DLAppID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Class = reader["ClassName"].ToString();
                    numPassed = Convert.ToInt32(reader["PassedTestCount"]);
                    status = reader["Status"].ToString();
                    Name = reader["FullName"].ToString();
                    DateApp = Convert.ToDateTime(reader["ApplicationDate"]);

                }
                reader.Close();

                string Query2 = @"  select   L.ApplicationID,
                                L.ApplicationDate,L.LastStatusDate,L.PaidFees
                                 ,Users.UserName from LocalDrivingLicenseFullApplications_View as L inner
                                  join  Users on Users.PersonID=L.ApplicantPersonID
                                  where L.LocalDrivingLicenseApplicationID=@DLApp";
                SqlCommand command2 = new SqlCommand(Query2, conn);
                command2.Parameters.AddWithValue("@DLApp", DLAppID);
                SqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    AppID = Convert.ToInt32(reader2["ApplicationID"]);
                    Fees = Convert.ToInt32(reader2["PaidFees"]);
                    Type = "New Local Driving License Services";
                    StDate = Convert.ToDateTime(reader2["LastStatusDate"]);
                    User = reader2["UserName"].ToString();
                }
                reader2.Close();
            }
        }

        //DataGrid Appointment
        public static DataTable GetAppointments(int IDLocal, int IDTest)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select TestAppointmentID as AppointmentID ,AppointmentDate,PaidFees ,IsLocked from TestAppointments 
                                 where TestTypeID= @IDTest and LocalDrivingLicenseApplicationID=@IDLocal ";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@IDLocal", IDLocal);
                command.Parameters.AddWithValue("@IDTest", IDTest);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            return dt;
        }

        public static DataTable InfoTest(int LocalID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"SELECT  [TestAppointmentID]
                          ,[LocalDrivingLicenseApplicationID]
                          ,[TestTypeTitle]
                          ,[ClassName]
                          ,[AppointmentDate]
                          ,[PaidFees]
                          ,[FullName]
  
                      FROM [DVLD].[dbo].[TestAppointments_View]
                      where LocalDrivingLicenseApplicationID=@LocalID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LocalID", LocalID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            return dt;
        }

        public static int FeesTest(int TypeTest)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"SELECT  [TestTypeFees]
  FROM [TestTypes] where TestTypeID=@TypeTest;";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@TypeTest", TypeTest);
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }

        public static int AddApplicationWhenRetakeTest(int UserID, DateTime AppDate, int Fees, int AppTypeID)
        {
            int AppID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                int PersonID = clsUsers.GetPersonIDByUserID(UserID);
                string query = @"INSERT INTO [Applications]
           (ApplicantPersonID,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
                     VALUES
           (@PersonID,@AppDate,@AppTypeID,1,@AppDate,@TotalFees,@UserID);select SCOPE_IDENTITY();";

                SqlCommand cmmand = new SqlCommand(query, conn);
                cmmand.Parameters.AddWithValue("@AppTypeID", AppTypeID);
                cmmand.Parameters.AddWithValue("@PersonID", PersonID);
                cmmand.Parameters.AddWithValue("@AppDate", AppDate);
                cmmand.Parameters.AddWithValue("@TotalFees", Fees);
                cmmand.Parameters.AddWithValue("@UserID", UserID);
                AppID = Convert.ToInt32(cmmand.ExecuteScalar());
            }
            return AppID;
        }

        public static int SaveAppointment(int LocalID, DateTime AppDate, int Fees, int TestType, int UserID, int AppID)
        {
            int result = 0;
            //int ApplicationID= 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();

                string Query = @"INSERT INTO [TestAppointments] 
(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
          VALUES (@TestType,@LocalID,@AppDate,@Fees,@UserID,0,@RetakeAppID) ; select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LocalID", LocalID);
                cmd.Parameters.AddWithValue("@TestType", TestType);
                cmd.Parameters.AddWithValue("@AppDate", AppDate);
                cmd.Parameters.AddWithValue("@Fees", Fees);
                if (AppID != 0) cmd.Parameters.AddWithValue("@RetakeAppID", AppID);
                else cmd.Parameters.AddWithValue("@RetakeAppID", DBNull.Value);

                cmd.Parameters.AddWithValue("@UserID", UserID); // Assuming CreatedByUserID is 1 for now
                result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            return result;
        }

        public static bool AppointmentIsLocked(int LocalID)
        {
            bool result = true;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select count(*) from TestAppointments 
                                where LocalDrivingLicenseApplicationID=@LocalID and IsLocked=0";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LocalID", LocalID);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    result = false;
                }


            }
            return result;
        }

        public static int GetTestTypeIDByLocalID(int LocalID)
        {
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();

                string Query = @" select count(*) from TestAppointments as A inner join 
  Tests as T on A.TestAppointmentID=T.TestAppointmentID 
  where A.LocalDrivingLicenseApplicationID=@LocalID and A.ISLocked=1 and T.TestResult=1 ";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LocalID", LocalID);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count + 1;

            }

        }

        public static bool EditAppointmentTest(int AppointmentID, DateTime NewDate)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" update TestAppointments set AppointmentDate=@NewDate
                                where TestAppointmentID=@AppointmentID ";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                cmd.Parameters.AddWithValue("@NewDate", NewDate);
                int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool AppointmentIsLockedByAppointmentID(int AppointmentID)
        {
            bool result = true;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select IsLocked from TestAppointments 
                                where TestAppointmentID=@AppointmentID ";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                int isLocked = Convert.ToInt32(cmd.ExecuteScalar());
                if (isLocked == 0)
                {
                    result = false;
                }
            }
            return result;
        }
        public static int SaveTakeTest(int AppointmentID, int LDAppID, int result, string notes, int userID)
        {
            int TestID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" insert into Tests
                                  (TestAppointmentID,TestResult,Notes,CreatedByUserID)
                                  values
                                  (@AppointmentID,@TestResult,@Notes,@UserID);
                                    select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                cmd.Parameters.AddWithValue("@TestResult", result);
                cmd.Parameters.AddWithValue("@Notes", notes);
                cmd.Parameters.AddWithValue("@UserID", userID);
                TestID = Convert.ToInt32(cmd.ExecuteScalar());

                string Query2 = @" update [TestAppointments] set IsLocked=1 where [LocalDrivingLicenseApplicationID]=@LDAppID";
                SqlCommand cmd2 = new SqlCommand(Query2, conn);
                cmd2.Parameters.AddWithValue("@LDAppID", LDAppID);
                int effects = Convert.ToInt32(cmd2.ExecuteNonQuery());

            }
            return TestID;
        }

        public static bool DoPassedTest(int LocalID, int TestType)
        {
            int Count = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select count(*) from Tests inner join [TestAppointments] as A
 on Tests.TestAppointmentID=A.TestAppointmentID
 where A.LocalDrivingLicenseApplicationID=@LocalID and Tests.TestResult=1 and A.TestTypeID=@TestType";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LocalID", LocalID);
                cmd.Parameters.AddWithValue("@TestType", TestType);
                Count = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return Count > 0;
        }

        public static DataTable InfoTestByLocalID(int LocalID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select Loc.LocalDrivingLicenseApplicationID,lic.ClassName,lic.ClassFees,A.FullName
              from [LocalDrivingLicenseApplications] as Loc
              inner join [LicenseClasses] lic on Loc.LicenseClassID=lic.LicenseClassID
              inner join LocalDrivingLicenseApplications_View  as A on Loc.LocalDrivingLicenseApplicationID=A.LocalDrivingLicenseApplicationID
              where Loc.LocalDrivingLicenseApplicationID=@LocalID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LocalID", LocalID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            return dt;
        }

        public static int GetAppIDByLocalID(int LocalID)
        {
            int AppID = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select [ApplicationID] from [LocalDrivingLicenseApplications] 
 where [LocalDrivingLicenseApplicationID]=@LocalID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@LocalID", LocalID);
                AppID = Convert.ToInt32(command.ExecuteScalar());
            }
            return AppID;
        }
        public static int IssueDrivingLicense(int AppID, int DriverID, int LicenseClassID, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, int PaidFees, int Reason, int UserID)
        {
            int LicenseID = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"insert into [Licenses]
(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IssueReason,CreatedByUserID)
Values (@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IssueReason,@CreatedByUserID);
select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ApplicationID", AppID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IssueReason", Reason);
                command.Parameters.AddWithValue("@CreatedByUserID", UserID);


                LicenseID = Convert.ToInt32(command.ExecuteScalar());


            }
            return LicenseID;
        }
    }
}