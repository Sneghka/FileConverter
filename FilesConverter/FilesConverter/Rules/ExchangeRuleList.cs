using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Sales;

namespace FilesConverter.Rules
{
    public class ExchangeRuleList
    {

        public List<ExchangeRule> GetChangingRules(string path, string request)
        {
            List<ExchangeRule> rules = new List<ExchangeRule>();
            var changes = new DataTable();
            WorkWithExcel.ExcelFileToDataTable(out changes, path/*, request*/);

            var colQuant = changes.Columns.Count;

            for (int i = colQuant - 1; i > 1; i--)
            {
                changes.Columns.RemoveAt(i);
            }

            Helper.SetColumnsInDataTable(changes);

            foreach (DataRow row in changes.Rows)
            {
                var rule = new ExchangeRule
                {
                    OldName = row["Исходное написание"].ToString(),
                    NewName = row["заменить на"].ToString(),
                };
                rules.Add(rule);
            }

            return rules;
        }
    }
}
