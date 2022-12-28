using accounting_sw.DataChangerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_sw
{
    public partial class MainForm : Form
    {
        SQLiteWorker sQLite;
        public const string uniqueErrorMessage = "constraint failed\r\nUNIQUE constraint failed";
        public MainForm()
        {
            InitializeComponent();
            sQLite = new SQLiteWorker("accounting_software.db");
            
        }
        private void FillTreeViewAudPcSoft()
        {
            TreeNode audience = treeViewInstalledSoftByAudAndPC.Nodes[0];
            DataTable dtAudienceNum = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
            for (int i = 0; i < dtAudienceNum.Rows.Count; i++)
            {
                audience.Nodes.Add(dtAudienceNum.Rows[i].ItemArray[0].ToString(), dtAudienceNum.Rows[i].ItemArray[0].ToString());
                DataTable dtPCNum = sQLite.SelectComputerNumberFromDB(dtAudienceNum.Rows[i].ItemArray[0].ToString());
                for (int j = 0; j < dtPCNum.Rows.Count; j++)
                {
                    audience.Nodes[i].Nodes.Add(dtPCNum.Rows[j].ItemArray[0].ToString(), dtPCNum.Rows[j].ItemArray[0].ToString());
                    DataTable dtSoftwareName = sQLite.SelectInstalledSoftwareOnPCFromDB(dtPCNum.Rows[j].ItemArray[0].ToString());
                    for (int k = 0; k < dtSoftwareName.Rows.Count; k++)
                    {
                        audience.Nodes[i].Nodes[j].Nodes.Add(dtSoftwareName.Rows[k].ItemArray[0].ToString(), dtSoftwareName.Rows[k].ItemArray[0].ToString());
                    }
                }
            }
        }
        private void FillTreeViewAudSoft()
        {
            TreeNode audience = treeViewInstalledSoftByAud.Nodes[0];
            DataTable dtAudienceNum = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
            for (int i = 0; i < dtAudienceNum.Rows.Count; i++)
            {
                audience.Nodes.Add(dtAudienceNum.Rows[i].ItemArray[0].ToString(), dtAudienceNum.Rows[i].ItemArray[0].ToString());
                DataTable dtSoftwareName = sQLite.SelectSoftwareByAudFromDB(dtAudienceNum.Rows[i].ItemArray[0].ToString());
                for (int j = 0; j < dtSoftwareName.Rows.Count; j++)
                {
                    audience.Nodes[i].Nodes.Add(dtSoftwareName.Rows[j].ItemArray[0].ToString(), dtSoftwareName.Rows[j].ItemArray[0].ToString());
                }
            }
        }
        private void tabPageEmployee_Enter(object sender, EventArgs e)
        {
            GetEmployeeFromDB();
        }

        private void GetEmployeeFromDB()
        {
            dataGridViewEmployee.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full);
        }

        private void tabPageAudience_Enter(object sender, EventArgs e)
        {
            GetAudienceToAudienceTabPageFromDB();
        }

        private void GetAudienceToAudienceTabPageFromDB()
        {
            dataGridViewAudience.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
        }

        private void tabPageComputers_Enter(object sender, EventArgs e)
        {
            GetComputersFromDB();
        }

        private void GetComputersFromDB()
        {
            dataGridViewComputer.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.computer_full);
            DataTable dt = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
            for (int i = 0; i < dt.Rows.Count; i++)
                comboBoxAudNums.Items.Add(dt.Rows[i].ItemArray[0]);
        }

        private void tabPageInstalledSoft_Enter(object sender, EventArgs e)
        {
            //dataGridViewAudiencePC.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
            treeViewInstalledSoftByAudAndPC.Nodes[0].Nodes.Clear();
            FillTreeViewAudPcSoft();
        }
        //private void dataGridViewComputerNumber_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    pcnum = dataGridViewComputerNumberPC.Rows[e.RowIndex].Cells[dataGridViewComputerNumberPC.Columns.Count - 1].Value.ToString();
        //    dataGridViewInstalledSoftPC.DataSource = sQLite.SelectInstalledSoftwareOnPCFromDB(pcnum);
        //}

        //private void dataGridViewInstalledSoft_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dataGridViewLicenceFromCurrentSoftFromPCPC.DataSource =
        //        sQLite.SelectLicencesFromSoftwareFromCurrentMachineFromDB(dataGridViewInstalledSoftPC.Rows[e.RowIndex].Cells[dataGridViewInstalledSoftPC.Columns.Count - 1].Value.ToString(), pcnum);
        //}

        private void tabPageSubjectArea_Enter(object sender, EventArgs e)
        {
            GetSubjectAreaFromDB();
        }

        private void GetSubjectAreaFromDB()
        {
            dataGridViewSubjectArea.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
        }

        private void tabPageSoftware_Enter(object sender, EventArgs e)
        {
            dataGridViewSoftware.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.software);
            dataGridViewSoftware.Columns["software_QR"].Visible = false;          
        }
        private Image SelectPhotoFromSoftwareFromDB(DataGridViewCellEventArgs e, DataGridView dataGridView)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[dataGridView.Columns.Count - 1].Value != DBNull.Value)
            {
                byte[] imageArray = (byte[])dataGridView.Rows[e.RowIndex].Cells[dataGridView.Columns.Count - 1].Value;
                var ms = new System.IO.MemoryStream(imageArray);
                Image img = Image.FromStream(ms);
                ms.Close();
                return img;
            }
            else
            {
                Image image = Properties.Resources.NoImage;
                return image;
            }
        }
        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RowIndexNotOut(e))
            {
                dataGridViewLicencesFromSoft.DataSource = sQLite.SelectLicenceFromSoftwareFromDB(dataGridViewSoftware.Rows[e.RowIndex].Cells[0].Value.ToString());
                pictureBoxQR.Image = SelectPhotoFromSoftwareFromDB(e, dataGridViewSoftware);
            }
        }

        private static bool RowIndexNotOut(DataGridViewCellEventArgs e)
        {
            return e.RowIndex >= 0;
        }

        //private void dataGridViewAudienceMain_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dataGridViewComputerNumberPC.DataSource = sQLite.SelectComputerNumberFromDB(dataGridViewAudiencePC.Rows[e.RowIndex].Cells[0].Value.ToString());
        //}

        private void tabPageInstalledSoftByAud_Enter(object sender, EventArgs e)
        {
            treeViewInstalledSoftByAud.Nodes[0].Nodes.Clear();
            FillTreeViewAudSoft();
        }

        //private void dataGridViewAudienceAud_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dataGridViewInstalledSoftAud.DataSource = sQLite.SelectSoftwareByAudFromDB(dataGridViewAudienceAud.Rows[e.RowIndex].Cells[0].Value.ToString());
        //    dataGridViewLicenceFromCurrentSoftFromAud.DataSource = sQLite.SelectLicenceByAudFromDB(dataGridViewAudienceAud.Rows[e.RowIndex].Cells[0].Value.ToString());
        //}

        private void dataGridViewComputer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RowIndexNotOut(e))
            {
                textBoxPCNum.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 6].Value.ToString();
                maskedTextBoxPCIP.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 5].Value.ToString();
                textBoxPCProc.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 4].Value.ToString();
                textBoxPCVideo.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 3].Value.ToString();
                textBoxPCRAM.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 2].Value.ToString();
                textBoxPCTotalSpace.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 1].Value.ToString();
            }
        }

        private void buttonInsertPC_Click(object sender, EventArgs e)
        {
            if (comboBoxAudNums.Text != "" && comboBoxAudNums.Text != null && textBoxPCNum.Text != null & textBoxPCNum.Text != "")
            {
                try
                {
                    string ipWithoutBackSpace = GetIpWithoutBackSpaces();
                    sQLite.InsertNewPC(comboBoxAudNums.Text, textBoxPCNum.Text, ipWithoutBackSpace, textBoxPCProc.Text, textBoxPCVideo.Text, textBoxPCRAM.Text, textBoxPCTotalSpace.Text);
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(uniqueErrorMessage))
                    {
                        MessageBox.Show("Указанный номер компьютера уже занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                GetComputersFromDB();
            }
            else
            {
                MessageBox.Show("Введите номер аудитории и укажите номер компьютера");
            }
        }

        private string GetIpWithoutBackSpaces()
        {
            string ipWithoutBackSpace = "";
            if (maskedTextBoxPCIP.Text.Length > 0)
                ipWithoutBackSpace = maskedTextBoxPCIP.Text.Replace(" ", "");
            return ipWithoutBackSpace;
        }

        private void buttonInsertAudience_Click(object sender, EventArgs e)
        {
            if(textBoxAudienceNumber.Text != "" && textBoxAudienceNumber.Text != null)
            {
                try
                {
                    sQLite.InsertNewAudience(textBoxAudienceNumber.Text);
                    GetAudienceToAudienceTabPageFromDB();
                }
                catch (Exception ex)
                {
                    if(ex.Message.StartsWith(uniqueErrorMessage))
                    {
                        MessageBox.Show("Наименование аудитории уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridViewAudience_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(RowIndexNotOut(e))
             textBoxAudienceNumber.Text = dataGridViewAudience.Rows[e.RowIndex].Cells[dataGridViewAudience.Columns.Count - 1].Value.ToString();
        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RowIndexNotOut(e))
            {
                textBoxEmployeeName.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 3].Value.ToString();
                textBoxEmployeeSurname.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 2].Value.ToString();
                textBoxEmployeePatronymic.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 1].Value.ToString();
            }
        }

        private void buttonInsertEmployee_Click(object sender, EventArgs e)
        {
            if ((textBoxEmployeeName.Text != "" && textBoxEmployeeName.Text != null) && (textBoxEmployeeSurname.Text != "" && textBoxEmployeeSurname.Text != null))
            {

                DataTable dtEmployee = sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full);
                bool exist = CheckIsEmployeeExist(dtEmployee);
                if (!exist)
                {
                    sQLite.InsertNewEmployee(textBoxEmployeeName.Text, textBoxEmployeeSurname.Text, textBoxEmployeePatronymic.Text);
                    GetEmployeeFromDB();
                }
                else
                {
                    MessageBox.Show("Введённый сотрудник уже существует");
                }

            }
            else
            {
                MessageBox.Show("Введите имя и фамилию сотрудника");
            }
        }

        private bool CheckIsEmployeeExist(DataTable dtEmployee)
        {
            bool exist = false;
            for (int i = 0; i < dtEmployee.Rows.Count; i++)
            {
                if (textBoxEmployeeName.Text == dtEmployee.Rows[i].ItemArray[0].ToString() && textBoxEmployeeSurname.Text == dtEmployee.Rows[i].ItemArray[1].ToString() && textBoxEmployeePatronymic.Text == dtEmployee.Rows[i].ItemArray[2].ToString())
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }

        private void dataGridViewSubjectArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(RowIndexNotOut(e))
            textBoxSubjectAreaName.Text = dataGridViewSubjectArea.Rows[e.RowIndex].Cells[dataGridViewSubjectArea.Columns.Count - 1].Value.ToString();
        }

        private void buttonInsertSubjectArea_Click(object sender, EventArgs e)
        {
            
            if(textBoxSubjectAreaName.Text != null && textBoxSubjectAreaName.Text != "")
            {
                try
                {
                    sQLite.InsertNewSubjectArea(textBoxSubjectAreaName.Text);
                    GetSubjectAreaFromDB();
                }               
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(uniqueErrorMessage))
                    {
                        MessageBox.Show("Наименование предметной области уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите наименование предметной области");
            }
        }

        private void buttonOpenLicenceForm_Click(object sender, EventArgs e)
        {
            LicenceChanger licenceChanger = new LicenceChanger(sQLite);
            licenceChanger.ShowDialog();
            if(dataGridViewLicencesFromSoft.DataSource != null && dataGridViewSoftware.DataSource != null)
                dataGridViewLicencesFromSoft.DataSource = sQLite.SelectLicenceFromSoftwareFromDB(dataGridViewSoftware.Rows[dataGridViewSoftware.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void buttonInstallSoftware_Click(object sender, EventArgs e)
        {
            InstalledSoftwareChanger installedSoftwareChanger = new InstalledSoftwareChanger(sQLite);
            installedSoftwareChanger.ShowDialog();
            dataGridViewLicenceFromCurrentSoftFromPC.DataSource = null;
            treeViewInstalledSoftByAudAndPC.Nodes[0].Nodes.Clear();
            FillTreeViewAudPcSoft();

        }

        private void buttonOpenSoftwareForm_Click(object sender, EventArgs e)
        {
            SoftwareChanger softwareChanger = new SoftwareChanger(sQLite);
            softwareChanger.ShowDialog();
            dataGridViewSoftware.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.software);
        }

        private void tabPageLicenceType_Enter(object sender, EventArgs e)
        {
            dataGridViewLicenceType.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.licence_type);
        }

        private void buttonInsertLicenceType_Click(object sender, EventArgs e)
        {
            if (textBoxLicenceTypeName.Text != "" && textBoxLicenceTypeName.Text != null)
                try
                {
                    sQLite.InsertNewLicenceType(textBoxLicenceTypeName.Text);
                    dataGridViewLicenceType.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.licence_type);
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(uniqueErrorMessage))
                    {
                        MessageBox.Show("Указанное наименование уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void buttonUpdatePC_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridViewComputer.CurrentCell.RowIndex;
            string currentPCNum = dataGridViewComputer.Rows[currentRowIndex].Cells[dataGridViewComputer.Columns.Count - 6].Value.ToString();
            try
            {
                string ipWithoutAudiences = GetIpWithoutBackSpaces();
                if (comboBoxAudNums.Text == "" || comboBoxAudNums.Text == null)
                    sQLite.UpdatePCInDB(currentPCNum, textBoxPCNum.Text, ipWithoutAudiences, textBoxPCProc.Text, textBoxPCVideo.Text, textBoxPCRAM.Text, textBoxPCTotalSpace.Text);
                else
                    sQLite.UpdatePCInDB(comboBoxAudNums.Text, currentPCNum, textBoxPCNum.Text, ipWithoutAudiences, textBoxPCProc.Text, textBoxPCVideo.Text, textBoxPCRAM.Text, textBoxPCTotalSpace.Text);
            }
            catch (Exception ex)
            {
                if(ex.Message.StartsWith(uniqueErrorMessage))
                {
                    MessageBox.Show("Указанный номер компьютера уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dataGridViewComputer.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.computer_full);
        }

        private void buttonUpdateAudience_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridViewAudience.CurrentCell.RowIndex;
            string audienceNum = dataGridViewAudience.Rows[currentRowIndex].Cells[dataGridViewAudience.Columns.Count - 1].Value.ToString();
            try
            {
                if (textBoxAudienceNumber.Text != null && textBoxAudienceNumber.Text != "")
                    sQLite.UpdateAudience(audienceNum, textBoxAudienceNumber.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith(uniqueErrorMessage))
                {
                    MessageBox.Show("Указанный номер аудитории уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
            dataGridViewAudience.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridViewEmployee.CurrentCell.RowIndex;
            string employeeName, employeeSurname, employeePatronymic;
            bool exist = CheckIsEmployeeExist(sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full));
            if (!exist)
            {
                GetEmployeeFullName(currentRowIndex, out employeeName, out employeeSurname, out employeePatronymic);
                if (textBoxEmployeeName.Text != "" && textBoxEmployeeSurname.Text != "")
                    sQLite.UpdateEmployee(employeeName, employeeSurname, employeePatronymic, textBoxEmployeeName.Text, textBoxEmployeeSurname.Text, textBoxEmployeePatronymic.Text);
                dataGridViewEmployee.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full);
            }
        }

        private void GetEmployeeFullName(int currentRowIndex, out string employeeName, out string employeeSurname, out string employeePatronymic)
        {
            employeeName = dataGridViewEmployee.Rows[currentRowIndex].Cells[dataGridViewEmployee.Columns.Count - 3].Value.ToString();
            employeeSurname = dataGridViewEmployee.Rows[currentRowIndex].Cells[dataGridViewEmployee.Columns.Count - 2].Value.ToString();
            employeePatronymic = dataGridViewEmployee.Rows[currentRowIndex].Cells[dataGridViewEmployee.Columns.Count - 1].Value.ToString();
        }

        private void buttonUpdateSubjectArea_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridViewSubjectArea.CurrentCell.RowIndex;
            string subjectAreaName = dataGridViewSubjectArea.Rows[currentRowIndex].Cells[dataGridViewSubjectArea.Columns.Count - 1].Value.ToString();
            if (textBoxSubjectAreaName.Text != "" && textBoxSubjectAreaName.Text != null)
                try
                {
                    sQLite.UpdateSubjectArea(subjectAreaName, textBoxSubjectAreaName.Text);
                    dataGridViewSubjectArea.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(uniqueErrorMessage))
                    {
                        MessageBox.Show("Указанное наименование предметной области уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
        }

        private void buttonUpdateLicenceType_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridViewLicenceType.CurrentCell.RowIndex;
            string licenceTypeName = "";
            if (currentRowIndex >= 0)
                licenceTypeName = dataGridViewLicenceType.Rows[currentRowIndex].Cells[dataGridViewLicenceType.Columns.Count - 1].Value.ToString();
            try
            {
                if (textBoxLicenceTypeName.Text != "" && textBoxLicenceTypeName.Text != null)
                    sQLite.UpdateLicenceType(licenceTypeName, textBoxLicenceTypeName.Text);
                dataGridViewLicenceType.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith(uniqueErrorMessage))
                {
                    MessageBox.Show("Указанное наименование уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void treeViewInstalledSoftByAudAndPC_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (treeViewInstalledSoftByAudAndPC.SelectedNode != null)
                if (treeViewInstalledSoftByAudAndPC.SelectedNode.Parent != null && treeViewInstalledSoftByAudAndPC.SelectedNode.Parent.Parent != null
                    && treeViewInstalledSoftByAudAndPC.SelectedNode.Parent.Parent.Parent != null)
                {                    
                    dataGridViewLicenceFromCurrentSoftFromPC.DataSource =
                sQLite.SelectLicencesFromSoftwareFromCurrentMachineFromDB(treeViewInstalledSoftByAudAndPC.SelectedNode.Text, treeViewInstalledSoftByAudAndPC.SelectedNode.Parent.Text);
                }
                else
                {
                    dataGridViewLicenceFromCurrentSoftFromPC.DataSource = null;
                }
        }

        private void treeViewInstalledSoftByAud_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(treeViewInstalledSoftByAud.SelectedNode != null)
                if(treeViewInstalledSoftByAud.SelectedNode.Parent != null && treeViewInstalledSoftByAud.SelectedNode.Parent !=null)
                {
                    //dataGridViewLicenceFromCurrentSoftFromAud.Rows.Clear();
                    dataGridViewLicenceFromCurrentSoftFromAud.DataSource =
                        sQLite.SelectLicenceByAudAndSoftFromDB(treeViewInstalledSoftByAud.SelectedNode.Parent.Text, treeViewInstalledSoftByAud.SelectedNode.Text);
                }
                else
                {
                    dataGridViewLicenceFromCurrentSoftFromAud.DataSource = null;
                }
        }

        private void buttonDeleteInstaledSoftwareFromPCFromDB_Click(object sender, EventArgs e)
        {
            if (treeViewInstalledSoftByAudAndPC.SelectedNode != null)
                if(MessageBox.Show("Вы точно хотите удалить ПО с компьютера?", "Удаление компьютера", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    if (treeViewInstalledSoftByAudAndPC.SelectedNode.Parent != null && treeViewInstalledSoftByAudAndPC.SelectedNode.Parent != null)
                    {
                        try
                        {
                            int currentRowIndex = dataGridViewLicenceFromCurrentSoftFromPC.CurrentCell.RowIndex;
                            string key = dataGridViewLicenceFromCurrentSoftFromPC.Rows[currentRowIndex].Cells[1].Value.ToString();
                            sQLite.DeleteInstalledSoftware(treeViewInstalledSoftByAudAndPC.SelectedNode.Parent.Text, key);
                            dataGridViewLicenceFromCurrentSoftFromPC.DataSource = null;
                            treeViewInstalledSoftByAudAndPC.Nodes[0].Nodes.Clear();
                            FillTreeViewAudPcSoft();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployee.DataSource != null)
            {
                try
                {
                    int currentRowIndex = dataGridViewEmployee.CurrentCell.RowIndex;
                    if (currentRowIndex >= 0)
                    {
                        if (MessageBox.Show("Вы точно хотите удалить выбранного сотрудника и всю связанную с ним информацию?", "Удаление сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string employeeSurname = "", employeePatronymic = "";
                            GetEmployeeFullName(currentRowIndex, out string employeeName, out employeeSurname, out employeePatronymic);
                            string employeeFull = employeeName + " " + employeeSurname + " " + employeePatronymic;
                            sQLite.DeleteEmployeeFromDB(employeeFull);

                            dataGridViewEmployee.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDeleteAudience_Click(object sender, EventArgs e)
        {
            if (dataGridViewAudience.DataSource != null)
            {                
                try
                {
                    int currentRowIndex = dataGridViewAudience.CurrentCell.RowIndex;
                    if (currentRowIndex >= 0)
                    {
                        if (MessageBox.Show("Вы точно хотите удалить выбранную аудиторию и всю связанную с ней информацию?", "Удаление аудитории", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            sQLite.DeleteAudienceFromDB(dataGridViewAudience.Rows[currentRowIndex].Cells[dataGridViewAudience.Columns.Count - 1].Value.ToString());
                            dataGridViewAudience.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDeletePC_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputer.DataSource != null)
                try
                {
                    int currentRowIndex = dataGridViewComputer.CurrentCell.RowIndex;
                    if (currentRowIndex >= 0)
                    {
                        if (MessageBox.Show("Вы точно хотите удалить выбранный компьютер и всю связанную с ним информацию?", "Удаление компьютера", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            sQLite.DeleteComputerFromDB(dataGridViewComputer.Rows[currentRowIndex].Cells[dataGridViewComputer.Columns.Count - 6].Value.ToString());
                            dataGridViewComputer.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.computer_full);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void buttonDeleteSubjectArea_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubjectArea.DataSource != null)
                if (MessageBox.Show("Вы точно хотите удалить выбранную предметную область и все связанные с ней данные?", "Удаление предметной области", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    try
                    {
                        int currentRowIndex = dataGridViewSubjectArea.CurrentCell.RowIndex;
                        if (currentRowIndex >= 0)
                        {
                            sQLite.DeleteSubjectAreaFromDB(dataGridViewSubjectArea.Rows[currentRowIndex].Cells[dataGridViewSubjectArea.Columns.Count - 1].Value.ToString());

                            dataGridViewSubjectArea.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void buttonDeleteLicenceType_Click(object sender, EventArgs e)
        {
            if (dataGridViewLicenceType.DataSource != null)
                if (MessageBox.Show("Вы точно хотите удалить выбранный тип лицензирования и все связанные с ним данные?", "Удаление типа лицензирования", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    try
                    {
                        int currentRowIndex = dataGridViewLicenceType.CurrentCell.RowIndex;
                        if (currentRowIndex >= 0)
                        {
                            sQLite.DeleteLicenceTypeFromDB(dataGridViewLicenceType.Rows[currentRowIndex].Cells[dataGridViewLicenceType.Columns.Count - 1].Value.ToString());

                            dataGridViewLicenceType.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.licence_type);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void buttonDeleteLicence_Click(object sender, EventArgs e)
        {
            if (dataGridViewLicencesFromSoft.DataSource != null)
            {
                int currentRowIndex = dataGridViewLicencesFromSoft.CurrentCell.RowIndex;
                int currentSoftwareRowIndex = dataGridViewSoftware.CurrentCell.RowIndex;
                if (currentRowIndex >= 0)
                {
                    if (MessageBox.Show("Вы точно хотите удалить выбранную копию ПО (лицензию) и все связанные с ней данные?", "Удаление лицензии", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            sQLite.DeleteLicenceFromDB(dataGridViewLicencesFromSoft.Rows[currentRowIndex].Cells[dataGridViewLicencesFromSoft.Columns.Count - 6].Value.ToString());
                            dataGridViewLicencesFromSoft.DataSource = sQLite.SelectLicenceFromSoftwareFromDB(dataGridViewSoftware.Rows[currentSoftwareRowIndex].Cells[0].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonDeleteSoftware_Click(object sender, EventArgs e)
        {
            if (dataGridViewSoftware.DataSource != null)
            {
                int currentRowIndex = dataGridViewSoftware.CurrentCell.RowIndex;
                if (currentRowIndex >= 0)
                {
                    if (MessageBox.Show("Вы точно хотите удалить выбранную копию ПО (лицензию) и все связанные с ней данные?", "Удаление лицензии", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            sQLite.DeleteSoftwareFromDB(dataGridViewSoftware.Rows[currentRowIndex].Cells[0].Value.ToString());

                            dataGridViewSoftware.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.software);
                            dataGridViewLicencesFromSoft.DataSource = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void поАудиториямToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = OpenSaveFileDialog("Отчёт по аудиториям");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFWorker pdf = new PDFWorker(sQLite);
                pdf.CreatePDFByAudience(sfd.FileName);
            }
        }

        private static SaveFileDialog OpenSaveFileDialog(string name)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = name;
            sfd.DefaultExt = "pdf";
            sfd.Filter = "PDF файлы (*.pdf)|*.pdf|Все файлы (*.*)|*.*";
            return sfd;
        }

        private void поПредназначениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = OpenSaveFileDialog("Отчёт по предназначению");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFWorker pdf = new PDFWorker(sQLite);
                pdf.CreatePDFBySubjectArea(sfd.FileName);
            }
        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = OpenSaveFileDialog("Отчёт по типу распространения");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFWorker pdf = new PDFWorker(sQLite);
                pdf.CreatePDFByLicenceType(sfd.FileName);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sQLite.ConnectionClose();
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sQLite.ConnectionClose();
            Application.Exit();
        }

        private void tabControlSoftwareAndLicence_Click(object sender, EventArgs e)
        {
            tabPageSoftware_Enter(sender, e);
        }
    }
}
