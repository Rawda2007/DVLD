using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPeoples
    {
        static public DataTable GetAllPeople()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string query = @"
        SELECT p.PersonID,
               p.NationalNo,
               p.FirstName,
               p.SecondName,
               p.ThirdName,
               p.LastName,
               p.DateOfBirth,
               p.Gendor,
               c.CountryName AS Nationality,
               p.Address,
               p.Phone,
               p.Email,
               p.ImagePath
        FROM People p
        JOIN Countries c 
          ON p.NationalityCountryID = c.CountryID";
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
        public static int AddPerson(People entity)
        {
            int ID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = @"INSERT INTO People (NationalNo,FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor,
                    Address, Phone,Email, NationalityCountryID, ImagePath)
                    VALUES (@NationalNo,@FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor,
                    @Address, @Phone, @Email, @NationalityCountryID, @ImagePath); select SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@NationalNo", entity.NationalNo);

                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@SecondName", entity.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", entity.ThirdName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", entity.Gendor);
                    command.Parameters.AddWithValue("@Address", entity.Address);
                    command.Parameters.AddWithValue("@Phone", entity.Phone);
                    command.Parameters.AddWithValue("@Email", entity.Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", entity.NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", entity.ImagePath);
                    ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
            }
            return ID;


        }
        
        public static bool DoPersonConnectTableElseWithApplications(int personID)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT COUNT(*) FROM Applications WHERE ApplicantPersonID=@PersonID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return true;
            }
            return count > 0;
        }

        public static bool DoPersonConnectTableElseWithDrivers(int personID)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT COUNT(*) FROM Drivers WHERE PersonID=@PersonID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return true;
            }
            return count > 0;
        }
        public static bool DeletePerson(int personID)
        {
            int result = 0;
            if (DoPersonConnectTableElseWithDrivers(personID) || DoPersonConnectTableElseWithApplications(personID))
            {
                return false;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "DELETE FROM People WHERE PersonID=@PersonID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return false;
            }
            return result > 0;
        }
        public static bool CheckNational(string national)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT COUNT(*) FROM People WHERE NationalNo=@NationalNo";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@NationalNo", national);
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return true;
            }
            return count > 0;
        }
        //Edit
        public static People GetPerson(int personID)
        {
            People entity = null; // null لو ما فيش بيانات
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // تحريك المؤشر لأول صف
                        {
                            entity = new People(
                                Convert.ToInt32(reader[0]),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString(),
                                reader[5].ToString(),
                               Convert.ToDateTime(reader[6]),
                                Convert.ToInt32(reader[7]),
                                reader[8].ToString(),
                                reader[9].ToString(),
                                reader[10].ToString(),
                                Convert.ToInt32(reader[11]),
                                reader[12].ToString()
                            );
                        }
                    }
                }
            }
            return entity; // ممكن ترجع null لو مش لاقي
        }

        public static bool EditPerson(People entity)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = @"UPDATE People SET NationalNo=@NationalNo,FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, LastName=@LastName, DateOfBirth=@DateOfBirth, Gendor=@Gendor,
                    Address=@Address, Phone=@Phone,Email=@Email, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath
                    WHERE PersonID=@PersonID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", entity.PersonID);
                    command.Parameters.AddWithValue("@NationalNo", entity.NationalNo);
                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@SecondName", entity.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", entity.ThirdName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", entity.Gendor);
                    command.Parameters.AddWithValue("@Address", entity.Address);
                    command.Parameters.AddWithValue("@Phone", entity.Phone);
                    command.Parameters.AddWithValue("@Email", entity.Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", entity.NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", entity.ImagePath);
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return false;
            }
            return result > 0;
        }
        //public static DataTable FilterBy(string Query)
        //{
        //    DataTable dt1 = GetAllPeople();
        //    DataRow[] dataRows = dt1.Select(Query, "PersonID DESC");//Array
        //    if (dataRows.Length > 0)
        //        return dataRows.CopyToDataTable();
        //    else
        //        return dt1.Clone(); //يرجع نفس هيكل الجدول فاضي
        //}

        public static int GetPersonIDByNational(string national)
        {
            int personID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT PersonID FROM People WHERE NationalNo=@NationalNo";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@NationalNo", national);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        personID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
            }
            return personID;
        }

        public static bool IsExist(int personID)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT COUNT(*) FROM People WHERE PersonID=@PersonID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.Message));
                return false;
            }
            return count > 0;
        }
    }
}
