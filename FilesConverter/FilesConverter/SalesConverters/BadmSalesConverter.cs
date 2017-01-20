using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FilesConverter.Result;
using FilesConverter.Sales;
using DataTable = System.Data.DataTable;

namespace FilesConverter.SalesConverters
{
    public class BadmSalesConverter : BaseConverter, ICommonConverter
    {

        public BadmSalesConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО клиента,Клиент,Факт#адрес доставки,Количество";
            Request = "select * from [Badm$]";
        }

        protected override  List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                int i;
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "БаДМ",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО клиента"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Факт#адрес доставки"],
                    Upakovki = int.TryParse(row["Количество"].ToString(), out i) ? i: (int?) null
                    
                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
