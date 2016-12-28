using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Distributors
{
   public class BadmItem 
    {
        public string ItemName { get; set; }
        public string Customer { get; set; }
        public string Distributor { get; set; }
        public string Month
        {
            get { return Date.ToString("MMMM"); }   // в таблице идёт в колонке под названием Период
        }
        public int Year
        {
            get { return Date.Year; }
        }

        public string Region { get; set; }
        public string City { get; set; }
        public string OKPO { get; set; }
        public string DistributorsClientPlusAdress { get; set; }
        public DateTime Date { get; set; }
        public string ItemCode { get; set; }
        public int Upakovki { get; set; }
    }
}
