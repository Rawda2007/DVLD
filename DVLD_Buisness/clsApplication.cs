using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        public static int GetPersonIDByApplicationID(int AppID)

        {
            return DVLD_DataAccess.clsApplications.GetPersonIDByApplicationID(AppID);
        }
        public static int InsertApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, decimal Fees, string UserName)

        {
            int UserID = clsUser.GetUserIDByUserName(UserName);
            return clsApplications.InsertApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, Fees, UserID);

        }
    }

    }
