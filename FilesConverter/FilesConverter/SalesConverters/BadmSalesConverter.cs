﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FilesConverter.Sales;
using DataTable = System.Data.DataTable;

namespace FilesConverter.SalesConverters
{
    public class BadmSalesConverter : BaseConverter, ISalesConverter
    {
        public BadmSalesConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО клиента,Клиент,Факт#адрес доставки,Количество";
        }

        protected override  List<SalesResultItem> ConvertRows(DataTable salesReport)
        {
            var property = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = _customer,
                    Distributor = "БаДМ",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО клиента"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Факт#адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                property.Add(storedSalesRow);
            }
            return property;
        }
    }
}
