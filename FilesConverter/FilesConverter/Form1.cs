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
using FilesConverter.ErrorsForm;
using FilesConverter.Result;
using FilesConverter.Rules;
using FilesConverter.Sales;
using System.Reflection;
using FilesConverter.SalesConverters;


namespace FilesConverter
{
    public partial class Form1 : Form
    {
        private CommonResult _selectedResult;
        private CommonResult SelectedResult
        {
            get
            {
                return _selectedResult;
            }
        }
        private List<ExchangeRule> _rules = new List<ExchangeRule>();
        private CommonResultList _commonResultList = new CommonResultList();

        public void ClearForm()
        {
            _commonResultList.ResultList.Clear();
            _commonResultList.PathForSaving = string.Empty;
            Controls.Clear();
            InitializeComponent();
            _rules.Clear();
        }

        public void RemoveDuplicateCommonResul(List<string> pathsList)
        {
            if (_commonResultList.ResultList == null) return;

            foreach (var path in pathsList)
            {
                for (int i = _commonResultList.ResultList.Count - 1; i >= 0; i--)
                {
                    if (path == _commonResultList.ResultList[i].FilePath) _commonResultList.ResultList.Remove(_commonResultList.ResultList[i]);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Today)
            {
                dateTimePicker1.Value = DateTime.Today;
                DialogResult ok = new DialogResult();
                ok = MessageBox.Show(Constants.IncorrectDate, "Внимание!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ok == DialogResult.OK)
                {
                    return;
                }
            }

            if (_commonResultList.ResultList != null)
            {
                foreach (var salesResult in _commonResultList.ResultList)
                {
                    salesResult.ChangeDate(dateTimePicker1.Value);
                }
            }
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

                RemoveDuplicateCommonResul(pathsList);

                var convertFiles = new ConvertFiles();

                _commonResultList.ResultList.AddRange(convertFiles.ConvertSalesFiles(pathsList, dateTimePicker1.Value, boxCustomer.Text, progressBar1, statusBar1));

                var gridView = new WorkWithGridView();
                gridView.AddDataToGridView(dataGridView1, _commonResultList);
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
                _commonResultList.PathForSaving = path;
            }
        }

        private void btnChangeNameAndSave_Click(object sender, EventArgs e)
        {
            foreach (var commonResult in _commonResultList.ResultList)
            {
                commonResult.FolderForSaving = _commonResultList.PathForSaving;
            }

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
                ok = MessageBox.Show(Constants.FolderForSavingIsnotChoosen, "Внимание!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (ok == DialogResult.Cancel) return;
            }

            var convertedFiles = _commonResultList.ResultList;
            var convertFiles = new ConvertFiles();

            convertFiles.SendResultToExcel(convertedFiles, _rules, progressBar1, statusBar1);

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
            if (boxCustomer.Text.Length > 0) btnUploadSales.Enabled = true;
            if (_commonResultList.ResultList != null)
            {
                foreach (var salesResult in _commonResultList.ResultList)
                {
                    salesResult.ChangeCustomer(boxCustomer.Text);
                }
            }
        }

        private void textBoxFolderForSaving_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            _selectedResult = (CommonResult)dataGridView1.SelectedRows[0].DataBoundItem;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedResult == null) return;
            if (SelectedResult.IsSuccess) return;
            if (SelectedResult.ErrorMessageList == null) return;
            ErrorsDescriptionForm.Show(SelectedResult);
        }
    }
}


