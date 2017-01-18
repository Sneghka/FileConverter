using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.Rules;
using FilesConverter.Sales;

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
    }
}
