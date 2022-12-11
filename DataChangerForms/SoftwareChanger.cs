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
    public partial class SoftwareChanger : Form
    {
        SQLiteWorker sqliteWorker;
        public SoftwareChanger(SQLiteWorker SQLiteWorker)
        {
            InitializeComponent();
            this.sqliteWorker = SQLiteWorker;
            DataTable dtSubjectArea = this.sqliteWorker.SelectFromDB(SQLiteWorker.dataTables.subject_area);
            for (int i = 0; i < dtSubjectArea.Rows.Count; i++)
                comboBoxSubjectArea.Items.Add(dtSubjectArea.Rows[i].ItemArray[0]);
            GetSoftwareFromDB();
        }

        private void buttonInsertNewSoftware_Click(object sender, EventArgs e)
        {   
            if(comboBoxSubjectArea.Text != "" && textBoxSoftwareName.Text != "")
            try
            {
                if (checkBoxQR.Checked)
                {
                    OpenFileDialog openFileDialog1 = GetOpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Image image = Image.FromFile(openFileDialog1.FileName);
                        sqliteWorker.InsertNewSoftware(comboBoxSubjectArea.Text, textBoxSoftwareName.Text, textBoxSoftwareDescription.Text, textBoxSoftwareRequiredSpace.Text, image);
                    }
                    else
                    {
                        MessageBox.Show("Не было выбрано фото. Снимите галочку или выберите фото.");
                    }
                }
                else
                    sqliteWorker.InsertNewSoftware(comboBoxSubjectArea.Text, textBoxSoftwareName.Text, textBoxSoftwareDescription.Text, textBoxSoftwareRequiredSpace.Text);
                GetSoftwareFromDB();
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith(MainForm.uniqueErrorMessage))
                {
                    MessageBox.Show("Указанное наименование ПО уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetSoftwareFromDB()
        {
            dataGridViewSoftware.DataSource = sqliteWorker.SelectFromDB(SQLiteWorker.dataTables.software);
            dataGridViewSoftware.Columns["software_QR"].Visible = false;
        }

        private void buttonUpdateSoftware_Click(object sender, EventArgs e)
        {
            if (comboBoxSubjectArea.Text != "" && textBoxSoftwareName.Text != "" && dataGridViewSoftware.DataSource != null && dataGridViewSoftware.Rows.Count > 0)
                try
                {                
                int currentRowIndex = dataGridViewSoftware.CurrentCell.RowIndex;
                if (checkBoxQR.Checked && currentRowIndex >= 0)
                {
                    OpenFileDialog openFileDialog1 = GetOpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Image image = Image.FromFile(openFileDialog1.FileName);
                        sqliteWorker.UpdateSoftware(dataGridViewSoftware.Rows[currentRowIndex].Cells[dataGridViewSoftware.Columns.Count - 5].Value.ToString(),
                            comboBoxSubjectArea.Text, textBoxSoftwareName.Text, textBoxSoftwareDescription.Text, textBoxSoftwareRequiredSpace.Text, image);
                    }
                    else
                    {
                        MessageBox.Show("Не было выбрано фото. Снимите галочку или выберите фото.");
                    }
                }
                else if (currentRowIndex >= 0)
                    sqliteWorker.UpdateSoftware(dataGridViewSoftware.Rows[currentRowIndex].Cells[dataGridViewSoftware.Columns.Count - 5].Value.ToString(),
                        comboBoxSubjectArea.Text, textBoxSoftwareName.Text, textBoxSoftwareDescription.Text, textBoxSoftwareRequiredSpace.Text);
                GetSoftwareFromDB();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith(MainForm.uniqueErrorMessage))
                    {
                        MessageBox.Show("Указанное наименование ПО уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
        private static OpenFileDialog GetOpenFileDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All Embroidery Files | *.bmp; *.gif; *.jpeg; *.jpg; " +
             "*.fif;*.fiff;*.png;*.wmf;*.emf" +
             "|Windows Bitmap (*.bmp)|*.bmp" +
             "|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg" +
             "|Graphics Interchange Format (*.gif)|*.gif" +
             "|Portable Network Graphics (*.png)|*.png" +
             "|Tag Embroidery File Format (*.tif)|*.tif;*.tiff";
            //openFileDialog1.Filter += "|All Files (*.*)|*.*";
            return openFileDialog1;
        }

        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridViewSoftware.CurrentCell.RowIndex;
            textBoxSoftwareName.Text = dataGridViewSoftware.Rows[currentRowIndex].Cells[dataGridViewSoftware.Columns.Count - 5].Value.ToString();
            textBoxSoftwareDescription.Text = dataGridViewSoftware.Rows[currentRowIndex].Cells[dataGridViewSoftware.Columns.Count - 3].Value.ToString();
            textBoxSoftwareRequiredSpace.Text = dataGridViewSoftware.Rows[currentRowIndex].Cells[dataGridViewSoftware.Columns.Count - 2].Value.ToString();
        }
    }
}
