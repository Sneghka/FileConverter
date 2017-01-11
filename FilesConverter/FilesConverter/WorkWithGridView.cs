using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Sales;

namespace FilesConverter
{
    public class WorkWithGridView
    {
        public void AddDataToGridView(DataGridView dataGridView1, SalesResultList resultListList)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = resultListList.ResultList;
           
            dataGridView1.Refresh();
            //dataGridView1.Rows[i].Cells[2].Style.ForeColor = convertedFile.IsSuccess ? Color.Green : Color.Red;





            /*   for (int i = 0; i < resultListList.ResultList.Count; i++)
               {
                   var convertedFile = resultListList.ResultList[i];
                   dataGridView1.Rows.Add();
                   dataGridView1.Rows[i].Cells[0].Value = i + 1;
                   dataGridView1.Rows[i].Cells[1].Value = convertedFile.FilePath;
                   dataGridView1.Rows[i].Cells[2].Value = convertedFile.Status;
                   dataGridView1.Rows[i].Cells[3].Value = convertedFile.GlobalErrorMessage;

                   dataGridView1.Rows[i].Cells[2].Style.ForeColor = convertedFile.IsSuccess ? Color.Green : Color.Red;

               }*/
        }
    }
}
