using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Sales
{
    public class SalesResult
    {
        public string Name { get; set; }
        public List<SalesResultItem> SaleLines { get; set; }
        public string Status { get; set; }

        public void CheckSalesError()
        {

        }


    }
}
