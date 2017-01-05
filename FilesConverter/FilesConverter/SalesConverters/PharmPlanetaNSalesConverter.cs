using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class PharmPlanetaNSalesConverter : BaseConverter, ISalesConverter
    {
        public PharmPlanetaNSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область1,Город1,Наименование,Артикул МЦ, ОКПО,НаимКлиента_,Адрес1,К-во";
        }

        protected override List<SalesResultItem> ConvertRows(DataTable salesReport)
        {
            var property = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = _customer,
                    Distributor = "Фармпланета",
                    Region = row["Область1"].ToString(), // из столбца F
                    City = row["Город1"].ToString(), // из столбца "G"
                    Date = _date.Date,
                    ItemName = row["Наименование"].ToString(),
                    ItemCode = row["Артикул МЦ"].ToString(),
                    OKPO = row[" ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["НаимКлиента_"] + " " + row["Адрес1"], //"Адрес" (из столбца "Н")
                    Upakovki = Convert.ToInt32(row["К-во"])
                };
                property.Add(storedSalesRow);
            }
            return property;
        }
    }
}
