using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using FilesConverter.Distributors;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;



namespace FilesConverter
{
    public static class WorkWithExcel
    {
        public static void ExcelFileToDataTable(out DataTable dtData, string path, string sRequest)
        {
            DataSet dsData = new DataSet();

            string sConnStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"{1};HDR=Yes\";", path, path.EndsWith(".xlsx") ? "Excel 12.0 Xml" : "Excel 8.0");
            using (OleDbConnection connection = new OleDbConnection(sConnStr))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sRequest, connection);
                using (OleDbDataAdapter oddaAdapter = new OleDbDataAdapter(command))
                {
                    oddaAdapter.Fill(dsData);
                }
                connection.Close();
            }
            dtData = dsData.Tables[0];
        }

        public static void WriteDataToExcel(List<SalesResultItem> list, string path)
        {
            Excel.Application myApp = new Excel.Application();
            myApp.Visible = false;

            /* Excel.Workbook wb = myApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);*/
            Excel.Workbook wb = myApp.Workbooks.Add(@"C:\Users\snizhana.nomirovska\Desktop\Jonson\SalesTemplate.xls");
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            for (int i = 0; i < list.Count; i++)
            /* for (int i = 0; i < 10; i++)*/
            {
                ws.Cells[i + 2, 1] = list[i].Customer;
                ws.Cells[i + 2, 2] = list[i].Distributor;
                ws.Cells[i + 2, 3] = list[i].Month;
                ws.Cells[i + 2, 4] = list[i].Year;
                ws.Cells[i + 2, 5] = list[i].ItemName;
                ws.Cells[i + 2, 6] = list[i].Region;
                ws.Cells[i + 2, 7] = list[i].City;
                ws.Cells[i + 2, 8] = list[i].OKPO;
                ws.Cells[i + 2, 9] = list[i].DistributorsClientPlusAdress;
                ws.Cells[i + 2, 10] = list[i].Date;
                ws.Cells[i + 2, 11] = list[i].ItemCode;
                ws.Cells[i + 2, 12] = list[i].Upakovki;
            }

            wb.SaveAs(path);
            wb.Close(Excel.XlSaveAction.xlSaveChanges, Type.Missing, Type.Missing);
            myApp.Quit();
        }
    }
}
