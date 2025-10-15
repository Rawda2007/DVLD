using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using Entity;
namespace DVLD_Buisness
{
    public class clsPeople
    {
        static public DataTable GetAllPeople()
        {
            return clsPeoples.GetAllPeople();
        }
        static public int AddPerson(People entity)
        {
            return clsPeoples.AddPerson(entity);
        }
        public static bool DeletePerson(int personID)
        {
            return clsPeoples.DeletePerson(personID);
        }
        public static bool CheckNational(string national)
        {
            return clsPeoples.CheckNational(national);
        }
        public static People GetPerson(int personID)
        {
            return clsPeoples.GetPerson(personID);
        }
        public static bool EditPerson(People entity)
        {
            return clsPeoples.EditPerson(entity);
        }
        //public static DataTable FilterBy(string Query)
        //{
        //    return DAL.FilterBy(Query);
        //}
        public static int GetPersonIDByNational(string national)
        {
            return clsPeoples.GetPersonIDByNational(national);
        }

        public static bool IsExist(int personID)
        {
           return clsPeoples.IsExist(personID);
        }
    }
}
