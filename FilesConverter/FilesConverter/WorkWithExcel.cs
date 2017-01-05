using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Reflection;
using FilesConverter.Sales;
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

            Excel.Workbook wb = myApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            /* Excel.Workbook wb = myApp.Workbooks.Add(@"C:\Users\snizhana.nomirovska\Desktop\Jonson\SalesTemplate.xls");*/
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            ws.Cells[1, 1] = "Заказчик";
            ws.Cells[1, 2] = "Дистрибьютор";
            ws.Cells[1, 3] = "Период";
            ws.Cells[1, 4] = "Год";
            ws.Cells[1, 5] = "Товар";
            ws.Cells[1, 6] = "Область";
            ws.Cells[1, 7] = "Город";
            ws.Cells[1, 8] = "Код ОКПО";
            ws.Cells[1, 9] = "Клиент с адресом";
            ws.Cells[1, 10] = "Дата";
            ws.Cells[1, 11] = "Код товара";
            ws.Cells[1, 12] = "Кол-во упаковок";

            PropertyInfo[] properties = typeof(SalesResultItem).GetProperties();
            var topRow = 2;
            object[,] arr = new object[list.Count, properties.Length];
            for (int r = 0; r < list.Count; r++)
            {
                var rowOfList = list[r];
                for (int p = 0; p < properties.Length; p++)
               {
                    arr[r, p] = properties[p].GetValue(rowOfList);
                }
            }

            Excel.Range c1 = (Excel.Range)ws.Cells[topRow, 1];
            Excel.Range c2 = (Excel.Range)ws.Cells[topRow + list.Count - 1, properties.Length];
            Excel.Range range = ws.get_Range(c1, c2);
            range.Value = arr;

            wb.SaveAs(path, Excel.XlFileFormat.xlAddIn8);
            wb.Close(Excel.XlSaveAction.xlSaveChanges, Type.Missing, Type.Missing);
            myApp.Quit();
        }
    }
}
