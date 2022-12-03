
namespace accounting_sw.DataChangerForms
{
    partial class SoftwareChanger
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
            this.comboBoxSubjectArea = new System.Windows.Forms.ComboBox();
            this.textBoxSoftwareName = new System.Windows.Forms.TextBox();
            this.textBoxSoftwareDescription = new System.Windows.Forms.TextBox();
            this.textBoxSoftwareRequiredSpace = new System.Windows.Forms.TextBox();
            this.checkBoxQR = new System.Windows.Forms.CheckBox();
            this.buttonInsertNewSoftware = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSubjectArea
            // 
            this.comboBoxSubjectArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubjectArea.FormattingEnabled = true;
            this.comboBoxSubjectArea.Location = new System.Drawing.Point(12, 24);
            this.comboBoxSubjectArea.Name = "comboBoxSubjectArea";
            this.comboBoxSubjectArea.Size = new System.Drawing.Size(195, 21);
            this.comboBoxSubjectArea.TabIndex = 0;
            // 
            // textBoxSoftwareName
            // 
            this.textBoxSoftwareName.Location = new System.Drawing.Point(13, 73);
            this.textBoxSoftwareName.Name = "textBoxSoftwareName";
            this.textBoxSoftwareName.Size = new System.Drawing.Size(194, 20);
            this.textBoxSoftwareName.TabIndex = 1;
            // 
            // textBoxSoftwareDescription
            // 
            this.textBoxSoftwareDescription.Location = new System.Drawing.Point(13, 122);
            this.textBoxSoftwareDescription.Name = "textBoxSoftwareDescription";
            this.textBoxSoftwareDescription.Size = new System.Drawing.Size(194, 20);
            this.textBoxSoftwareDescription.TabIndex = 2;
            // 
            // textBoxSoftwareRequiredSpace
            // 
            this.textBoxSoftwareRequiredSpace.Location = new System.Drawing.Point(12, 168);
            this.textBoxSoftwareRequiredSpace.Name = "textBoxSoftwareRequiredSpace";
            this.textBoxSoftwareRequiredSpace.Size = new System.Drawing.Size(194, 20);
            this.textBoxSoftwareRequiredSpace.TabIndex = 3;
            // 
            // checkBoxQR
            // 
            this.checkBoxQR.AutoSize = true;
            this.checkBoxQR.Location = new System.Drawing.Point(47, 213);
            this.checkBoxQR.Name = "checkBoxQR";
            this.checkBoxQR.Size = new System.Drawing.Size(125, 17);
            this.checkBoxQR.TabIndex = 4;
            this.checkBoxQR.Text = "С QR - кодом сайта";
            this.checkBoxQR.UseVisualStyleBackColor = true;
            // 
            // buttonInsertNewSoftware
            // 
            this.buttonInsertNewSoftware.Location = new System.Drawing.Point(31, 252);
            this.buttonInsertNewSoftware.Name = "buttonInsertNewSoftware";
            this.buttonInsertNewSoftware.Size = new System.Drawing.Size(154, 23);
            this.buttonInsertNewSoftware.TabIndex = 5;
            this.buttonInsertNewSoftware.Text = "Добавить";
            this.buttonInsertNewSoftware.UseVisualStyleBackColor = true;
            this.buttonInsertNewSoftware.Click += new System.EventHandler(this.buttonInsertNewSoftware_Click);
            // 
            // SoftwareChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 309);
            this.Controls.Add(this.buttonInsertNewSoftware);
            this.Controls.Add(this.checkBoxQR);
            this.Controls.Add(this.textBoxSoftwareRequiredSpace);
            this.Controls.Add(this.textBoxSoftwareDescription);
            this.Controls.Add(this.textBoxSoftwareName);
            this.Controls.Add(this.comboBoxSubjectArea);
            this.Name = "SoftwareChanger";
            this.Text = "Software_changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSubjectArea;
        private System.Windows.Forms.TextBox textBoxSoftwareName;
        private System.Windows.Forms.TextBox textBoxSoftwareDescription;
        private System.Windows.Forms.TextBox textBoxSoftwareRequiredSpace;
        private System.Windows.Forms.CheckBox checkBoxQR;
        private System.Windows.Forms.Button buttonInsertNewSoftware;
    }
}