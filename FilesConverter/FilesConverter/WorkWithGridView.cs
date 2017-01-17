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
        public void AddDataToGridView(DataGridView dataGridView1, CommonResultList resultListList)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultListList.ResultList;
           
            
            
        }
    }
}
