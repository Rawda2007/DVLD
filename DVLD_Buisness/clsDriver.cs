using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;

namespace DVLD_Buisness
{
    public class clsDriver
    {
        public static int AddNewDriver(int PersonID,int UserID)
        {
            return clsDrivers.AddNewDrivers(PersonID, UserID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDrivers.GetAllDrivers();
        }
    }
}
