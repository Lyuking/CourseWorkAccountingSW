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
        }

        private void buttonInsertNewSoftware_Click(object sender, EventArgs e)
        {
            if(checkBoxQR.Checked)
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
        }
    }
}
