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
        string pcnum;
        public MainForm()
        {
            InitializeComponent();
            sQLite = new SQLiteWorker("accounting_software.db");
            
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
            dataGridViewAudiencePC.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);          
        }
        private void dataGridViewComputerNumber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pcnum = dataGridViewComputerNumberPC.Rows[e.RowIndex].Cells[dataGridViewComputerNumberPC.Columns.Count - 1].Value.ToString();
            dataGridViewInstalledSoftPC.DataSource = sQLite.SelectInstalledSoftwareOnPCFromDB(pcnum);
        }

        private void dataGridViewInstalledSoft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLicenceFromCurrentSoftFromPCPC.DataSource = sQLite.SelectLicencesFromSoftwareFromCurrentMachineFromDB(dataGridViewInstalledSoftPC.Rows[e.RowIndex].Cells[dataGridViewInstalledSoftPC.Columns.Count - 1].Value.ToString(), pcnum);
        }

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
            dataGridViewLicencesFromSoft.DataSource = sQLite.SelectLicenceFromSoftwareFromDB(dataGridViewSoftware.Rows[e.RowIndex].Cells[0].Value.ToString());
            pictureBoxQR.Image = SelectPhotoFromSoftwareFromDB(e, dataGridViewSoftware);
        }

        private void dataGridViewAudienceMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewComputerNumberPC.DataSource = sQLite.SelectComputerNumberFromDB(dataGridViewAudiencePC.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void tabPageInstalledSoftByAud_Enter(object sender, EventArgs e)
        {
            dataGridViewAudienceAud.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
        }

        private void dataGridViewAudienceAud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewInstalledSoftAud.DataSource = sQLite.SelectSoftwareByAudFromDB(dataGridViewAudienceAud.Rows[e.RowIndex].Cells[0].Value.ToString());
            dataGridViewLicenceFromCurrentSoftFromAud.DataSource = sQLite.SelectLicenceByAudFromDB(dataGridViewAudienceAud.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridViewComputer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxPCNum.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 6].Value.ToString();
            textBoxPCIP.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 5].Value.ToString();
            textBoxPCProc.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 4].Value.ToString();
            textBoxPCVideo.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 3].Value.ToString();
            textBoxPCRAM.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 2].Value.ToString();
            textBoxPCTotalSpace.Text = dataGridViewComputer.Rows[e.RowIndex].Cells[dataGridViewComputer.Columns.Count - 1].Value.ToString();
        }

        private void buttonInsertPC_Click(object sender, EventArgs e)
        {
            if (comboBoxAudNums.Text != "" && comboBoxAudNums.Text != null)
            {
                sQLite.InsertNewPC(comboBoxAudNums.Text, textBoxPCNum.Text, textBoxPCIP.Text, textBoxPCProc.Text, textBoxPCVideo.Text, textBoxPCRAM.Text, textBoxPCTotalSpace.Text);
                GetComputersFromDB();
            }
        }

        private void buttonInsertAudience_Click(object sender, EventArgs e)
        {
            if(textBoxAudienceNumber.Text != "" && textBoxAudienceNumber.Text != null)
            {
                sQLite.InsertNewAudience(textBoxAudienceNumber.Text);
                GetAudienceToAudienceTabPageFromDB();
            }
        }

        private void dataGridViewAudience_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxAudienceNumber.Text = dataGridViewAudience.Rows[e.RowIndex].Cells[dataGridViewAudience.Columns.Count - 1].Value.ToString();
        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxEmployeeName.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 3].Value.ToString();
            textBoxEmployeeSurname.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 2].Value.ToString();
            textBoxEmployeePatronymic.Text = dataGridViewEmployee.Rows[e.RowIndex].Cells[dataGridViewEmployee.Columns.Count - 1].Value.ToString();
        }

        private void buttonInsertEmployee_Click(object sender, EventArgs e)
        {
            if((textBoxEmployeeName.Text != "" && textBoxEmployeeName.Text != null) && (textBoxEmployeeSurname.Text != "" && textBoxEmployeeSurname.Text != null))
            {
                sQLite.InsertNewEmployee(textBoxEmployeeName.Text, textBoxEmployeeSurname.Text, textBoxEmployeePatronymic.Text);
                GetEmployeeFromDB();
            }
        }

        private void dataGridViewSubjectArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxSubjectAreaName.Text = dataGridViewSubjectArea.Rows[e.RowIndex].Cells[dataGridViewSubjectArea.Columns.Count - 1].Value.ToString();
        }

        private void buttonInsertSubjectArea_Click(object sender, EventArgs e)
        {
            if(textBoxSubjectAreaName.Text != null && textBoxSubjectAreaName.Text != "")
            {
                sQLite.InsertNewSubjectArea(textBoxSubjectAreaName.Text);
                GetSubjectAreaFromDB();
            }
        }

        private void buttonOpenLicenceForm_Click(object sender, EventArgs e)
        {
            LicenceChanger licenceChanger = new LicenceChanger(sQLite);
            licenceChanger.ShowDialog();
        }

        private void buttonInstallSoftware_Click(object sender, EventArgs e)
        {
            InstalledSoftwareChanger installedSoftwareChanger = new InstalledSoftwareChanger(sQLite);
            installedSoftwareChanger.ShowDialog();
        }

        private void buttonOpenSoftwareForm_Click(object sender, EventArgs e)
        {
            SoftwareChanger softwareChanger = new SoftwareChanger(sQLite);
            softwareChanger.ShowDialog();
        }

        private void tabPageLicenceType_Enter(object sender, EventArgs e)
        {
            dataGridViewLicenceType.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.licence_type);
        }

        private void buttonInsertLicenceType_Click(object sender, EventArgs e)
        {
            if (textBoxLicenceTypeName.Text != "" && textBoxLicenceTypeName.Text != null)
                sQLite.InsertNewLicenceType(textBoxLicenceTypeName.Text);
        }
    }
}
