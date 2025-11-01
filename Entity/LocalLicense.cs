using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LocalLicense
    {
       public int ID { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public string FullName
            { get; set; }
        public DateTime AppDate { get; set; }
        public int CountPassed { get; set; }
        public string Status { get; set; }

        LocalLicense(string ClassName, string NationalNo, string FullName, DateTime AppDate, int CountPassed, string Status)
        {
            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.AppDate = AppDate;
            this.CountPassed = CountPassed;
            this.Status = Status;
        }
        LocalLicense(int ID,string ClassName, string NationalNo, string FullName, DateTime AppDate, int CountPassed, string Status)
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.AppDate = AppDate;
            this.CountPassed = CountPassed;
            this.Status = Status;
        }
    }
}
