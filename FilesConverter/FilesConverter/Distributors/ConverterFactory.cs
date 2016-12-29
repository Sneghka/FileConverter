using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Distributors
{
    public class ConverterFactory
    {

        private string _customer;
        private DateTime _date;


        public ConverterFactory(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }
        
        public ISalesConverter GetConverter(string filename)
        {
            if (filename.Contains("Badm") && (filename.Contains("Sales")|| filename.Contains("sales"))) return new BadmSalesConverter(_date, _customer);
            if (filename.Contains("Farmaco") && (filename.Contains("Sales") || filename.Contains("sales"))) return new FarmacoSalesConverter(_date, _customer);
            if (filename.Contains("Framko") && (filename.Contains("Sales") || filename.Contains("sales"))) return new FramkoSalesConverter(_date, _customer);
            if (filename.Contains("Optima") && (filename.Contains("Sales") || filename.Contains("sales"))) return new OptimaSalesConverter(_date, _customer);
            if (filename.Contains("Venta") && (filename.Contains("Sales") || filename.Contains("sales"))) return new VentaSalesConverter(_date, _customer);
            if (filename.Contains("PharmPlaneta") && (filename.Contains("Sales") || filename.Contains("sales"))) return new PharmPlanetaNSalesConverter(_date, _customer);
            return null;
        }
    }
}
