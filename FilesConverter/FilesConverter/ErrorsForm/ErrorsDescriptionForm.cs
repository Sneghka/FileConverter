using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Errors;
using FilesConverter.Result;
using FilesConverter.Sales;
using Microsoft.Office.Interop.Excel;

namespace FilesConverter.ErrorsForm
{
    public partial class ErrorsDescriptionForm : Form
    {
        private List<ConvertationError> _errorList;
        /*private ConvertationError _error;
        private string _globalErrorMessage;*/

        public ErrorsDescriptionForm(CommonResult selectedResult)
        {
            InitializeComponent();
            dataGridViewErrors.AutoGenerateColumns = false;
            Init(selectedResult);

        }

        private void Init(CommonResult selectedResult)
        {
            InitErrors(selectedResult);
        }

        private void InitErrors(CommonResult selectedResult)
        {
            _errorList = selectedResult.ErrorMessageList;
            dataGridViewErrors.DataSource = _errorList;
        }

        public static void Show(CommonResult selectedResult)
        {
            var form = new ErrorsDescriptionForm(selectedResult);
            form.ShowDialog();
        }

        private void buttonCloseErrorForm_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }



    }
}
