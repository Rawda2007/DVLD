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

        public static bool DoUserConnectAppplicaton(int UserID)
        {       
            return clsUsers.DoUserConnectAppplicaton(UserID);
        }
        public static User GetUserByPersonID(int PersonID)
        {
            return clsUsers.GetUserByPersonID(PersonID);

        }
        public static bool UpdateUser(User entity)
        {
            return clsUsers.UpdateUser(entity);
        }
        public static bool ChangePassword(int PersonID, string OldPassword, string NewPassword)
        {
            return clsUsers.ChangePassword(PersonID, OldPassword, NewPassword);
        }
  public static int PersonIDByUserName(string UserName)
        {
                       return clsUsers.PersonIDByUserName(UserName);
        }
    }
}
