using System;
using FilesConverter.Stock;
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
        
        public ICommonConverter GetConverter(string filename, string directoryName)
        {
            var filenameSmall = filename.ToLower();
            var directoryNameSmall = directoryName.ToLower();

            if (filenameSmall.IndexOf("badm") != -1 && directoryNameSmall.IndexOf("sales") != -1 ) return new BadmSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("farmaco") != -1 && directoryNameSmall.IndexOf("sales") != -1) return new FarmacoSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("framko") != - 1 && directoryNameSmall.IndexOf("sales") != -1) return new FramkoSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("optima") != -1 && directoryNameSmall.IndexOf("sales") != -1) return new OptimaSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("venta") != -1 && directoryNameSmall.IndexOf("sales") != -1) return new VentaSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("pharmplaneta") != -1 && directoryNameSmall.IndexOf("sales") != -1) return new PharmPlanetaNSalesConverter(_date, _customer);
            if (filenameSmall.IndexOf("badm") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new BadmStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("optima") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new OptimaStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("framko") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new FramkoStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("venta") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new VentaStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("pharmplaneta") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new PharmPlanetaNStocksConverter(_date, _customer);
            if (filenameSmall.IndexOf("farmaco") != -1 && directoryNameSmall.IndexOf("stock") != -1) return new FarmacoStocksConverter(_date, _customer);

            return null;
        }
    }
}
