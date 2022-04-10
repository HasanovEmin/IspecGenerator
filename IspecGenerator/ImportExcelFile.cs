using Aveva.Core.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IspecGenerator
{
    internal class ImportExcelFile
    {

        Scoms scoms;
        Spec specCreator;
        private string ceIspecImport;
        private DbElement ceCateImport;
        private readonly string ceUnit;
        private Dictionary<double, DbElement> scomsAndValue = new Dictionary<double, DbElement>();
        DbFormat fbore;
        int fault = 0;
        public ImportExcelFile(string ceIspecImport, DbElement ceCateImport, string ceUnit)
        {
            this.ceIspecImport = ceIspecImport;
            this.ceCateImport = ceCateImport;
            this.ceUnit = ceUnit;
            fbore = null;

            scoms = new Scoms(ceCateImport, ceIspecImport);
            specCreator = new Spec(ceIspecImport);
            SetUnits();
            ImportFile();
        }

        private void SetUnits()
        {
            fbore = DbFormat.Create();

            if (ceUnit == "mm")
            {
                fbore.Units = DbDoubleUnits.GetUnits(DbUnits.MM);

            }
            else
            {
                fbore.Units = DbDoubleUnits.GetUnits(DbUnits.INCH);
            }

        }
        private void ImportFile() 
        {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            bool isSpecCreated = specCreator.TryToCreateSpec();

            if (!isSpecCreated)
            {
                return;
            }

       

            object misValue = System.Reflection.Missing.Value;
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(filePath, 0, true, 5, "", "", true,Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1);
            Excel.Range range = worksheet.UsedRange;

            var columns = range.EntireColumn;
            var rows = range.EntireRow;

            int count = 1;
            for (int column = 2; column <= columns.Count; column++)
            {
                Excel.Range tempRange = (Excel.Range)worksheet.Cells[1, column];
                string[] headers = new string[]{ };
                double ans = 0;
                double maxans = 0;
                try
                {
                    headers = tempRange.get_Value(misValue).ToString().Split();
                    ans = double.Parse(headers[1]);
                    maxans = double.Parse(headers[3]);
                }
                catch (Exception)
                {
                    // if header is wrong format or empty => skip this iteration
                    continue;
                }
                


                specCreator.CreateSelec(count, ans, maxans);
                

                int spcoIterator = 1;
                for (int row = 2; row <= rows.Count; row++)
                {
                    DbDouble bore = null;

                    Excel.Range temp = (Excel.Range)worksheet.Cells[row, 1];
                    try
                    {
                        bore = DbDouble.Create(temp.get_Value(misValue), fbore);
                    }
                    catch (Exception)
                    {
                        bore = DbDouble.Create("0", fbore);
                    }

                    specCreator.CreateSpco(spcoIterator, bore);
                    spcoIterator++;


                    Excel.Range cellValue = (Excel.Range)worksheet.Cells[row, column];
                    double value;
                    string textValue = string.Empty;
                    List<double> doubleValue = new List<double>();
                    
                    try
                    {
                        value = cellValue.get_Value(misValue);
                        doubleValue.Add(value * 2);
                    }
                    catch (Exception)
                    {
                        
                        try
                        {
                            textValue = (string)cellValue.get_Value(misValue);
                            value = double.Parse(textValue);
                            doubleValue.Add(value * 2);
                        }
                        catch (Exception)
                        {
                            fault++;
                            continue;
                        }
                        

                    }
                    scoms.Spco = specCreator.Spco;
                    scoms.Ans = ans;
                    scoms.Maxans = maxans;
                    scoms.bore = bore;
                    scoms.isScomAvailableMethod(value, doubleValue);
                    
                }
                count++;

            }
            if (fault != 0)
            {
                MessageBox.Show($"{fault} of excel's cells is wrong format");
                Aveva.Core.Utilities.CommandLine.Command.CreateCommand($@"$p Completed with {fault} errors").RunInPdms();

            }
            else
            {
                Aveva.Core.Utilities.CommandLine.Command.CreateCommand(@"$p Completed").RunInPdms();
            }
            MessageBox.Show("Completed");
                
            workbook.Close();
            application.Quit();
        }
    }
}