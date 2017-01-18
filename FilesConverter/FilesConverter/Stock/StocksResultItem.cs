using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilesConverter.Result;

namespace FilesConverter.Stock
{
    public class StocksResultItem : IResultItem
    {
        [ExcelColumn(Name = "Заказчик")]
        public string Customer { get; set; }

        [ExcelColumn(Name = "Дистрибьютор")]
        public string Distributor { get; set; }

        [ExcelColumn(Name = "Период")]
        public string Month => Date.ToString("MMMM");

        [ExcelColumn(Name = "Год")]
        public int Year => Date.Year;

        [ExcelColumn(Name = "Наименование товара")]
        public string ItemName { get; set; }

        [ExcelColumn(Name = "Код товара")]
        public string ItemCode { get; set; }

        [ExcelColumn(Name = "Адрес склада")]
        public string AdressSklada { get; set; }

        [ExcelColumn(Name = "Дата")]
        public DateTime Date { get; set; }

        [ExcelColumn(Name = "Остаток")]
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
            if (AdressSklada.Split(' ').Length < 2)

            {
                messageList.Add(Constants.IncorrectAdressSklada);
            }
            if (messageList.Count != 0)
            {
                errorMessage = string.Join("/", messageList);
            }
            return errorMessage;

        }
    }
}
