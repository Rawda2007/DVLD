using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public  class clsInternationalLicense
    {
        public static DataTable GetAllDatabase()

        {
            return clsInternationalLicenses.GetAllDatabase();
        }

        public static DataTable GetDataDriveLicenseInfoByLicenseID(int LicenseID)

        {
            return clsInternationalLicenses.GetDataDriveLicenseInfoByLicenseID(LicenseID);
        }

        public static bool IsExistLicenseIDBytLicenseID(int LID)

        {
            return clsInternationalLicenses.IsExistLicenseIDBytLicenseID(LID);
        }

        public static int InsertInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)

        {
            return clsInternationalLicenses.InsertInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public static DataTable GetDataInternationalToHistoryLicense(int PersonID)

        {
           return clsInternationalLicenses.GetDataInternationalToHistoryLicense(PersonID);
        }

        public static DataTable GetDataInternationalByLicenseID(int LicenseID)
        {
            return clsInternationalLicenses.GetDataInternationalByLicenseID(LicenseID);
        }
    }
}
