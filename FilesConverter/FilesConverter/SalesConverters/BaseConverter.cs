using System;

namespace FilesConverter.SalesConverters
{
    public class BaseConverter
    {
        public string _customer;
        public DateTime _date;


        public BaseConverter(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }
    }
}
