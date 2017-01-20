using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Result;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class FarmacoSalesConverter :  BaseConverter, ICommonConverter
    {
        public FarmacoSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Наименование товара,ОКПО покупателя,Покупатель,Адрес доставки,Количество проданных уп#";
            Request = "select * from [report_202$]";
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
                    Distributor = "Фармако",
                    Region = row["Область"].ToString(),
                    Date = Date.Date,
                    ItemName = row["Наименование товара"].ToString(),
                    OKPO = row["ОКПО покупателя"].ToString(),
                    DistributorsClientPlusAdress = row["Покупатель"] + " " + row["Адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество проданных уп#"])
                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;

        }
    }
}
