using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_sw.DataChangerForms
{
    public partial class InstalledSoftwareChanger : Form
    {
        SQLiteWorker sqLite;
        public InstalledSoftwareChanger(SQLiteWorker sQLiteWorker)
        {
            InitializeComponent();
            this.sqLite = sQLiteWorker;
            FillTreeView();
            FillComboBox();
            

        }

        private void FillComboBox()
        {
            DataTable dtSoftwareName = sqLite.SelectFromDB(SQLiteWorker.dataTables.software_name);
            for (int i = 0; i < dtSoftwareName.Rows.Count; i++)
                comboBoxSoftwareName.Items.Add(dtSoftwareName.Rows[i].ItemArray[0]);
        }

        private void FillTreeView()
        {
            TreeNode audience = treeViewAudiencesAndPCs.Nodes[0];
            DataTable dtAudienceNum = sqLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
            for (int i = 0; i < dtAudienceNum.Rows.Count; i++)
            {
                audience.Nodes.Add(dtAudienceNum.Rows[i].ItemArray[0].ToString(), dtAudienceNum.Rows[i].ItemArray[0].ToString());
                DataTable dtPCNum = sqLite.SelectComputerNumberFromDB(dtAudienceNum.Rows[i].ItemArray[0].ToString());
                for (int j = 0; j < dtPCNum.Rows.Count; j++)
                {
                    audience.Nodes[i].Nodes.Add(dtPCNum.Rows[j].ItemArray[0].ToString(), dtPCNum.Rows[j].ItemArray[0].ToString());
                }
            }
        }

        private void comboBoxSoftwareName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtNotInstalledSoftLicences = sqLite.SelectNotInstalledLicencesFromDB((sender as ComboBox).Text);
            dataGridViewInstalledLicences.DataSource = dtNotInstalledSoftLicences;
        }

        private void buttonInstallSoftOnPC_Click(object sender, EventArgs e)
        {
            if(treeViewAudiencesAndPCs.SelectedNode.Parent.Parent!= null)
            {               
                if (comboBoxSoftwareName.Text != "" && comboBoxSoftwareName.Text != null)
                {
                    if (dataGridViewInstalledLicences.CurrentCell != null)
                    {
                        int currentRowIndex = dataGridViewInstalledLicences.CurrentCell.RowIndex;
                        if (currentRowIndex >= 0)
                        {
                            try
                            {
                                DataTable dataTable = sqLite.SelectLicencesFromSoftwareFromCurrentMachineFromDB(comboBoxSoftwareName.Text, treeViewAudiencesAndPCs.SelectedNode.Text);
                                bool isInstalled = false;
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    if (dataTable.Rows[i].ItemArray[1].ToString() == dataGridViewInstalledLicences.Rows[currentRowIndex].Cells[1].Value.ToString())
                                        isInstalled = true;
                                }
                                if (!isInstalled)
                                {
                                    sqLite.InsertNewSoftwareToPC(comboBoxSoftwareName.Text,
                                        dataGridViewInstalledLicences.Rows[currentRowIndex].Cells[dataGridViewInstalledLicences.Columns.Count - 6].Value.ToString(),
                                        treeViewAudiencesAndPCs.SelectedNode.Text);
                                    dataGridViewInstalledLicences.DataSource = sqLite.SelectNotInstalledLicencesFromDB(comboBoxSoftwareName.Text);
                                }
                                else
                                {
                                    MessageBox.Show("Выбранное ПО уже установлено на данную машину", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.StartsWith(MainForm.uniqueErrorMessage))
                                {
                                    MessageBox.Show("Выбранное ПО уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите ПО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите компьютер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
