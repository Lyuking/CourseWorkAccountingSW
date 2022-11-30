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
    public partial class Form1 : Form
    {
        SQLiteWorker sQLite;
        string pcnum;
        public Form1()
        {
            InitializeComponent();
            sQLite = new SQLiteWorker("accounting_software.db");
        }

        private void tabPageEmployee_Enter(object sender, EventArgs e)
        {
            dataGridViewEmployee.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.employee_full);
        }

        private void tabPageAudience_Enter(object sender, EventArgs e)
        {
            dataGridViewAudience.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
        }

        private void tabPageComputers_Enter(object sender, EventArgs e)
        {
            dataGridViewComputer.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.computer_full);
        }

        private void tabPageInstalledSoft_Enter(object sender, EventArgs e)
        {
            dataGridViewAudienceMain.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);          
        }
        private void dataGridViewComputerNumber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pcnum = dataGridViewComputerNumber.Rows[e.RowIndex].Cells[dataGridViewComputerNumber.Columns.Count - 1].Value.ToString();
            dataGridViewInstalledSoft.DataSource = sQLite.SelectInstalledSoftwareOnPCFromDB(pcnum);
        }

        private void dataGridViewInstalledSoft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLicenceFromCurrentSoftFromPC.DataSource = sQLite.SelectLicencesFromSoftwareFromCurrentMachineFromDB(dataGridViewInstalledSoft.Rows[e.RowIndex].Cells[dataGridViewInstalledSoft.Columns.Count - 1].Value.ToString(), pcnum);
        }

        private void tabPageSubjectArea_Enter(object sender, EventArgs e)
        {
            dataGridViewSubjectArea.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
        }

        private void tabPageSoftware_Enter(object sender, EventArgs e)
        {
            dataGridViewSoftware.DataSource = sQLite.SelectFromDB(SQLiteWorker.dataTables.software);
            dataGridViewSoftware.Columns["software_QR"].Visible = false;
        }

        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLicencesFromSoft.DataSource = sQLite.SelectLicenceFromSoftwareFromDB(dataGridViewSoftware.Rows[e.RowIndex].Cells[0].Value.ToString());

        }

        private void dataGridViewAudienceMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewComputerNumber.DataSource = sQLite.SelectComputerNumberFromDB(dataGridViewAudienceMain.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
