using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilesConverter.SalesConverters
{
    public class BaseConverter
    {
        public string _customer;
        public DateTime _date;
        public string ColumnNames { get; set; }
      

        public BaseConverter(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }

        public string CheckColumnNames(string[] dtColumnNames)
        {
            List<string> colNamesNotFound = new List<string>();
            string message = string.Empty;
            string[] colListOfClass = ColumnNames.Split(',');

            foreach (var col in colListOfClass)
            
            {
                if (!dtColumnNames.Contains(col))
                {
                    colNamesNotFound.Add(col);
                }
            }

            if (colNamesNotFound.Count > 0)
            {
                var newString = new StringBuilder();
                foreach (var col in colNamesNotFound)
                {
                    newString.Append(col + " / ");
                }
                message = "Не найдены колонки - " + newString;
            }
            return message;
        }
    }
}
