using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Rules
{
    public class ExchangeRuleList : List<ExchangeRule>
    {

        public List<ExchangeRule> GetChangingRules(string path, string request)
        {
            List<ExchangeRule> rules = new List<ExchangeRule>();
            var changes = new DataTable();
            WorkWithExcel.ExcelFileToDataTable(out changes, path, request);
            foreach (DataRow row in changes.Rows)
            {
                var rule = new ExchangeRule
                {
                    OldName = row["Исходное наименование товара"].ToString(),
                    NewName = row["Заменить на"].ToString(),
                };
                rules.Add(rule);
            }

            return rules;
        }
    }
}
