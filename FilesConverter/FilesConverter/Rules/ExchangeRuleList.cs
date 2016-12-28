using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Rules
{
    public class ExchangeRuleList : List<ExchangeRule>
    {
        public List<string> GetListOfNameForChanging()
        {
            return (from r in this
                    select r.OldName).ToList();
        }
    }
}
