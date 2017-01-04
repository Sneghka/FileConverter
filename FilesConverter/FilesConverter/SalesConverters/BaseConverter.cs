using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesConverter.SalesConverters
{
    public class BaseConverter
    {
        public string _customer;
        public DateTime _date;
        public string ColumnNames { get; set; }
      /*  public List<string> IncorrectColumnNamesList { get; set; }*/

        public BaseConverter(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }

        public List<string> CheckColumnNames(string[] dtColumnNames)
        {
            List<string> colNamesNotFound = new List<string>();
            string[] colListOfClass = ColumnNames.Split(',');

            foreach (var col in colListOfClass)
            
            {
                if (!dtColumnNames.Contains(col))
                {
                    colNamesNotFound.Add(col);
                }
            }
            return colNamesNotFound;
        }
    }
}
