using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FilesConverter.Errors;
using FilesConverter.Result;

namespace FilesConverter.Sales
{
    public class SalesResultItem : IResultItem
    {

        public string Customer { get; set; }
        public string Distributor { get; set; }
        public string Month
        {
            get { return Date.ToString("MMMM"); }   // в таблице идёт в колонке под названием Период
        }
        public int Year
        {
            get { return Date.Year; }
        }
        public string ItemName { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string OKPO { get; set; }
        public string DistributorsClientPlusAdress { get; set; }
        public DateTime Date { get; set; }
        public string ItemCode { get; set; }
        public int? Upakovki { get; set; }


        public string LineErrorMessage()
        {
           var messageList = new List<string>();
            var errorMessage = string.Empty;

            if (Upakovki == null)
            {
                messageList.Add(Constants.UpakovkiCellIsEmpty);
            }
            if ((Region?.Length ?? 0) < 2 || !Regex.IsMatch(Region, @"[a-zA-Zа-яА-ЯіІїЇєЄ]{2,}"))
            // @"^[a-zA-Zа-яА-ЯіІїЇєЄ.()\s.-]+$"
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
