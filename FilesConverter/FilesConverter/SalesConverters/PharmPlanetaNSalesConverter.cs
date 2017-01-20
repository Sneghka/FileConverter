using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Result;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class PharmPlanetaNSalesConverter : BaseConverter, ICommonConverter
    {
        public PharmPlanetaNSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область1,Город1,Наименование,Артикул МЦ, ОКПО,НаимКлиента_,Адрес1,К-во";
            Request = "select * from [Отчет о продажах поставщика дет$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "Фармпланета",
                    Region = row["Область1"].ToString(), // из столбца F
                    City = row["Город1"].ToString(), // из столбца "G"
                    Date = Date.Date,
                    ItemName = row["Наименование"].ToString(),
                    ItemCode = row["Артикул МЦ"].ToString(),
                    OKPO = row[" ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["НаимКлиента_"] + " " + row["Адрес1"], //"Адрес" (из столбца "Н")
                    Upakovki = Convert.ToInt32(row["К-во"])
                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
