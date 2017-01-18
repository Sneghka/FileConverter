using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FilesConverter.Errors;
using FilesConverter.Result;

namespace FilesConverter.Sales
{
    public class SalesResultItem : IResultItem
    {
        
        [ExcelColumn(Name = "Заказчик")]
        public string Customer { get; set; }
        [ExcelColumn(Name = "Дистрибьютор")]
        public string Distributor { get; set; }
        [ExcelColumn(Name = "Период")]
        public string Month
        {
            get { return Date.ToString("MMMM"); }  
        }
        [ExcelColumn(Name = "Год")]
        public int Year
        {
            get { return Date.Year; }
        }
        [ExcelColumn(Name = "Товар")]
        public string ItemName { get; set; }
        [ExcelColumn(Name = "Область")]
        public string Region { get; set; }
        [ExcelColumn(Name = "Город")]
        public string City { get; set; }
        [ExcelColumn(Name = "Код ОКПО")]
        public string OKPO { get; set; }
        [ExcelColumn(Name = "Клиент с адресом")]
        public string DistributorsClientPlusAdress { get; set; }
        [ExcelColumn(Name = "Дата")]
        public DateTime Date { get; set; }
        [ExcelColumn(Name = "Код товара")]
        public string ItemCode { get; set; }
        [ExcelColumn(Name = "Кол-во упаковок")]
        public int? Upakovki { get; set; }




        public string GetLineErrorMessage()
        {
            var messageList = new List<string>();
            var errorMessage = string.Empty;

            if (Upakovki == null)
            {
                messageList.Add(Constants.UpakovkiCellIsEmpty);
            }
            if (string.IsNullOrEmpty(ItemName))
            {
                messageList.Add(Constants.IncorrectItemName);
            }
            if ((Region?.Length ?? 0) < 2 || !Regex.IsMatch(Region, @"[a-zA-Zа-яА-ЯіІїЇєЄ]{2,}"))
            {
                messageList.Add(Constants.IncorrectRegionName);
            }
            if (Regex.IsMatch(DistributorsClientPlusAdress, "^(?!.*[a-zA-Zа-яА-ЯіІїЇєЄ]).*$"))
            // line contains gap after concat. Check if doesn't contain letters
            {
                messageList.Add(Constants.IncorrectNameAndAdress);
            }
            if (messageList.Count != 0)
            {
                errorMessage = string.Join("/", messageList);
            }
            return errorMessage;
        }
    }
}
