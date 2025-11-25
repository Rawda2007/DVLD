using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsRenewLicenses
    {
        public static int RenewLicense(int OldLicenseID,ref int AppID,string Notes,int AppFees,int TFees,int UserID,DateTime ExpDate,int AppTypeID,int IssueReason)
        {
             clsRenewLicense.AddNewApplication(OldLicenseID, AppFees, UserID, ref AppID,AppTypeID);
            return clsRenewLicense.AddReNewLicense(OldLicenseID, ref AppID, ExpDate, Notes, TFees, UserID, IssueReason);

        }
    }
}
