using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApp
    {
        public static DataTable LicenseClass()
        {
            return clsLocalDrivingLicenseApps.LicenseClass();
        }
        public static int FeesNewLocal()

        {
            return clsLocalDrivingLicenseApps.FeesNewLocal();

        }
        public static bool DoFindOrderElse(int PersonID,int classID)
        {
            return clsLocalDrivingLicenseApps.DoFindOrderElse(PersonID,classID);
        }
        public static int AddNewLocal(int PersonID,string UserName, int ClassID)
        {
            return clsLocalDrivingLicenseApps.AddNewLocal(PersonID, UserName, ClassID);
        }
        public static DataTable GetAllDatabase()
        {
            return clsLocalDrivingLicenseApps.GetAllDatabase();
        }

        public static bool CancelLocalDriving(int LDLAppID)
        {
            return clsLocalDrivingLicenseApps.CancelLocalDriving(LDLAppID);
        }

        public static void FullControlLocalDriving(int DLAppID, ref string Class, ref int numPassed, ref int AppID,
                                            ref string status, ref int Fees, ref string Type, ref string Name,
                                            ref DateTime DateApp, ref DateTime StDate, ref string User)

        {
            clsLocalDrivingLicenseApps.FullControlLocalDriving(DLAppID, ref Class, ref numPassed, ref AppID,
                                           ref status, ref Fees, ref Type, ref Name,
                                           ref DateApp, ref StDate, ref User);
        }

        public static DataTable GetAppointments(int IDLocal,int IDTest )
        {
            return clsLocalDrivingLicenseApps.GetAppointments(IDLocal, IDTest);
        }
        public static DataTable InfoTest(int LocalID)
        {
            return clsLocalDrivingLicenseApps.InfoTest(LocalID);
        }
        public static int FeesVisionEye(int TestID)
        {
           return clsLocalDrivingLicenseApps.FeesTest(TestID);
        }
       
        public static int AddApplicationWhenRetakeTest(int UserID, DateTime AppDate, int Fees,int AppTypeID)
        {
            return clsLocalDrivingLicenseApps.AddApplicationWhenRetakeTest( UserID, AppDate, Fees,AppTypeID);
        }
        public static int SaveAppointment(int LocalID, DateTime AppDate, int Fees, int TestType, int UserID, int AppID)

        {
            return clsLocalDrivingLicenseApps.SaveAppointment(LocalID, AppDate, Fees,TestType, UserID, AppID);
        }
        public static bool AppointmentIsLocked(int LocalID)
        {
            return clsLocalDrivingLicenseApps.AppointmentIsLocked(LocalID);
        }

        public static int GetTestTypeIDByLocalID(int LocalID)

        {
            return clsLocalDrivingLicenseApps.GetTestTypeIDByLocalID(LocalID);
        }

        public static bool EditAppointmentTest(int AppointmentID,DateTime NewDate)

        {
            return clsLocalDrivingLicenseApps.EditAppointmentTest(AppointmentID,NewDate);
        }

        public static bool AppointmentIsLockedByAppointmentID(int AppointmentID)
        {
            return clsLocalDrivingLicenseApps.AppointmentIsLockedByAppointmentID(AppointmentID);
        }

        public static int SaveTakeTest(int AppointmentID,int LDAppID, int result, string notes, int userID)
        {
            return clsLocalDrivingLicenseApps.SaveTakeTest(AppointmentID,LDAppID, result, notes, userID);
        }

        public static bool DoPassedTest(int LocalID, int TestType)
        {
            return clsLocalDrivingLicenseApps.DoPassedTest(LocalID, TestType);
        }

        public static DataTable InfoTestByLocalID(int LocalID)
        {
            return clsLocalDrivingLicenseApps.InfoTestByLocalID(LocalID);
        }
        public static int GetAppIDByLocalID(int LocalID)
        {
            return clsLocalDrivingLicenseApps.GetAppIDByLocalID(LocalID);
        }
        public static int IssueDrivingLicense(int LDAppID,string ClassName,string National,int UserID,string Notes)
        {
            int PersonID = clsPeople.GetPersonIDByNational(National);
         int DriverID = clsDrivers.GetDriverIDIFExistByPersonID(PersonID);
            if(DriverID == 0)
            {
                DriverID = clsDrivers.AddNewDrivers(PersonID, UserID);
            }
            int AppID= clsLocalDrivingLicenseApps.GetAppIDByLocalID(LDAppID);
            clsApplications.ChangeStatusAppliction(AppID, 3);//Completed
            int LicenseClassID = clsLicenses.GetClassIDByNameClassLicense(ClassName);
            DateTime IssueDate= DateTime.Now;
            DateTime ExpirationDate= DateTime.Now.AddYears(clsLicenses.GetValidityLengthLicenseByClassName(ClassName));
            int PaidFees = clsLicenses.GetPaidFeesByClassID(LicenseClassID);
            
            //            (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IssueReason, CreatedByUserID)
            //Values(@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IssueReason, @CreatedByUserID)
            return clsLocalDrivingLicenseApps.IssueDrivingLicense(AppID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, 1, UserID);
        }
        public static bool IsExist(int LicenseID)
        {
            return clsLocalDrivingLicenseApps.IsExist(LicenseID);
        }

        public static DataTable GetDataLicenseToHistoryLicense(int PersonID)

        {
            return clsLocalDrivingLicenseApps.GetDataLicenseToHistoryLicense(PersonID);
        }
    }

}
