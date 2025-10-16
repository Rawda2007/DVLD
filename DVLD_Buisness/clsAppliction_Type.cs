using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

    public class clsAppliction_Type
    {
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplication_Types.GetAllApplicationTypes();
        }

        public static DataTable GetApplicationByID(int ID)
        {
            return clsApplication_Types.GetApplicationByID(ID);
        }
    public static bool ChangeFees(int ID, decimal fees)
    {
     return clsApplication_Types. ChangeFees(ID, fees);

    }

    }

