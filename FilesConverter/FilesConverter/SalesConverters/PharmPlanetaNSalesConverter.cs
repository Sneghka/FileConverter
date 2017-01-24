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
            ColumnNames = "Область1,Город1,Наименование,Артикул МЦ, ОКПО,НаимКлиента\n,Адрес1,К-во,Производитель";
            Request = "select * from [Отчет о продажах поставщика дет$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                decimal i;
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "Фармпланета",
                    Region = row["Область1"].ToString(), // из столбца F
                    City = row["Город1"].ToString(), // из столбца "G"
                    Date = Date.Date,
                    ItemName = row["Наименование"] + " " + row["Производитель"],
                    /*ItemCode = row["Артикул МЦ"].ToString(),*/
                    OKPO = row[" ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["НаимКлиента\n"] + " " + row["Адрес1"], //"Адрес" (из столбца "Н")
                    Upakovki = decimal.TryParse(row["К-во"].ToString(), out i) ? i : (decimal?)null
                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
