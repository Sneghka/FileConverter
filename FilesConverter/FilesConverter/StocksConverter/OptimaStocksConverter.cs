﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.SalesConverters;
using FilesConverter.Stock;

namespace FilesConverter.StocksConverter
{
    public class OptimaStocksConverter : BaseConverter, ICommonConverter
    {
        public OptimaStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Товар,Код товара,Винницкий филиал,Днепропетровский филиал,Запорожский филиал,Ивано-Франковский филиал,Киевский филиал,Львовский филиал,Одесский филиал,Полтавский филиал,Харьковский филиал,Центральный офис";
            Request = "select * from [Страница 1$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable stocksReport)
        {
            var columns = stocksReport.Columns;
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in stocksReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                for (int j = 2; j < columns.Count; j++)
                {
                    decimal i;
                    var filial = columns[j].Caption;
                    var storedSalesRow = new StocksResultItem
                    {
                        Customer = Customer,
                        Distributor = "Оптима",
                        AdressSklada = filial == "Центральный офис" ? "Оптима Киевский офис" : "Оптима" + " " + columns[j].Caption,
                        Date = Date.Date,
                        ItemName = row["Товар"].ToString(),
                        ItemCode = row["Код товара"].ToString(),
                        Upakovki = decimal.TryParse(row[columns[j].Caption].ToString(), out i) ? i : (decimal?)null

                    };
                    commonResultLines.Add(storedSalesRow);
                }
            }
            return commonResultLines;
        }
    }
}
