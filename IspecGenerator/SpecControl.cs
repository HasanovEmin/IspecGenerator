using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aveva.Core.Database;

namespace IspecGenerator
{
    public partial class SpecControl : UserControl
    {
        DbElement ceIspecExport;
        DbElement ceCateImport;
        bool exportIspecSet;
        bool importIspecSet;
        bool importCateSet;


        string ceUnit = string.Empty;
        string ceIspecImport;

        public SpecControl()
        {
            InitializeComponent();
            exportIspecSet = false;
            importIspecSet = false;
            radioMM.Checked = true;
            radioInch.Checked = false;
            ceUnit = "mm";
        }

        private void btnExportIspec_Click(object sender, EventArgs e)
        {
            ceIspecExport = CurrentElement.Element;

            if (ceIspecExport.GetAsString(DbAttributeInstance.TYPE) == "SPEC" && ceIspecExport.GetAsString(DbAttributeInstance.PURP) == "INSU")
            {
                lblExportIspec.Text = ceIspecExport.GetAsString(DbAttributeInstance.NAME);
                exportIspecSet = true;
            }
            else
            {
                lblExportIspec.Text = "Please choose spec with purp = insu";
                exportIspecSet = false;
            }



        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileExport.Text = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
             
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (exportIspecSet && txtFileExport.Text != null)
            {
                ExportExcelFile export = new ExportExcelFile(ceIspecExport, txtFileExport.Text);
            }
        }


        private void btnCate_Click(object sender, EventArgs e)
        {
            ceCateImport = CurrentElement.Element;

            if (ceCateImport.GetAsString(DbAttributeInstance.TYPE) == "CATE" && ceCateImport.GetAsString(DbAttributeInstance.GTYP) == "INSU")
            {
                lblCate.Text = ceCateImport.GetAsString(DbAttributeInstance.NAME);
                importCateSet = true;
            }
            else
            {
                lblCate.Text = "Please choose spec with purp = insu";
                importCateSet = false;
            }
        }



        private void txtImportSpecName_Leave(object sender, EventArgs e)
        {
            ceIspecImport = $"/{txtImportSpecName.Text}";
            if (ceIspecImport == "/")
            {
                importIspecSet = false;
                return;
            }
            try
            {
                DbElement ele;
                Aveva.Core.Utilities.Messaging.PdmsMessage message;
                bool element = DbElement.Parse(ceIspecImport, out ele, out message);

                if (element)
                {
                    txtImportSpecName.ResetText();
                    importIspecSet = false;
                    MessageBox.Show($"{ceIspecImport} is already available");
                }
                else
                {
                    bool isValidName = DbElement.IsValidNameFormat(ceIspecImport, Aveva.Core.Database.DbType.Catalogue, out message);
                    if (!isValidName)
                    {
                        MessageBox.Show($"{ceIspecImport} isn't a valid name");
                        return;
                    }

                    importIspecSet = true;

                }
            }
            catch (Exception)
            {
            }


        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!importIspecSet || !importCateSet)
            {
                if (!radioMM.Checked && !radioInch.Checked)
                {
                    MessageBox.Show("Please enter all options");
                    return;
                }
                
            }
            ImportExcelFile importExcelFile = new ImportExcelFile(ceIspecImport, ceCateImport, ceUnit);
            
        }

       


        private void radioMM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMM.Checked)
            {
                radioInch.Checked = false;
                ceUnit = "mm";
            }
        }

        private void radioInch_CheckedChanged(object sender, EventArgs e)
        {
            if (radioInch.Checked)
            {
                radioMM.Checked = false;
                ceUnit = "inch";
            }
        }
    }
}
