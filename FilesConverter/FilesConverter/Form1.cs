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
using FilesConverter.Rules;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;


namespace FilesConverter
{
    public partial class Form1 : Form
    {

        private List<ExchangeRule> _rules = new List<ExchangeRule>();
        private List<List<SalesResultItem>> _convertedReportList = new List<List<SalesResultItem>>();
        private List<string> _incorrectFilesNameSales = new List<string>();
        private List<string> _correctFilesNameSales = new List<string>();
        private string _pathForSaving = string.Empty;

        public void CheckAndConvertSalesFiles(List<string> salesFile)
        {
            int i = 1;
            int j = 1;
            var factory = new ConverterFactory(dateTimePicker1.Value, boxCustomer.Text);

            foreach (var file in salesFile)
            {
                var converter = factory.GetConverter(file);
                if (converter == null)
                {
                    _incorrectFilesNameSales.Add(j + ") " + file + " - некорректное имя файла");
                    continue;
                }
                var newResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");
                _convertedReportList.Add(newResult);
                _correctFilesNameSales.Add(i + ") " + file + " - загружен");

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnUploadSales_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel files | *.xls; *.xlsx";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string> pathsList = (from f in dialog.FileNames
                                          select f).ToList();

                CheckAndConvertSalesFiles(pathsList);

                listBox1.DataSource = _incorrectFilesNameSales; // временно для проверки
                listBox2.DataSource = _correctFilesNameSales;
            }
        }

        private void btnChooseFolderForSaving_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                textBox1.Text = path;
                _pathForSaving = path;
            }
        }

        private void btnChangeNameAndSave_Click(object sender, EventArgs e)
        {
            if (_rules.Count == 0)
            {
                DialogResult cancel = new DialogResult();
                cancel = MessageBox.Show(
                    "Файл с заменами наименований препаратов не загружен или не содержит записей. Файлы будут конвертированы без замены наименований препаратов.", "Внимание!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (cancel == DialogResult.Cancel)
                {
                    Close();
                  //????? как остановить выполнение метода ??? чтобы была возможность догрузить файл правил?
                }
            }

            for (int i = 0; i < _convertedReportList.Count; i++)
            {
                int j = 1;


                if (_rules.Count != 0)
                {
                    Helper.ChangeItemName(_rules, _convertedReportList[i]);
                }
                WorkWithExcel.WriteDataToExcel(_convertedReportList[i], _pathForSaving + @"\SalesConverted_" + j + ".xls");
                j++;
            }

            this.Controls.Clear();
            this.InitializeComponent();
            _convertedReportList.Clear();
            _rules.Clear();
            _pathForSaving = string.Empty;
            _incorrectFilesNameSales.Clear();
            _correctFilesNameSales.Clear();
        }


        private void btnUploadRules_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel files | *.xls; *.xlsx";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                textBoxRulesPath.Text = path;
                ExchangeRuleList ruleList = new ExchangeRuleList();
                _rules = ruleList.GetChangingRules(path, "select * from [Sheet1$]");
            }


        }

        private void boxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCustomer.Text.Length > 0)
                btnUploadSales.Enabled = true;
        }
    }
}


