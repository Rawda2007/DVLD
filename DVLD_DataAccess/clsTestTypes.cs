using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypes
    {
        public static DataTable GetAllTestTypes()

        {
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = "select ID=TestTypeID,Title=TestTypeTitle,Description=TestTypeDescription,Fees=TestTypeFees from TestTypes";
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
                else
                {
                    return new DataTable();
                }
            }
        }
        public static bool ChangeFees(int ID, decimal fees)
        {
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = "UPDATE TestTypes SET TestTypeFees = @Fees WHERE TestTypeID = @ID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Fees", fees);
                command.Parameters.AddWithValue("@ID", ID);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }

        }

        public static DataTable GetInfoTestByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                connection.Open();
                string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @ID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
                else
                {
                    return new DataTable();
                }
            }
        }
    }
    }
