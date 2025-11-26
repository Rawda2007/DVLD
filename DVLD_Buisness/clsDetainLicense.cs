using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Buisness
{
    public class clsDetainLicense
    {
        public static DataTable GetAllDetainedLicenses()

        {
            return clsDetainLicenses.GetAllDetainedLicenses();
        }
        public static int AddDetainLicense(int LicenseID, int Fees, int UserID)
        {
            return clsDetainLicenses.AddDetainLicense(LicenseID, Fees, UserID);
        }
        public static bool DoLicenseExistInDetain(int LicenseID)
        {
            return clsDetainLicenses.DoLicenseExistInDetain(LicenseID);
        }

        public static DataTable GetInfoDetainedByLicenseID(int LicenseID)
        {
            return clsDetainLicenses.GetInfoDetainedByLicenseID(LicenseID);
        }
        public static int ReleasedDetainedLicense(int DetainedID,string NationalNo,string UserName )
        {
          int AppID=  clsApplication.InsertApplication(clsPeople.GetPersonIDByNational(NationalNo),DateTime.Now,5,3, DateTime.Now,clsApplication_Types.FeesTypeByTypeID(5), UserName);
            clsDetainLicenses.ReleaseDetainedLicenseByDentainedID(DetainedID, AppID, clsUser.GetUserIDByUserName(UserName));

            return AppID;
        }
    }
}
