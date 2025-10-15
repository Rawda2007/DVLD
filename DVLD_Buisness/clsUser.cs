using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DVLD_Buisness
{
    public class clsUser
    {
        public static bool CheckLogIn(string UserName, string passport)
        {
            return clsUsers.CheckLogIn(UserName, passport);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsers.GetAllUsers();
        }
        public static User GetUser(int id)
        {
            return clsUsers.GetUser(id);
        }
        public static bool DoPersonConnectecedToUser(int PersonID)
        {
            return clsUsers.DoPersonConnectecedToUser(PersonID);
        }
        public static int AddUser(User entity)
        {
            return clsUsers.AddUser(entity);
        }
        public static bool DoPersonIdConnectecedToUser(int personid)
        {
            return clsUsers.DoPersonIdConnectecedToUser(personid);
        }

    }
}
