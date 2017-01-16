﻿using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class FramkoSalesConverter : BaseConverter, ISalesConverter
    {

        public FramkoSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,КодОКПО,Клиент,Улица,Количество";
            Request = "select * from [Клиентский отчет$]";
        }

        protected override List<SalesResultItem> ConvertRows(DataTable salesReport)
        {
            var property = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "Фрамко",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                    OKPO = row["КодОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Улица"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                property.Add(storedSalesRow);
            }
            return property;
        }
    }
}
