using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using FilesConverter.Result;
using FilesConverter.Sales;
using FilesConverter.Stock;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace FilesConverter
{
    public static class WorkWithExcel
    {
        public static void ExcelFileToDataTable(out DataTable dtData, string path/*, string sRequest*/)
        {
            DataSet dsData = new DataSet();

            string sConnStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"{1};HDR=No;IMEX=1;\";", path, path.EndsWith(".xlsx") ? "Excel 12.0 Xml" : "Excel 8.0");
            using (OleDbConnection connection = new OleDbConnection(sConnStr))
            {
                connection.Open();

                var dtSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                var sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");

                OleDbCommand command = new OleDbCommand($"Select * from [{sheet1}]", connection);
                
                //OleDbCommand command = new OleDbCommand(sRequest, connection);
                using (OleDbDataAdapter oddaAdapter = new OleDbDataAdapter(command))
                {
                    oddaAdapter.Fill(dsData);
                }
                connection.Close();
            }

            dtData = dsData.Tables[0];
        }

        public static void WriteDataToExcel(List<IResultItem> list, string path)
        {
            Application myApp = new Application();
            myApp.Visible = false;

            Workbook wb = myApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            PropertyInfo[] properties = list[0].GetType().GetProperties();

            int i = 1;
            foreach (var property in properties)
            {
                if (!Attribute.IsDefined(property, typeof(ExcelColumnAttribute))) continue;
                var attrs = property.GetCustomAttributes(true);
                foreach (var attr in attrs) 
                {
                    ExcelColumnAttribute attrColName1 = attr as ExcelColumnAttribute;
                    if (attrColName1 != null)
                    {
                        ws.Cells[1, i] = attrColName1.Name;
                    }
                }
                i++;
            }

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

            Range c1 = (Range)ws.Cells[topRow, 1];
            Range c2 = (Range)ws.Cells[topRow + list.Count - 1, properties.Length];
            Range range = ws.get_Range(c1, c2);
            range.Value = arr;

            wb.SaveAs(path, XlFileFormat.xlAddIn8);
            wb.Close(XlSaveAction.xlSaveChanges, Type.Missing, Type.Missing);
            myApp.Quit();
        }
    }
}
