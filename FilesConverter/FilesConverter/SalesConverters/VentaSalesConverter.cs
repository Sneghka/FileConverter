using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Result;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class VentaSalesConverter : BaseConverter, ICommonConverter
    {

        public VentaSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,Окпо,Клиент,Адрес дост#,Количество";
            Request = "select * from [Sheet1$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "Вента",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["Окпо"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Адрес дост#"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                commonResultLines.Add(storedSalesRow);
            }
            return  commonResultLines; 
        }
    }
}
