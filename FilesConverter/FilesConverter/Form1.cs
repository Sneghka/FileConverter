using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Distributors;


namespace FilesConverter
{
    public partial class Form1 : Form
    {
        private List<SalesResultItem> storedSalesBadm = new List<SalesResultItem>();
        private List<SalesResultItem> storedSalesFarmaco = new List<SalesResultItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel files | *.xls; *.xlsx"; // file types, that will be allowed to upload
            dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                List<string> pathsList = (from f in dialog.FileNames
                                          select f).ToList(); // get name of file

                label6.Text = pathsList[0];

                foreach (var file in pathsList)
                {
                    //проверка имени файла для генерации экземпляра нужного класса
                    if (file.Contains("Badm"))
                    {
                        var badm = new BadmSalesConverter();
                        storedSalesBadm = badm.ConvertSalesReport(file, "select * from [Sheet1$]");
                    }

                    if (file.Contains("Farmaco"))
                    {
                        var farmaco = new FarmacoSalesConverter();
                        storedSalesFarmaco = farmaco.ConvertSalesReport(file, "select * from [Sheet1$]");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                textBox1.Text = path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var badm = new BadmSalesConverter();
            badm.WriteDataToExcel(storedSalesBadm);

            var farmaco = new FarmacoSalesConverter();
            farmaco.WriteDataToExcel(storedSalesFarmaco);

        }
    }
}
