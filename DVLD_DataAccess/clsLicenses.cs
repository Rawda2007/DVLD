using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenses
    {
        public static DataTable GetInfoLicenseByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select *from Licenses
  where LicenseID=@ID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ID", LicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }
        //int LicenseClassID = clsLicenses.GetClassIDByNameClassLicense(ClassName);
        //DateTime IssueDate = DateTime.Now;
        //DateTime ExpirationDate = DateTime.Now.AddYears(clsLicenses.GetValidityLengthLicenseByClassName(ClassName));
        //int PaidFees = clsLicenses.GetPaidFeesByClassID(LicenseClassID);

        public static int GetClassIDByNameClassLicense(string ClassName)
        {
            int ID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" select LicenseClassID from  LicenseClasses
  where ClassName=@ClassName";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassName", ClassName);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return ID;
        }
        public static int GetValidityLengthLicenseByClassName(string ClassName)
        {
            int Length = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" select DefaultValidityLength from  LicenseClasses
  where ClassName=@ClassName";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassName", ClassName);
                Length = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Length;
        }

        public static int GetPaidFeesByClassID(int ClassID)
        {
            int Paid = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select ClassFees from  LicenseClasses
  where LicenseClassID=@ClassName";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassName", ClassID);
                Paid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Paid;
        }
        public static string GetClassNameByClassID(int ClassID)
        {
            string ClassName = "";
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"select ClassName from  LicenseClasses
  where LicenseClassID=@ClassName";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassName", ClassID);
                ClassName = (cmd.ExecuteScalar()).ToString();
            }
            return ClassName;
        }

        public static int GetLicenseIDByNational(string National, int ClassID)
        {
            int LicenseID = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @" select L.LicenseID from Applications as A
  inner join Licenses as L on L.ApplicationID=A.ApplicationID
  inner join People as P on A.ApplicantPersonID=P.PersonID
 where P.NationalNo=@National and L.LicenseClass=@ClassID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                cmd.Parameters.AddWithValue("@National", National);
                LicenseID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return LicenseID;
        }

        public static int GetFeesClassByClassID(int ClassID)
        {
            int Fees = 0;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"   select ClassFees from LicenseClasses
  where LicenseClassID=@ClassID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                Fees = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Fees;
        }

        public static bool changeActiveLicenseToNonActive(int LicenseID)
        {
            bool IsDone = false;
            using (SqlConnection conn = new SqlConnection(clsLinkConnectionDB.StringConnection))
            {
                conn.Open();
                string Query = @"    update Licenses
  set IsActive=0
  where LicenseID=@LicenseID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    IsDone = true;
                }
            }
            return IsDone;

        }
    }
}
