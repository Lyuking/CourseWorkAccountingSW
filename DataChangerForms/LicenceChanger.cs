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
    public partial class LicenceChanger : Form
    {
        SQLiteWorker sqLiteWorker;
        public LicenceChanger(SQLiteWorker SQLiteWorker)
        {
            InitializeComponent();
            this.sqLiteWorker = SQLiteWorker;
            DataTable dtLicenceType = this.sqLiteWorker.SelectFromDB(SQLiteWorker.dataTables.licence_type);
            for (int i = 0; i < dtLicenceType.Rows.Count; i++)
                comboBoxSelectLicenceType.Items.Add(dtLicenceType.Rows[i].ItemArray[0]);

            DataTable dtEmployeeFullName = this.sqLiteWorker.SelectFromDB(SQLiteWorker.dataTables.employee_full);
            for (int i = 0; i < dtEmployeeFullName.Rows.Count; i++)
                comboBoxSelectEmployee.Items.Add($"{dtEmployeeFullName.Rows[i].ItemArray[0]} {dtEmployeeFullName.Rows[i].ItemArray[1]} {dtEmployeeFullName.Rows[i].ItemArray[2]}");

            DataTable dtSoftwareName = this.sqLiteWorker.SelectFromDB(SQLiteWorker.dataTables.software_name);
            for (int i = 0; i < dtSoftwareName.Rows.Count; i++)
                comboBoxSelectSoftware.Items.Add(dtSoftwareName.Rows[i].ItemArray[0]);
            //foreach (DataRowCollection item in dtLicenceType.Rows)
            //    comboBoxSelectLicenceTypeToAddLicence.Items.Add(item.item);
        }

        private void buttonAddLicence_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectEmployee.Text != "" && comboBoxSelectLicenceType.Text != "" & comboBoxSelectLicenceType.Text != "" && textBoxKey.Text != "")
                try
                {
                    sqLiteWorker.InsertNewLicence(comboBoxSelectLicenceType.Text, comboBoxSelectEmployee.Text, comboBoxSelectSoftware.Text, textBoxKey.Text, dateTimePickerStartToAddLicence.Value.Date,
                        dateTimePickerEndToAddLicence.Value.Date, textBoxPrice.Text);
                    FillLicencesFromDB();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(MainForm.uniqueErrorMessage))
                    {
                        MessageBox.Show("Указанный ключ уже используется. Возможно, ПО уже установлено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void comboBoxSelectSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLicencesFromDB();
        }

        private void FillLicencesFromDB()
        {
            dataGridViewLicences.DataSource = sqLiteWorker.SelectLicenceFromSoftwareFromDB(comboBoxSelectSoftware.Text);
        }

        private void buttonUpdateLicence_Click(object sender, EventArgs e)
        {
            if(comboBoxSelectLicenceType.Text != "" && comboBoxSelectEmployee.Text != "" && textBoxKey.Text != "" && dataGridViewLicences.DataSource != null && dataGridViewLicences.Rows.Count > 0)
            try
            {
                    if (dataGridViewLicences.Rows.Count > 0)
                    {
                        int currentRowIndex = dataGridViewLicences.CurrentCell.RowIndex;
                        if (currentRowIndex >= 0)
                        {
                            sqLiteWorker.UpdateLicence(comboBoxSelectLicenceType.Text, comboBoxSelectEmployee.Text, textBoxKey.Text, dateTimePickerStartToAddLicence.Text, dateTimePickerEndToAddLicence.Text,
                                textBoxPrice.Text, dataGridViewLicences.Rows[currentRowIndex].Cells[dataGridViewLicences.Columns.Count - 5].Value.ToString());
                            FillLicencesFromDB();
                        }
                        else
                            MessageBox.Show("Выберите лицензию для изменения");
                    }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith(MainForm.uniqueErrorMessage))
                {
                    MessageBox.Show("Указанный ключ уже используется. Возможно, ПО уже установлено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
