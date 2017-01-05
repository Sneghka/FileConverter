using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class VentaSalesConverter : BaseConverter, ISalesConverter
    {

        public VentaSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,Окпо,Клиент,Адрес дост#,Количество";
        }

        protected override List<SalesResultItem> ConvertRows(DataTable salesReport)
        {
            var property = new List<SalesResultItem>();
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
                property.Add(storedSalesRow);
            }
            return property;
        }
    }
}
