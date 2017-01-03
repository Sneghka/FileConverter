namespace FilesConverter
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.boxCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvertAndSave = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUploadSales = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChooseFolderForSaving = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBoxRulesPath = new System.Windows.Forms.TextBox();
            this.btnUploadRules = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SequenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // boxCustomer
            // 
            this.boxCustomer.DropDownHeight = 150;
            this.boxCustomer.DropDownWidth = 220;
            this.boxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boxCustomer.FormattingEnabled = true;
            this.boxCustomer.IntegralHeight = false;
            this.boxCustomer.ItemHeight = 20;
            this.boxCustomer.Items.AddRange(new object[] {
            "Джонсон и Джонсон",
            "Другое"});
            this.boxCustomer.Location = new System.Drawing.Point(184, 20);
            this.boxCustomer.MaxDropDownItems = 20;
            this.boxCustomer.Name = "boxCustomer";
            this.boxCustomer.Size = new System.Drawing.Size(226, 28);
            this.boxCustomer.TabIndex = 1;
            this.boxCustomer.SelectedIndexChanged += new System.EventHandler(this.boxCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(478, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // btnConvertAndSave
            // 
            this.btnConvertAndSave.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConvertAndSave.Location = new System.Drawing.Point(828, 573);
            this.btnConvertAndSave.Name = "btnConvertAndSave";
            this.btnConvertAndSave.Size = new System.Drawing.Size(143, 44);
            this.btnConvertAndSave.TabIndex = 4;
            this.btnConvertAndSave.Text = "Convert";
            this.btnConvertAndSave.UseVisualStyleBackColor = true;
            this.btnConvertAndSave.Click += new System.EventHandler(this.btnChangeNameAndSave_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(541, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 26);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Upload sales";
            // 
            // btnUploadSales
            // 
            this.btnUploadSales.Enabled = false;
            this.btnUploadSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadSales.Location = new System.Drawing.Point(145, 28);
            this.btnUploadSales.Name = "btnUploadSales";
            this.btnUploadSales.Size = new System.Drawing.Size(148, 31);
            this.btnUploadSales.TabIndex = 14;
            this.btnUploadSales.Text = "Choose file";
            this.btnUploadSales.UseVisualStyleBackColor = true;
            this.btnUploadSales.Click += new System.EventHandler(this.btnUploadSales_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(609, 20);
            this.textBox1.TabIndex = 17;
            // 
            // btnChooseFolderForSaving
            // 
            this.btnChooseFolderForSaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseFolderForSaving.Location = new System.Drawing.Point(665, 81);
            this.btnChooseFolderForSaving.Name = "btnChooseFolderForSaving";
            this.btnChooseFolderForSaving.Size = new System.Drawing.Size(198, 35);
            this.btnChooseFolderForSaving.TabIndex = 18;
            this.btnChooseFolderForSaving.Text = "Choose folder for saving";
            this.btnChooseFolderForSaving.UseVisualStyleBackColor = true;
            this.btnChooseFolderForSaving.Click += new System.EventHandler(this.btnChooseFolderForSaving_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(42, 189);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(929, 366);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.btnUploadSales);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(921, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Converter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(299, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "(заполните поля Customer и Date)";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(25, 79);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(890, 36);
            this.listBox2.TabIndex = 18;
            // 
            // textBoxRulesPath
            // 
            this.textBoxRulesPath.Location = new System.Drawing.Point(41, 135);
            this.textBoxRulesPath.Name = "textBoxRulesPath";
            this.textBoxRulesPath.Size = new System.Drawing.Size(609, 20);
            this.textBoxRulesPath.TabIndex = 22;
            // 
            // btnUploadRules
            // 
            this.btnUploadRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadRules.Location = new System.Drawing.Point(665, 128);
            this.btnUploadRules.Name = "btnUploadRules";
            this.btnUploadRules.Size = new System.Drawing.Size(198, 35);
            this.btnUploadRules.TabIndex = 23;
            this.btnUploadRules.Text = "Upload rules";
            this.btnUploadRules.UseVisualStyleBackColor = true;
            this.btnUploadRules.Click += new System.EventHandler(this.btnUploadRules_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 59);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SequenceNumber,
            this.FilePath,
            this.Information,
            this.Others});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(40, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(757, 160);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SequenceNumber
            // 
            this.SequenceNumber.HeaderText = "n/n";
            this.SequenceNumber.Name = "SequenceNumber";
            this.SequenceNumber.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "File";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.HeaderText = "Status";
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            // 
            // Others
            // 
            this.Others.HeaderText = "Information";
            this.Others.Name = "Others";
            this.Others.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUploadRules);
            this.Controls.Add(this.textBoxRulesPath);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnChooseFolderForSaving);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConvertAndSave);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvertAndSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUploadSales;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnChooseFolderForSaving;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxRulesPath;
        private System.Windows.Forms.Button btnUploadRules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SequenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
    }
}

