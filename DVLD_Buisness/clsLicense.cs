using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
namespace DVLD_Buisness
{
    public class clsLicense
    {
        public static DataTable GetInfoLicenseByLicenseID(int LicenseID)

        {
            return clsLicenses.GetInfoLicenseByLicenseID(LicenseID);
        }
        public static string GetClassNameByClassID(int ClassID)
        {
            return clsLicenses.GetClassNameByClassID(ClassID);
        }
        public static int GetLicenseIDByNational(string National,string ClassName )
        {
            int ClassID=clsLicenses.GetClassIDByNameClassLicense(ClassName);
            return clsLicenses.GetLicenseIDByNational(National, ClassID);
        }
    }
}
