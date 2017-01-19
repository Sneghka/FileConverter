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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.boxCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvertAndSave = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnUploadSales = new System.Windows.Forms.Button();
            this.textBoxFolderForSaving = new System.Windows.Forms.TextBox();
            this.btnChooseFolderForSaving = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRulesPath = new System.Windows.Forms.TextBox();
            this.btnUploadRules = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заказчик";
            // 
            // boxCustomer
            // 
            this.boxCustomer.DropDownHeight = 150;
            this.boxCustomer.DropDownWidth = 220;
            this.boxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boxCustomer.FormattingEnabled = true;
            this.boxCustomer.IntegralHeight = false;
            this.boxCustomer.ItemHeight = 25;
            this.boxCustomer.Items.AddRange(new object[] {
            "Джонсон и Джонсон",
            "Другое"});
            this.boxCustomer.Location = new System.Drawing.Point(176, 15);
            this.boxCustomer.MaxDropDownItems = 20;
            this.boxCustomer.Name = "boxCustomer";
            this.boxCustomer.Size = new System.Drawing.Size(226, 33);
            this.boxCustomer.TabIndex = 1;
            this.boxCustomer.SelectedIndexChanged += new System.EventHandler(this.boxCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(642, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата";
            // 
            // btnConvertAndSave
            // 
            this.btnConvertAndSave.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnConvertAndSave.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConvertAndSave.Location = new System.Drawing.Point(721, 582);
            this.btnConvertAndSave.Name = "btnConvertAndSave";
            this.btnConvertAndSave.Size = new System.Drawing.Size(250, 44);
            this.btnConvertAndSave.TabIndex = 4;
            this.btnConvertAndSave.Text = "Конвертировать";
            this.btnConvertAndSave.UseVisualStyleBackColor = false;
            this.btnConvertAndSave.Click += new System.EventHandler(this.btnChangeNameAndSave_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(738, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 32);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnUploadSales
            // 
            this.btnUploadSales.Enabled = false;
            this.btnUploadSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadSales.Location = new System.Drawing.Point(23, 28);
            this.btnUploadSales.Name = "btnUploadSales";
            this.btnUploadSales.Size = new System.Drawing.Size(173, 31);
            this.btnUploadSales.TabIndex = 14;
            this.btnUploadSales.Text = "Выбрать файлы";
            this.btnUploadSales.UseVisualStyleBackColor = true;
            this.btnUploadSales.Click += new System.EventHandler(this.btnUploadSales_Click);
            // 
            // textBoxFolderForSaving
            // 
            this.textBoxFolderForSaving.Location = new System.Drawing.Point(42, 89);
            this.textBoxFolderForSaving.Name = "textBoxFolderForSaving";
            this.textBoxFolderForSaving.Size = new System.Drawing.Size(625, 20);
            this.textBoxFolderForSaving.TabIndex = 17;
            this.textBoxFolderForSaving.TextChanged += new System.EventHandler(this.textBoxFolderForSaving_TextChanged);
            // 
            // btnChooseFolderForSaving
            // 
            this.btnChooseFolderForSaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseFolderForSaving.Location = new System.Drawing.Point(689, 80);
            this.btnChooseFolderForSaving.Name = "btnChooseFolderForSaving";
            this.btnChooseFolderForSaving.Size = new System.Drawing.Size(198, 35);
            this.btnChooseFolderForSaving.TabIndex = 18;
            this.btnChooseFolderForSaving.Text = "Сохранить файлы\r\n";
            this.btnChooseFolderForSaving.UseVisualStyleBackColor = true;
            this.btnChooseFolderForSaving.Click += new System.EventHandler(this.btnChooseFolderForSaving_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(37, 189);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 383);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnUploadSales);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(926, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Конвертер";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilePath,
            this.Information,
            this.Others});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(23, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 25;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(875, 242);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.FillWeight = 189.1304F;
            this.FilePath.HeaderText = "Файл";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Information.DataPropertyName = "Status";
            this.Information.HeaderText = "Статус";
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            this.Information.Width = 97;
            // 
            // Others
            // 
            this.Others.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Others.DataPropertyName = "GlobalErrorMessage";
            this.Others.HeaderText = "Информация";
            this.Others.Name = "Others";
            this.Others.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(201, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "(заполните поля Заказчик и Дата)";
            // 
            // textBoxRulesPath
            // 
            this.textBoxRulesPath.Location = new System.Drawing.Point(41, 135);
            this.textBoxRulesPath.Name = "textBoxRulesPath";
            this.textBoxRulesPath.Size = new System.Drawing.Size(626, 20);
            this.textBoxRulesPath.TabIndex = 22;
            // 
            // btnUploadRules
            // 
            this.btnUploadRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadRules.Location = new System.Drawing.Point(689, 126);
            this.btnUploadRules.Name = "btnUploadRules";
            this.btnUploadRules.Size = new System.Drawing.Size(198, 35);
            this.btnUploadRules.TabIndex = 23;
            this.btnUploadRules.Text = "Загрузить правила\r\n";
            this.btnUploadRules.UseVisualStyleBackColor = true;
            this.btnUploadRules.Click += new System.EventHandler(this.btnUploadRules_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(955, 59);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 640);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1011, 19);
            this.statusBar1.TabIndex = 25;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 500;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(495, 640);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(516, 23);
            this.progressBar1.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1011, 659);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUploadRules);
            this.Controls.Add(this.textBoxRulesPath);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnChooseFolderForSaving);
            this.Controls.Add(this.textBoxFolderForSaving);
            this.Controls.Add(this.btnConvertAndSave);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvertAndSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnUploadSales;
        private System.Windows.Forms.TextBox textBoxFolderForSaving;
        private System.Windows.Forms.Button btnChooseFolderForSaving;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxRulesPath;
        private System.Windows.Forms.Button btnUploadRules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

