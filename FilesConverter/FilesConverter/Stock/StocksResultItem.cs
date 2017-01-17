﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;

namespace FilesConverter.Stock
{
    public class StocksResultItem : IResultItem
    {
        public const string ExcelColumnsName = "Заказчик,Дистрибьютор,Период,Год,Наименование товара,Код товара,Адрес склада,Дата,Остаток";

        public string Customer { get; set; }
        public string Distributor { get; set; }
        public string Month => Date.ToString("MMMM");

        public int Year => Date.Year;
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string AdressSklada { get; set; }
        public DateTime Date { get; set; }
        public int? Upakovki { get; set; }
       // public string ExcelColumnsName => "Заказчик,Дистрибьютор,Период,Год,Наименование товара,Код товара,Адрес склада,Дата,Остаток";


      
        public string LineErrorMessage()
        {
            var errorMessage = string.Empty;

            return errorMessage;

        }

        public string[] GetColunmsNameForExcel()
        {
            return ExcelColumnsName.Split(',');
        }

    }
}
