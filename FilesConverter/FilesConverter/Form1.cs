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
        private List<SalesResultItem> _storedSalesBadm = new List<SalesResultItem>();
        private List<SalesResultItem> _storedSalesFarmaco = new List<SalesResultItem>();
        private List<SalesResultItem> _storedSalesFramko = new List<SalesResultItem>();
        private List<List<SalesResultItem>> _convertedReportList = new List<List<SalesResultItem>>();

        private List<string> incorrectFilesNameSales = new List<string>();
        private List<string> correctFilesNameSales = new List<string>();

        public void CheckAndConvertSalesFiles(List<string> salesFile)
        {
            int i = 1;
            int j = 1;
            var factory = new ConverterFactory(dateTimePicker1.Value, comboBox1.Text);

            foreach (var file in salesFile)
            {
                var converter = factory.GetConverter(file);
                if (converter == null)
                {
                    incorrectFilesNameSales.Add(j + ") " + file + " - некорректное имя файла");
                    continue;
                }
                var newResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");
                _convertedReportList.Add(newResult);
            }
        }

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
            dialog.Filter = "Excel files | *.xls; *.xlsx"; 
            dialog.Multiselect = true; 
            if (dialog.ShowDialog() == DialogResult.OK) 
            {
                List<string> pathsList = (from f in dialog.FileNames
                                          select f).ToList(); 

                CheckAndConvertSalesFiles(pathsList);

                listBox1.DataSource = incorrectFilesNameSales; // временно для проверки
                listBox2.DataSource = correctFilesNameSales;
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
            for (int i = 0; i < _convertedReportList.Count; i++)
            {
                int j = 1;
                WorkWithExcel.WriteDataToExcel(_convertedReportList[i], @"C:\Users\snizhana.nomirovska\Desktop\Jonson\Project\Converted Files\SalesConverted_"+ j + ".xls");
                j++;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


