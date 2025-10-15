using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global
{
    public class clsVaildation
    {
        public static string validateEmail(string email)
        {
            if(email == null||!email.Contains('@'))
                {
                return "Format Email is wrong !";
            }
            return "";
        }

       

    }
}
