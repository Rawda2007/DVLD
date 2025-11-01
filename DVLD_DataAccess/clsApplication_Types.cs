using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplication_Types
    {
        public static DataTable GetAllApplicationTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();

                    string Query = "SELECT * FROM ApplicationTypes";
                    SqlCommand command = new SqlCommand(Query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        reader.Close();
                        return dataTable;
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving application types: " + ex.Message);
            }
        }

        public static DataTable GetApplicationByID(int ID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        reader.Close();
                        return dataTable;
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new DataTable();
        }

        public static bool ChangeFees(int ID,decimal fees)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
                {
                    connection.Open();
                    string Query = "UPDATE ApplicationTypes SET ApplicationFees = @Fees WHERE ApplicationTypeID = @ID";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@Fees", fees);
                    command.Parameters.AddWithValue("@ID", ID);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static int FeesTypeByTypeID(int TypeID)
        {
            int FeesType = 0;
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = @"select ApplicationFees from ApplicationTypes
                                 where ApplicationTypeID=@TypeID ";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@TypeID", TypeID);
                FeesType=Convert.ToInt32(command.ExecuteScalar());
            }
            return FeesType;
            }
    }
}
