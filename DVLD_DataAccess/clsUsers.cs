using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DVLD_DataAccess
{
    public class clsUsers
    {
        //LogIn
        public static bool CheckLogIn(string UserName, string passport)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = "select count(*) from Users where UserName=@UserName and Password=@Passport and IsActive=1";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@Passport", passport);
                command.Parameters.Add("@UserName", UserName);
                result = (int)command.ExecuteScalar();

            }
            return result > 0;
        }
    

     public static DataTable GetAllUsers()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string query = @"select u.UserID,u.PersonID,p.FirstName+' '+p.SecondName+' '+p.ThirdName+' '+p.LastName as PersonName
                                    ,u.UserName,u.Password,u.IsActive from
                                    Users u inner join People p
                                    on p.PersonID=u.PersonID";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        table.Load(reader);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
            }

            return table;
        }

        public static User GetUser(int UserID)
        {
            User entity = null;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string query = "SELECT UserID,UserName,IsActive FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // تحريك المؤشر لأول صف
                        {
                            entity = new User(
                                Convert.ToInt32(reader[0]),
                                reader[1].ToString(),
                                Convert.ToInt32(reader[2])
                            );
                        }
                    }
                }
                return entity;
            }

        }
        public static bool DoPersonConnectecedToUser(int PersonID)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select count(*) from Users where PersonID=@PersonID";
                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.Add("@PersonID", PersonID);
                result = (int)Command.ExecuteScalar();
            }
            return result > 0;
        }

        public static int AddUser(User entity)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
                                 VALUES(@PersonID,@UserName,@Password,@IsActive);
                                 SELECT SCOPE_IDENTITY();"; // استعلام لإرجاع المعرف الذي تم إنشاؤه حديثًا
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PersonID", entity.PersonID);
                command.Parameters.AddWithValue("@UserName", entity.UserName);
                command.Parameters.AddWithValue("@Password", entity.Password);
                command.Parameters.AddWithValue("@IsActive", entity.IsActive);
                // تنفيذ الأمر وإرجاع المعرف الجديد
                object newId = command.ExecuteScalar();
                if (newId != null)
                {
                    result = Convert.ToInt32(newId);
                }
            }
            return result;
        }
        public static bool DoPersonIdConnectecedToUser(int PersonID)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select count(*) from Users where PersonID=@PersonID";
                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.Add("@PersonID", PersonID);
                result = (int)Command.ExecuteScalar();
            }
            return result > 0;
        }
    }
}
