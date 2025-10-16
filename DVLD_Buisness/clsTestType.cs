using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
namespace DVLD_Buisness
{
    public class clsTestType
    {
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypes.GetAllTestTypes();
        }
        public static bool ChangeFees(int ID, decimal fees)
        {
            return clsTestTypes.ChangeFees(ID, fees);
        }
        public static DataTable GetInfoTestByID(int ID)
        {
            return clsTestTypes.GetInfoTestByID(ID);

        }

    }
}
