
namespace accounting_sw.DataChangerForms
{
    partial class InstalledSoftwareChanger
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Аудитория");
            this.dataGridViewInstalledLicences = new System.Windows.Forms.DataGridView();
            this.treeViewAudiencesAndPCs = new System.Windows.Forms.TreeView();
            this.comboBoxSoftwareName = new System.Windows.Forms.ComboBox();
            this.buttonInstallSoftOnPC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledLicences)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInstalledLicences
            // 
            this.dataGridViewInstalledLicences.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewInstalledLicences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstalledLicences.Location = new System.Drawing.Point(203, 12);
            this.dataGridViewInstalledLicences.Name = "dataGridViewInstalledLicences";
            this.dataGridViewInstalledLicences.ReadOnly = true;
            this.dataGridViewInstalledLicences.Size = new System.Drawing.Size(403, 280);
            this.dataGridViewInstalledLicences.TabIndex = 0;
            // 
            // treeViewAudiencesAndPCs
            // 
            this.treeViewAudiencesAndPCs.Location = new System.Drawing.Point(12, 51);
            this.treeViewAudiencesAndPCs.Name = "treeViewAudiencesAndPCs";
            treeNode2.Name = "AudienceNumber";
            treeNode2.Text = "Аудитория";
            this.treeViewAudiencesAndPCs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeViewAudiencesAndPCs.Size = new System.Drawing.Size(164, 259);
            this.treeViewAudiencesAndPCs.TabIndex = 1;
            // 
            // comboBoxSoftwareName
            // 
            this.comboBoxSoftwareName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSoftwareName.FormattingEnabled = true;
            this.comboBoxSoftwareName.Location = new System.Drawing.Point(12, 12);
            this.comboBoxSoftwareName.Name = "comboBoxSoftwareName";
            this.comboBoxSoftwareName.Size = new System.Drawing.Size(164, 21);
            this.comboBoxSoftwareName.TabIndex = 2;
            this.comboBoxSoftwareName.SelectedIndexChanged += new System.EventHandler(this.comboBoxSoftwareName_SelectedIndexChanged);
            // 
            // buttonInstallSoftOnPC
            // 
            this.buttonInstallSoftOnPC.Location = new System.Drawing.Point(431, 298);
            this.buttonInstallSoftOnPC.Name = "buttonInstallSoftOnPC";
            this.buttonInstallSoftOnPC.Size = new System.Drawing.Size(171, 23);
            this.buttonInstallSoftOnPC.TabIndex = 3;
            this.buttonInstallSoftOnPC.Text = "Добавить ПО на компьютер";
            this.buttonInstallSoftOnPC.UseVisualStyleBackColor = true;
            this.buttonInstallSoftOnPC.Click += new System.EventHandler(this.buttonInstallSoftOnPC_Click);
            // 
            // InstalledSoftwareChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 331);
            this.Controls.Add(this.buttonInstallSoftOnPC);
            this.Controls.Add(this.comboBoxSoftwareName);
            this.Controls.Add(this.treeViewAudiencesAndPCs);
            this.Controls.Add(this.dataGridViewInstalledLicences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InstalledSoftwareChanger";
            this.Text = "Добавление ПО на компьютер";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledLicences)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInstalledLicences;
        private System.Windows.Forms.TreeView treeViewAudiencesAndPCs;
        private System.Windows.Forms.ComboBox comboBoxSoftwareName;
        private System.Windows.Forms.Button buttonInstallSoftOnPC;
    }
}