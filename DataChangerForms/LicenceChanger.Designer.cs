
namespace accounting_sw.DataChangerForms
{
    partial class LicenceChanger
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
            this.comboBoxSelectSoftware = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectLicenceType = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectEmployee = new System.Windows.Forms.ComboBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerStartToAddLicence = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndToAddLicence = new System.Windows.Forms.DateTimePicker();
            this.buttonAddLicence = new System.Windows.Forms.Button();
            this.dataGridViewLicences = new System.Windows.Forms.DataGridView();
            this.buttonUpdateLicence = new System.Windows.Forms.Button();
            this.labelSoft = new System.Windows.Forms.Label();
            this.labelLicType = new System.Windows.Forms.Label();
            this.labelEmp = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.numericUpDownLicenceCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLicenceCount)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectSoftware
            // 
            this.comboBoxSelectSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectSoftware.FormattingEnabled = true;
            this.comboBoxSelectSoftware.Location = new System.Drawing.Point(119, 306);
            this.comboBoxSelectSoftware.Name = "comboBoxSelectSoftware";
            this.comboBoxSelectSoftware.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectSoftware.TabIndex = 0;
            this.comboBoxSelectSoftware.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectSoftware_SelectedIndexChanged);
            // 
            // comboBoxSelectLicenceType
            // 
            this.comboBoxSelectLicenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectLicenceType.FormattingEnabled = true;
            this.comboBoxSelectLicenceType.Location = new System.Drawing.Point(119, 360);
            this.comboBoxSelectLicenceType.Name = "comboBoxSelectLicenceType";
            this.comboBoxSelectLicenceType.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectLicenceType.TabIndex = 1;
            // 
            // comboBoxSelectEmployee
            // 
            this.comboBoxSelectEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectEmployee.FormattingEnabled = true;
            this.comboBoxSelectEmployee.Location = new System.Drawing.Point(119, 418);
            this.comboBoxSelectEmployee.Name = "comboBoxSelectEmployee";
            this.comboBoxSelectEmployee.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectEmployee.TabIndex = 2;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(119, 474);
            this.textBoxKey.MaxLength = 255;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(189, 20);
            this.textBoxKey.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(119, 522);
            this.textBoxPrice.MaxLength = 255;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(189, 20);
            this.textBoxPrice.TabIndex = 4;
            // 
            // dateTimePickerStartToAddLicence
            // 
            this.dateTimePickerStartToAddLicence.Location = new System.Drawing.Point(119, 571);
            this.dateTimePickerStartToAddLicence.Name = "dateTimePickerStartToAddLicence";
            this.dateTimePickerStartToAddLicence.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerStartToAddLicence.TabIndex = 5;
            // 
            // dateTimePickerEndToAddLicence
            // 
            this.dateTimePickerEndToAddLicence.Location = new System.Drawing.Point(119, 623);
            this.dateTimePickerEndToAddLicence.Name = "dateTimePickerEndToAddLicence";
            this.dateTimePickerEndToAddLicence.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerEndToAddLicence.TabIndex = 6;
            // 
            // buttonAddLicence
            // 
            this.buttonAddLicence.Location = new System.Drawing.Point(115, 692);
            this.buttonAddLicence.Name = "buttonAddLicence";
            this.buttonAddLicence.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLicence.TabIndex = 7;
            this.buttonAddLicence.Text = "Добавить";
            this.buttonAddLicence.UseVisualStyleBackColor = true;
            this.buttonAddLicence.Click += new System.EventHandler(this.buttonAddLicence_Click);
            // 
            // dataGridViewLicences
            // 
            this.dataGridViewLicences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewLicences.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLicences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLicences.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewLicences.Name = "dataGridViewLicences";
            this.dataGridViewLicences.ReadOnly = true;
            this.dataGridViewLicences.Size = new System.Drawing.Size(439, 256);
            this.dataGridViewLicences.TabIndex = 8;
            // 
            // buttonUpdateLicence
            // 
            this.buttonUpdateLicence.Location = new System.Drawing.Point(233, 692);
            this.buttonUpdateLicence.Name = "buttonUpdateLicence";
            this.buttonUpdateLicence.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateLicence.TabIndex = 9;
            this.buttonUpdateLicence.Text = "Изменить";
            this.buttonUpdateLicence.UseVisualStyleBackColor = true;
            this.buttonUpdateLicence.Click += new System.EventHandler(this.buttonUpdateLicence_Click);
            // 
            // labelSoft
            // 
            this.labelSoft.AutoSize = true;
            this.labelSoft.Location = new System.Drawing.Point(116, 287);
            this.labelSoft.Name = "labelSoft";
            this.labelSoft.Size = new System.Drawing.Size(79, 13);
            this.labelSoft.TabIndex = 10;
            this.labelSoft.Text = "Выберите ПО:";
            // 
            // labelLicType
            // 
            this.labelLicType.AutoSize = true;
            this.labelLicType.Location = new System.Drawing.Point(116, 344);
            this.labelLicType.Name = "labelLicType";
            this.labelLicType.Size = new System.Drawing.Size(126, 13);
            this.labelLicType.TabIndex = 11;
            this.labelLicType.Text = "Укажите тип лицензии:";
            // 
            // labelEmp
            // 
            this.labelEmp.AutoSize = true;
            this.labelEmp.Location = new System.Drawing.Point(112, 402);
            this.labelEmp.Name = "labelEmp";
            this.labelEmp.Size = new System.Drawing.Size(199, 13);
            this.labelEmp.TabIndex = 12;
            this.labelEmp.Text = "Укажите ответственного сотрудника:";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(116, 458);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(36, 13);
            this.labelKey.TabIndex = 13;
            this.labelKey.Text = "Ключ:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(116, 506);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(33, 13);
            this.labelPrice.TabIndex = 14;
            this.labelPrice.Text = "Цена";
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Location = new System.Drawing.Point(116, 555);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(74, 13);
            this.labelDateStart.TabIndex = 15;
            this.labelDateStart.Text = "Дата начала:";
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Location = new System.Drawing.Point(116, 607);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(92, 13);
            this.labelDateEnd.TabIndex = 16;
            this.labelDateEnd.Text = "Дата окончания:";
            // 
            // numericUpDownLicenceCount
            // 
            this.numericUpDownLicenceCount.Location = new System.Drawing.Point(233, 654);
            this.numericUpDownLicenceCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLicenceCount.Name = "numericUpDownLicenceCount";
            this.numericUpDownLicenceCount.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownLicenceCount.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 656);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Количество:";
            // 
            // LicenceChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 727);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownLicenceCount);
            this.Controls.Add(this.labelDateEnd);
            this.Controls.Add(this.labelDateStart);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelEmp);
            this.Controls.Add(this.labelLicType);
            this.Controls.Add(this.labelSoft);
            this.Controls.Add(this.buttonUpdateLicence);
            this.Controls.Add(this.dataGridViewLicences);
            this.Controls.Add(this.buttonAddLicence);
            this.Controls.Add(this.dateTimePickerEndToAddLicence);
            this.Controls.Add(this.dateTimePickerStartToAddLicence);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.comboBoxSelectEmployee);
            this.Controls.Add(this.comboBoxSelectLicenceType);
            this.Controls.Add(this.comboBoxSelectSoftware);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LicenceChanger";
            this.Text = "Добавление и изменение лицензии";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLicenceCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectSoftware;
        private System.Windows.Forms.ComboBox comboBoxSelectLicenceType;
        private System.Windows.Forms.ComboBox comboBoxSelectEmployee;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartToAddLicence;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndToAddLicence;
        private System.Windows.Forms.Button buttonAddLicence;
        private System.Windows.Forms.DataGridView dataGridViewLicences;
        private System.Windows.Forms.Button buttonUpdateLicence;
        private System.Windows.Forms.Label labelSoft;
        private System.Windows.Forms.Label labelLicType;
        private System.Windows.Forms.Label labelEmp;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownLicenceCount;
        private System.Windows.Forms.Label label1;
    }
}