using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FilesConverter.Result;
using FilesConverter.SalesConverters;

namespace FilesConverter.Sales
{
    public class CommonResultList 
    {
        public List<CommonResult> ResultList { get;} = new List<CommonResult>();
        public string PathForSaving { get; set; }

        public List<string> GetInformationForLogging()
        {
            var logStringList = new List<string>();

            foreach (var commonResult in ResultList)
            {
                logStringList.Add(commonResult.FilePath + " - " + commonResult.Status);
                if (commonResult.IsSuccess) continue;
                if (commonResult.GlobalErrorMessage != Constants.ShowErrorDetails)
                {
                    logStringList.Add("       " + commonResult.GlobalErrorMessage);
                    continue;
                }
                foreach (var error in commonResult.ErrorMessageList)
                {
                    logStringList.Add("       " + error.RowNumber + " " + error.ErrorMessage);
                }
            }





            return logStringList;
        }

    }
}
