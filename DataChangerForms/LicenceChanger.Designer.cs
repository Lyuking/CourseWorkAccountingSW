
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
            this.SuspendLayout();
            // 
            // comboBoxSelectSoftware
            // 
            this.comboBoxSelectSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectSoftware.FormattingEnabled = true;
            this.comboBoxSelectSoftware.Location = new System.Drawing.Point(12, 12);
            this.comboBoxSelectSoftware.Name = "comboBoxSelectSoftware";
            this.comboBoxSelectSoftware.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectSoftware.TabIndex = 0;
            // 
            // comboBoxSelectLicenceType
            // 
            this.comboBoxSelectLicenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectLicenceType.FormattingEnabled = true;
            this.comboBoxSelectLicenceType.Location = new System.Drawing.Point(12, 66);
            this.comboBoxSelectLicenceType.Name = "comboBoxSelectLicenceType";
            this.comboBoxSelectLicenceType.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectLicenceType.TabIndex = 1;
            // 
            // comboBoxSelectEmployee
            // 
            this.comboBoxSelectEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectEmployee.FormattingEnabled = true;
            this.comboBoxSelectEmployee.Location = new System.Drawing.Point(12, 124);
            this.comboBoxSelectEmployee.Name = "comboBoxSelectEmployee";
            this.comboBoxSelectEmployee.Size = new System.Drawing.Size(189, 21);
            this.comboBoxSelectEmployee.TabIndex = 2;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 180);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(189, 20);
            this.textBoxKey.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(12, 228);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(189, 20);
            this.textBoxPrice.TabIndex = 4;
            // 
            // dateTimePickerStartToAddLicence
            // 
            this.dateTimePickerStartToAddLicence.Location = new System.Drawing.Point(12, 277);
            this.dateTimePickerStartToAddLicence.Name = "dateTimePickerStartToAddLicence";
            this.dateTimePickerStartToAddLicence.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerStartToAddLicence.TabIndex = 5;
            // 
            // dateTimePickerEndToAddLicence
            // 
            this.dateTimePickerEndToAddLicence.Location = new System.Drawing.Point(12, 329);
            this.dateTimePickerEndToAddLicence.Name = "dateTimePickerEndToAddLicence";
            this.dateTimePickerEndToAddLicence.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerEndToAddLicence.TabIndex = 6;
            // 
            // buttonAddLicence
            // 
            this.buttonAddLicence.Location = new System.Drawing.Point(69, 371);
            this.buttonAddLicence.Name = "buttonAddLicence";
            this.buttonAddLicence.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLicence.TabIndex = 7;
            this.buttonAddLicence.Text = "Добавить";
            this.buttonAddLicence.UseVisualStyleBackColor = true;
            this.buttonAddLicence.Click += new System.EventHandler(this.buttonAddLicence_Click);
            // 
            // LicenceChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 406);
            this.Controls.Add(this.buttonAddLicence);
            this.Controls.Add(this.dateTimePickerEndToAddLicence);
            this.Controls.Add(this.dateTimePickerStartToAddLicence);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.comboBoxSelectEmployee);
            this.Controls.Add(this.comboBoxSelectLicenceType);
            this.Controls.Add(this.comboBoxSelectSoftware);
            this.Name = "LicenceChanger";
            this.Text = "LicenceChanger";
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
    }
}