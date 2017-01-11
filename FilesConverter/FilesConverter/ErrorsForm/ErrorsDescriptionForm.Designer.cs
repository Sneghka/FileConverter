using System.Windows.Forms;
using FilesConverter.Sales;

namespace FilesConverter.ErrorsForm
{
    partial class ErrorsDescriptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewErrors = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.Label();
            this.buttonCloseErrorForm = new System.Windows.Forms.Button();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewErrors
            // 
            this.dataGridViewErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.ErrorMessage});
            this.dataGridViewErrors.Location = new System.Drawing.Point(12, 66);
            this.dataGridViewErrors.Name = "dataGridViewErrors";
            this.dataGridViewErrors.Size = new System.Drawing.Size(602, 262);
            this.dataGridViewErrors.TabIndex = 0;
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(28, 18);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(0, 13);
            this.fileName.TabIndex = 1;
            // 
            // buttonCloseErrorForm
            // 
            this.buttonCloseErrorForm.Location = new System.Drawing.Point(507, 350);
            this.buttonCloseErrorForm.Name = "buttonCloseErrorForm";
            this.buttonCloseErrorForm.Size = new System.Drawing.Size(107, 30);
            this.buttonCloseErrorForm.TabIndex = 2;
            this.buttonCloseErrorForm.Text = "Close";
            this.buttonCloseErrorForm.UseVisualStyleBackColor = true;
            this.buttonCloseErrorForm.Click += new System.EventHandler(this.buttonCloseErrorForm_Click);
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "Row";
            this.RowNumber.Name = "RowNumber";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ErrorMessage.DataPropertyName = "ErrorMessage";
            this.ErrorMessage.HeaderText = "Error message";
            this.ErrorMessage.Name = "ErrorMessage";
            // 
            // ErrorsDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 392);
            this.Controls.Add(this.buttonCloseErrorForm);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.dataGridViewErrors);
            this.Name = "ErrorsDescriptionForm";
            this.Text = "ErrorsDescriptionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewErrors;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Button buttonCloseErrorForm;
        private DataGridViewTextBoxColumn RowNumber;
        private DataGridViewTextBoxColumn ErrorMessage;
    }
}