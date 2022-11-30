
namespace accounting_sw
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInstalledSoft = new System.Windows.Forms.TabPage();
            this.dataGridViewAudienceMain = new System.Windows.Forms.DataGridView();
            this.dataGridViewLicenceFromCurrentSoftFromPC = new System.Windows.Forms.DataGridView();
            this.dataGridViewInstalledSoft = new System.Windows.Forms.DataGridView();
            this.dataGridViewComputerNumber = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPageSoftware = new System.Windows.Forms.TabPage();
            this.dataGridViewLicencesFromSoft = new System.Windows.Forms.DataGridView();
            this.dataGridViewSoftware = new System.Windows.Forms.DataGridView();
            this.tabPageSubjectArea = new System.Windows.Forms.TabPage();
            this.dataGridViewSubjectArea = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPageComputers = new System.Windows.Forms.TabPage();
            this.dataGridViewComputer = new System.Windows.Forms.DataGridView();
            this.tabPageAudience = new System.Windows.Forms.TabPage();
            this.dataGridViewAudience = new System.Windows.Forms.DataGridView();
            this.tabPageEmployee = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployee = new System.Windows.Forms.DataGridView();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeSurname = new System.Windows.Forms.TextBox();
            this.textBoxEmployeePatronymic = new System.Windows.Forms.TextBox();
            this.buttonInsertEmployee = new System.Windows.Forms.Button();
            this.buttonUpdateEmployee = new System.Windows.Forms.Button();
            this.buttonDeleteEmployee = new System.Windows.Forms.Button();
            this.buttonDeleteAudience = new System.Windows.Forms.Button();
            this.buttonUpdateAudience = new System.Windows.Forms.Button();
            this.buttonInsertAudience = new System.Windows.Forms.Button();
            this.textBoxAudienceNumber = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageInstalledSoft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudienceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicenceFromCurrentSoftFromPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledSoft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputerNumber)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPageSoftware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicencesFromSoft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).BeginInit();
            this.tabPageSubjectArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjectArea)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageComputers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputer)).BeginInit();
            this.tabPageAudience.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudience)).BeginInit();
            this.tabPageEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInstalledSoft);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPageComputers);
            this.tabControl1.Controls.Add(this.tabPageAudience);
            this.tabControl1.Controls.Add(this.tabPageEmployee);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInstalledSoft
            // 
            this.tabPageInstalledSoft.Controls.Add(this.dataGridViewAudienceMain);
            this.tabPageInstalledSoft.Controls.Add(this.dataGridViewLicenceFromCurrentSoftFromPC);
            this.tabPageInstalledSoft.Controls.Add(this.dataGridViewInstalledSoft);
            this.tabPageInstalledSoft.Controls.Add(this.dataGridViewComputerNumber);
            this.tabPageInstalledSoft.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstalledSoft.Name = "tabPageInstalledSoft";
            this.tabPageInstalledSoft.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstalledSoft.Size = new System.Drawing.Size(935, 400);
            this.tabPageInstalledSoft.TabIndex = 0;
            this.tabPageInstalledSoft.Text = "Установленное П.О. По компьютерам";
            this.tabPageInstalledSoft.UseVisualStyleBackColor = true;
            this.tabPageInstalledSoft.Enter += new System.EventHandler(this.tabPageInstalledSoft_Enter);
            // 
            // dataGridViewAudienceMain
            // 
            this.dataGridViewAudienceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAudienceMain.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAudienceMain.Name = "dataGridViewAudienceMain";
            this.dataGridViewAudienceMain.Size = new System.Drawing.Size(124, 388);
            this.dataGridViewAudienceMain.TabIndex = 3;
            this.dataGridViewAudienceMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAudienceMain_CellClick);
            // 
            // dataGridViewLicenceFromCurrentSoftFromPC
            // 
            this.dataGridViewLicenceFromCurrentSoftFromPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLicenceFromCurrentSoftFromPC.Location = new System.Drawing.Point(519, 6);
            this.dataGridViewLicenceFromCurrentSoftFromPC.Name = "dataGridViewLicenceFromCurrentSoftFromPC";
            this.dataGridViewLicenceFromCurrentSoftFromPC.Size = new System.Drawing.Size(410, 388);
            this.dataGridViewLicenceFromCurrentSoftFromPC.TabIndex = 2;
            // 
            // dataGridViewInstalledSoft
            // 
            this.dataGridViewInstalledSoft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstalledSoft.Location = new System.Drawing.Point(312, 6);
            this.dataGridViewInstalledSoft.Name = "dataGridViewInstalledSoft";
            this.dataGridViewInstalledSoft.Size = new System.Drawing.Size(191, 388);
            this.dataGridViewInstalledSoft.TabIndex = 1;
            this.dataGridViewInstalledSoft.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInstalledSoft_CellClick);
            // 
            // dataGridViewComputerNumber
            // 
            this.dataGridViewComputerNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComputerNumber.Location = new System.Drawing.Point(182, 6);
            this.dataGridViewComputerNumber.Name = "dataGridViewComputerNumber";
            this.dataGridViewComputerNumber.Size = new System.Drawing.Size(124, 388);
            this.dataGridViewComputerNumber.TabIndex = 0;
            this.dataGridViewComputerNumber.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewComputerNumber_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(935, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Программное обеспечение";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPageSoftware);
            this.tabControl3.Controls.Add(this.tabPageSubjectArea);
            this.tabControl3.Location = new System.Drawing.Point(-4, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(943, 404);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPageSoftware
            // 
            this.tabPageSoftware.Controls.Add(this.dataGridViewLicencesFromSoft);
            this.tabPageSoftware.Controls.Add(this.dataGridViewSoftware);
            this.tabPageSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabPageSoftware.Name = "tabPageSoftware";
            this.tabPageSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSoftware.Size = new System.Drawing.Size(935, 378);
            this.tabPageSoftware.TabIndex = 0;
            this.tabPageSoftware.Text = "Общее";
            this.tabPageSoftware.UseVisualStyleBackColor = true;
            this.tabPageSoftware.Enter += new System.EventHandler(this.tabPageSoftware_Enter);
            // 
            // dataGridViewLicencesFromSoft
            // 
            this.dataGridViewLicencesFromSoft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLicencesFromSoft.Location = new System.Drawing.Point(559, 6);
            this.dataGridViewLicencesFromSoft.Name = "dataGridViewLicencesFromSoft";
            this.dataGridViewLicencesFromSoft.Size = new System.Drawing.Size(370, 359);
            this.dataGridViewLicencesFromSoft.TabIndex = 1;
            // 
            // dataGridViewSoftware
            // 
            this.dataGridViewSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSoftware.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSoftware.Name = "dataGridViewSoftware";
            this.dataGridViewSoftware.Size = new System.Drawing.Size(422, 359);
            this.dataGridViewSoftware.TabIndex = 0;
            this.dataGridViewSoftware.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSoftware_CellClick);
            // 
            // tabPageSubjectArea
            // 
            this.tabPageSubjectArea.Controls.Add(this.dataGridViewSubjectArea);
            this.tabPageSubjectArea.Location = new System.Drawing.Point(4, 22);
            this.tabPageSubjectArea.Name = "tabPageSubjectArea";
            this.tabPageSubjectArea.Size = new System.Drawing.Size(935, 378);
            this.tabPageSubjectArea.TabIndex = 2;
            this.tabPageSubjectArea.Text = "Предметная область";
            this.tabPageSubjectArea.UseVisualStyleBackColor = true;
            this.tabPageSubjectArea.Enter += new System.EventHandler(this.tabPageSubjectArea_Enter);
            // 
            // dataGridViewSubjectArea
            // 
            this.dataGridViewSubjectArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjectArea.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSubjectArea.Name = "dataGridViewSubjectArea";
            this.dataGridViewSubjectArea.Size = new System.Drawing.Size(240, 362);
            this.dataGridViewSubjectArea.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(935, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Лицензирование";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage15);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Controls.Add(this.tabPage12);
            this.tabControl2.Location = new System.Drawing.Point(4, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(761, 396);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage15
            // 
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Size = new System.Drawing.Size(753, 370);
            this.tabPage15.TabIndex = 2;
            this.tabPage15.Text = "Общее";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(753, 370);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Детализация лицензирования";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(753, 370);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Вид лицензии";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPageComputers
            // 
            this.tabPageComputers.Controls.Add(this.dataGridViewComputer);
            this.tabPageComputers.Location = new System.Drawing.Point(4, 22);
            this.tabPageComputers.Name = "tabPageComputers";
            this.tabPageComputers.Size = new System.Drawing.Size(935, 400);
            this.tabPageComputers.TabIndex = 3;
            this.tabPageComputers.Text = "Компьютеры";
            this.tabPageComputers.UseVisualStyleBackColor = true;
            this.tabPageComputers.Enter += new System.EventHandler(this.tabPageComputers_Enter);
            // 
            // dataGridViewComputer
            // 
            this.dataGridViewComputer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComputer.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewComputer.Name = "dataGridViewComputer";
            this.dataGridViewComputer.Size = new System.Drawing.Size(261, 394);
            this.dataGridViewComputer.TabIndex = 0;
            // 
            // tabPageAudience
            // 
            this.tabPageAudience.Controls.Add(this.buttonDeleteAudience);
            this.tabPageAudience.Controls.Add(this.buttonUpdateAudience);
            this.tabPageAudience.Controls.Add(this.buttonInsertAudience);
            this.tabPageAudience.Controls.Add(this.textBoxAudienceNumber);
            this.tabPageAudience.Controls.Add(this.dataGridViewAudience);
            this.tabPageAudience.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudience.Name = "tabPageAudience";
            this.tabPageAudience.Size = new System.Drawing.Size(935, 400);
            this.tabPageAudience.TabIndex = 4;
            this.tabPageAudience.Text = "Аудитории";
            this.tabPageAudience.UseVisualStyleBackColor = true;
            this.tabPageAudience.Enter += new System.EventHandler(this.tabPageAudience_Enter);
            // 
            // dataGridViewAudience
            // 
            this.dataGridViewAudience.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAudience.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewAudience.Name = "dataGridViewAudience";
            this.dataGridViewAudience.Size = new System.Drawing.Size(314, 396);
            this.dataGridViewAudience.TabIndex = 0;
            // 
            // tabPageEmployee
            // 
            this.tabPageEmployee.Controls.Add(this.buttonDeleteEmployee);
            this.tabPageEmployee.Controls.Add(this.buttonUpdateEmployee);
            this.tabPageEmployee.Controls.Add(this.buttonInsertEmployee);
            this.tabPageEmployee.Controls.Add(this.textBoxEmployeePatronymic);
            this.tabPageEmployee.Controls.Add(this.textBoxEmployeeSurname);
            this.tabPageEmployee.Controls.Add(this.textBoxEmployeeName);
            this.tabPageEmployee.Controls.Add(this.dataGridViewEmployee);
            this.tabPageEmployee.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployee.Name = "tabPageEmployee";
            this.tabPageEmployee.Size = new System.Drawing.Size(935, 400);
            this.tabPageEmployee.TabIndex = 5;
            this.tabPageEmployee.Text = "Сотрудники";
            this.tabPageEmployee.UseVisualStyleBackColor = true;
            this.tabPageEmployee.Enter += new System.EventHandler(this.tabPageEmployee_Enter);
            // 
            // dataGridViewEmployee
            // 
            this.dataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployee.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEmployee.Name = "dataGridViewEmployee";
            this.dataGridViewEmployee.Size = new System.Drawing.Size(349, 394);
            this.dataGridViewEmployee.TabIndex = 0;
            // 
            // textBoxEmployeeName
            // 
            this.textBoxEmployeeName.Location = new System.Drawing.Point(373, 33);
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmployeeName.TabIndex = 1;
            // 
            // textBoxEmployeeSurname
            // 
            this.textBoxEmployeeSurname.Location = new System.Drawing.Point(373, 77);
            this.textBoxEmployeeSurname.Name = "textBoxEmployeeSurname";
            this.textBoxEmployeeSurname.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmployeeSurname.TabIndex = 2;
            // 
            // textBoxEmployeePatronymic
            // 
            this.textBoxEmployeePatronymic.Location = new System.Drawing.Point(373, 125);
            this.textBoxEmployeePatronymic.Name = "textBoxEmployeePatronymic";
            this.textBoxEmployeePatronymic.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmployeePatronymic.TabIndex = 3;
            // 
            // buttonInsertEmployee
            // 
            this.buttonInsertEmployee.Location = new System.Drawing.Point(373, 172);
            this.buttonInsertEmployee.Name = "buttonInsertEmployee";
            this.buttonInsertEmployee.Size = new System.Drawing.Size(100, 23);
            this.buttonInsertEmployee.TabIndex = 4;
            this.buttonInsertEmployee.Text = "Добавить";
            this.buttonInsertEmployee.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateEmployee
            // 
            this.buttonUpdateEmployee.Location = new System.Drawing.Point(373, 225);
            this.buttonUpdateEmployee.Name = "buttonUpdateEmployee";
            this.buttonUpdateEmployee.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateEmployee.TabIndex = 5;
            this.buttonUpdateEmployee.Text = "Обновить";
            this.buttonUpdateEmployee.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteEmployee
            // 
            this.buttonDeleteEmployee.Location = new System.Drawing.Point(373, 276);
            this.buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            this.buttonDeleteEmployee.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteEmployee.TabIndex = 6;
            this.buttonDeleteEmployee.Text = "Удалить";
            this.buttonDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAudience
            // 
            this.buttonDeleteAudience.Location = new System.Drawing.Point(335, 185);
            this.buttonDeleteAudience.Name = "buttonDeleteAudience";
            this.buttonDeleteAudience.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteAudience.TabIndex = 12;
            this.buttonDeleteAudience.Text = "Удалить";
            this.buttonDeleteAudience.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateAudience
            // 
            this.buttonUpdateAudience.Location = new System.Drawing.Point(335, 134);
            this.buttonUpdateAudience.Name = "buttonUpdateAudience";
            this.buttonUpdateAudience.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateAudience.TabIndex = 11;
            this.buttonUpdateAudience.Text = "Обновить";
            this.buttonUpdateAudience.UseVisualStyleBackColor = true;
            // 
            // buttonInsertAudience
            // 
            this.buttonInsertAudience.Location = new System.Drawing.Point(335, 81);
            this.buttonInsertAudience.Name = "buttonInsertAudience";
            this.buttonInsertAudience.Size = new System.Drawing.Size(100, 23);
            this.buttonInsertAudience.TabIndex = 10;
            this.buttonInsertAudience.Text = "Добавить";
            this.buttonInsertAudience.UseVisualStyleBackColor = true;
            // 
            // textBoxAudienceNumber
            // 
            this.textBoxAudienceNumber.Location = new System.Drawing.Point(335, 27);
            this.textBoxAudienceNumber.Name = "textBoxAudienceNumber";
            this.textBoxAudienceNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxAudienceNumber.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 477);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageInstalledSoft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudienceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicenceFromCurrentSoftFromPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledSoft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputerNumber)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPageSoftware.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicencesFromSoft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).EndInit();
            this.tabPageSubjectArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjectArea)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageComputers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputer)).EndInit();
            this.tabPageAudience.ResumeLayout(false);
            this.tabPageAudience.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudience)).EndInit();
            this.tabPageEmployee.ResumeLayout(false);
            this.tabPageEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInstalledSoft;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPageComputers;
        private System.Windows.Forms.TabPage tabPageAudience;
        private System.Windows.Forms.TabPage tabPageEmployee;
        private System.Windows.Forms.DataGridView dataGridViewEmployee;
        private System.Windows.Forms.DataGridView dataGridViewAudience;
        private System.Windows.Forms.DataGridView dataGridViewComputer;
        private System.Windows.Forms.DataGridView dataGridViewComputerNumber;
        private System.Windows.Forms.DataGridView dataGridViewInstalledSoft;
        private System.Windows.Forms.DataGridView dataGridViewLicenceFromCurrentSoftFromPC;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPageSoftware;
        private System.Windows.Forms.DataGridView dataGridViewLicencesFromSoft;
        private System.Windows.Forms.DataGridView dataGridViewSoftware;
        private System.Windows.Forms.TabPage tabPageSubjectArea;
        private System.Windows.Forms.DataGridView dataGridViewSubjectArea;
        private System.Windows.Forms.DataGridView dataGridViewAudienceMain;
        private System.Windows.Forms.Button buttonDeleteAudience;
        private System.Windows.Forms.Button buttonUpdateAudience;
        private System.Windows.Forms.Button buttonInsertAudience;
        private System.Windows.Forms.TextBox textBoxAudienceNumber;
        private System.Windows.Forms.Button buttonDeleteEmployee;
        private System.Windows.Forms.Button buttonUpdateEmployee;
        private System.Windows.Forms.Button buttonInsertEmployee;
        private System.Windows.Forms.TextBox textBoxEmployeePatronymic;
        private System.Windows.Forms.TextBox textBoxEmployeeSurname;
        private System.Windows.Forms.TextBox textBoxEmployeeName;
    }
}

