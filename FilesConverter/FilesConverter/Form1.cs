﻿using System;
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
using FilesConverter.Rules;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;


namespace FilesConverter
{
    public partial class Form1 : Form
    {
        private SalesResult _selectedResult;
        private SalesResult SelectedResult
        {
            get
            {
                return _selectedResult;
            }
        }
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

            if (_salesResultList.ResultList != null)
            {
                foreach (var salesResult in _salesResultList.ResultList)
                {
                    if (salesResult.IsSuccess)
                    {
                        foreach (var lines in salesResult.SaleLines)
                        {
                            lines.Date = dateTimePicker1.Value.Date;
                        }
                    }
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

                var convertFiles = new ConvertFiles();
                _salesResultList.ResultList = convertFiles.ConvertSalesFiles(pathsList, dateTimePicker1.Value, boxCustomer.Text); //convert to view


                foreach (var salesResult in _salesResultList.ResultList)
                {
                    if (!string.IsNullOrEmpty(salesResult.GlobalErrorMessage)) continue;
                    salesResult.ErrorMessageList = convertFiles.CheckSaleLinesErrors(salesResult); // check if neccessary cells are correct
                }
                
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
            var convertFiles = new ConvertFiles();
            convertFiles.SendResultToExcel(convertedFiles, textBoxFolderForSaving.Text, _rules);

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
            if (_salesResultList.ResultList != null)
            {
                foreach (var salesResult in _salesResultList.ResultList)
                {
                    if (salesResult.IsSuccess)
                    {
                        foreach (var lines in salesResult.SaleLines)
                        {
                            lines.Customer = boxCustomer.Text;
                        }
                    }
                }
            }
        }

        private void textBoxFolderForSaving_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            _selectedResult = (SalesResult)dataGridView1.SelectedRows[0].DataBoundItem;
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


