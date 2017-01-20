using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.Rules;




namespace FilesConverter
{
    public static class Helper
    {
        public static void ChangeItemName(List<ExchangeRule> rules, List<IResultItem> convertedFile)
        {
            for (int i = 0; i < convertedFile.Count; i++)
            {
                foreach (var rule in rules)
                {
                    if (convertedFile[i].ItemName == rule.OldName)
                    {
                        convertedFile[i].ItemName = rule.NewName;
                        break;
                    }
                }
            }
        }

        public static bool IsRowEmpty(DataRow row)
        {
            return row.ItemArray.All(item => item == DBNull.Value);
        }
        
    }
}
