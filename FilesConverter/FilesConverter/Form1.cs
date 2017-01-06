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
        private SalesResultList _salesResultList = new SalesResultList();

        public void ClearForm()
        {
            _salesResultList.ResultList.Clear();
            _salesResultList.PathForSaving = string.Empty;
            Controls.Clear();
            InitializeComponent();
            _rules.Clear();
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
                
                var convertFiles = new ConvertFiles();
                _salesResultList.ResultList = convertFiles.ConvertSalesFiles(pathsList, dateTimePicker1.Value, boxCustomer.Text);

                var gridView = new WorkWithGridView();
                gridView.AddDataToGridView(dataGridView1, _salesResultList);
             }
        }

        private void btnChooseFolderForSaving_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                textBoxFolderForSaving.Text = path;
                _salesResultList.PathForSaving = path;
            }
        }

        private void btnChangeNameAndSave_Click(object sender, EventArgs e)
        {
            if (_rules.Count == 0)
            {
                DialogResult cancel = new DialogResult();
                cancel = MessageBox.Show(Constants.RulesNotUpload, "Внимание!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (cancel == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (string.IsNullOrEmpty(textBoxFolderForSaving.Text))
            {
                DialogResult ok = new DialogResult();
                ok = MessageBox.Show(Constants.FolderForSavingIsnotChoosen, "Внимание!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ok == DialogResult.OK)
                {
                    return;
                }
              
            }

            var convertedFiles = _salesResultList.ResultList;
            for (int i = 0; i < convertedFiles.Count; i++)
            {
                
                if (_rules.Count != 0)
                {
                    Helper.ChangeItemName(_rules, convertedFiles[i].SaleLines);
                }

                var chosenFolder = textBoxFolderForSaving.Text;
                var pathForSaving =Path.Combine(chosenFolder, convertedFiles[i].Name);
                if(convertedFiles[i].SaleLines != null) WorkWithExcel.WriteDataToExcel(convertedFiles[i].SaleLines, pathForSaving);

            }

           ClearForm();
            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxFolderForSaving_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}


