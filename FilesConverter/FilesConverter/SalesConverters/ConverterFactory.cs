using System;
using FilesConverter.StocksConverter;

namespace FilesConverter.SalesConverters
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
        
        public ICommonConverter GetConverter(string filename)
        {
            var filenameSmall = filename.ToLower();
            if (filenameSmall.IndexOf("badm") != -1 && filenameSmall.IndexOf("sales") != -1 ) return new BadmSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("farmaco") != -1 &&  filenameSmall.IndexOf("sales") != -1) return new FarmacoSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("framko") != - 1 && filenameSmall.IndexOf("sales") != -1) return new FramkoSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("optima") != -1 && filenameSmall.IndexOf("sales") != -1) return new OptimaSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("venta") != -1 && filenameSmall.IndexOf("sales") != -1) return new VentaSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("pharmplaneta") != -1 && filenameSmall.IndexOf("sales") != -1) return new PharmPlanetaNSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("badm") != -1 && filenameSmall.IndexOf("stocks") != -1) return new BadmStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("optima") != -1 && filenameSmall.IndexOf("stocks") != -1) return new OptimaStocksConverter(_date, _customer);

            return null;
        }
    }
}
