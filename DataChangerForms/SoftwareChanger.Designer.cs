
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
            this.dataGridViewSoftware = new System.Windows.Forms.DataGridView();
            this.buttonUpdateSoftware = new System.Windows.Forms.Button();
            this.labelSubjectAreaName = new System.Windows.Forms.Label();
            this.labelSoftName = new System.Windows.Forms.Label();
            this.labelSoftDescr = new System.Windows.Forms.Label();
            this.labelReqSpace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSubjectArea
            // 
            this.comboBoxSubjectArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubjectArea.FormattingEnabled = true;
            this.comboBoxSubjectArea.Location = new System.Drawing.Point(143, 221);
            this.comboBoxSubjectArea.Name = "comboBoxSubjectArea";
            this.comboBoxSubjectArea.Size = new System.Drawing.Size(195, 21);
            this.comboBoxSubjectArea.TabIndex = 0;
            // 
            // textBoxSoftwareName
            // 
            this.textBoxSoftwareName.Location = new System.Drawing.Point(144, 270);
            this.textBoxSoftwareName.Name = "textBoxSoftwareName";
            this.textBoxSoftwareName.Size = new System.Drawing.Size(194, 20);
            this.textBoxSoftwareName.TabIndex = 1;
            // 
            // textBoxSoftwareDescription
            // 
            this.textBoxSoftwareDescription.Location = new System.Drawing.Point(144, 319);
            this.textBoxSoftwareDescription.Multiline = true;
            this.textBoxSoftwareDescription.Name = "textBoxSoftwareDescription";
            this.textBoxSoftwareDescription.Size = new System.Drawing.Size(194, 106);
            this.textBoxSoftwareDescription.TabIndex = 2;
            // 
            // textBoxSoftwareRequiredSpace
            // 
            this.textBoxSoftwareRequiredSpace.Location = new System.Drawing.Point(144, 444);
            this.textBoxSoftwareRequiredSpace.Name = "textBoxSoftwareRequiredSpace";
            this.textBoxSoftwareRequiredSpace.Size = new System.Drawing.Size(194, 20);
            this.textBoxSoftwareRequiredSpace.TabIndex = 3;
            // 
            // checkBoxQR
            // 
            this.checkBoxQR.AutoSize = true;
            this.checkBoxQR.Location = new System.Drawing.Point(180, 470);
            this.checkBoxQR.Name = "checkBoxQR";
            this.checkBoxQR.Size = new System.Drawing.Size(125, 17);
            this.checkBoxQR.TabIndex = 4;
            this.checkBoxQR.Text = "С QR - кодом сайта";
            this.checkBoxQR.UseVisualStyleBackColor = true;
            // 
            // buttonInsertNewSoftware
            // 
            this.buttonInsertNewSoftware.Location = new System.Drawing.Point(297, 493);
            this.buttonInsertNewSoftware.Name = "buttonInsertNewSoftware";
            this.buttonInsertNewSoftware.Size = new System.Drawing.Size(154, 23);
            this.buttonInsertNewSoftware.TabIndex = 5;
            this.buttonInsertNewSoftware.Text = "Добавить";
            this.buttonInsertNewSoftware.UseVisualStyleBackColor = true;
            this.buttonInsertNewSoftware.Click += new System.EventHandler(this.buttonInsertNewSoftware_Click);
            // 
            // dataGridViewSoftware
            // 
            this.dataGridViewSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSoftware.Location = new System.Drawing.Point(28, 12);
            this.dataGridViewSoftware.Name = "dataGridViewSoftware";
            this.dataGridViewSoftware.ReadOnly = true;
            this.dataGridViewSoftware.Size = new System.Drawing.Size(423, 189);
            this.dataGridViewSoftware.TabIndex = 6;
            this.dataGridViewSoftware.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSoftware_CellClick);
            // 
            // buttonUpdateSoftware
            // 
            this.buttonUpdateSoftware.Location = new System.Drawing.Point(28, 493);
            this.buttonUpdateSoftware.Name = "buttonUpdateSoftware";
            this.buttonUpdateSoftware.Size = new System.Drawing.Size(154, 23);
            this.buttonUpdateSoftware.TabIndex = 7;
            this.buttonUpdateSoftware.Text = "Изменить";
            this.buttonUpdateSoftware.UseVisualStyleBackColor = true;
            this.buttonUpdateSoftware.Click += new System.EventHandler(this.buttonUpdateSoftware_Click);
            // 
            // labelSubjectAreaName
            // 
            this.labelSubjectAreaName.AutoSize = true;
            this.labelSubjectAreaName.Location = new System.Drawing.Point(141, 204);
            this.labelSubjectAreaName.Name = "labelSubjectAreaName";
            this.labelSubjectAreaName.Size = new System.Drawing.Size(164, 13);
            this.labelSubjectAreaName.TabIndex = 8;
            this.labelSubjectAreaName.Text = "Укажите предметную область:";
            // 
            // labelSoftName
            // 
            this.labelSoftName.AutoSize = true;
            this.labelSoftName.Location = new System.Drawing.Point(141, 254);
            this.labelSoftName.Name = "labelSoftName";
            this.labelSoftName.Size = new System.Drawing.Size(105, 13);
            this.labelSoftName.TabIndex = 9;
            this.labelSoftName.Text = "Наименование ПО:";
            // 
            // labelSoftDescr
            // 
            this.labelSoftDescr.AutoSize = true;
            this.labelSoftDescr.Location = new System.Drawing.Point(141, 303);
            this.labelSoftDescr.Name = "labelSoftDescr";
            this.labelSoftDescr.Size = new System.Drawing.Size(79, 13);
            this.labelSoftDescr.TabIndex = 10;
            this.labelSoftDescr.Text = "Описание ПО:";
            // 
            // labelReqSpace
            // 
            this.labelReqSpace.AutoSize = true;
            this.labelReqSpace.Location = new System.Drawing.Point(141, 428);
            this.labelReqSpace.Name = "labelReqSpace";
            this.labelReqSpace.Size = new System.Drawing.Size(157, 13);
            this.labelReqSpace.TabIndex = 11;
            this.labelReqSpace.Text = "Занимаемое место на диске:";
            // 
            // SoftwareChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 528);
            this.Controls.Add(this.labelReqSpace);
            this.Controls.Add(this.labelSoftDescr);
            this.Controls.Add(this.labelSoftName);
            this.Controls.Add(this.labelSubjectAreaName);
            this.Controls.Add(this.buttonUpdateSoftware);
            this.Controls.Add(this.dataGridViewSoftware);
            this.Controls.Add(this.buttonInsertNewSoftware);
            this.Controls.Add(this.checkBoxQR);
            this.Controls.Add(this.textBoxSoftwareRequiredSpace);
            this.Controls.Add(this.textBoxSoftwareDescription);
            this.Controls.Add(this.textBoxSoftwareName);
            this.Controls.Add(this.comboBoxSubjectArea);
            this.Name = "SoftwareChanger";
            this.Text = "Добавление и изменение ПО";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewSoftware;
        private System.Windows.Forms.Button buttonUpdateSoftware;
        private System.Windows.Forms.Label labelSubjectAreaName;
        private System.Windows.Forms.Label labelSoftName;
        private System.Windows.Forms.Label labelSoftDescr;
        private System.Windows.Forms.Label labelReqSpace;
    }
}