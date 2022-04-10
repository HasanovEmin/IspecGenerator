using Aveva.Core.Database;
using Aveva.Core.Database.Filters;
using System.Collections.Generic;
using System.Linq;
using excel = Microsoft.Office.Interop.Excel;

namespace IspecGenerator
{
    internal class ExportExcelFile
    {
        private DbElement ceIspecExport;
        private string filePath;

        public ExportExcelFile(DbElement ceIspecExport, string fileName)
        {
            this.ceIspecExport = ceIspecExport;
            this.filePath = fileName;
            ExportFile();
        }

        private void ExportFile()
        {
            excel.Application application = new excel.Application();
            
            excel.Workbook workbook = application.Workbooks.Add();
            excel.Worksheet worksheet = workbook.ActiveSheet;

            
            HashSet<double> sizes = new HashSet<double>();
            TypeFilter spcoFilter = new TypeFilter(DbElementTypeInstance.SPCOMPONENT);
            DBElementCollection spcos = new DBElementCollection(ceIspecExport, spcoFilter);

            worksheet.Cells[1, 1] = "Size/Temperature";
            foreach (DbElement spco in spcos)
            {
                sizes.Add(spco.GetDouble(DbAttributeInstance.ANSW));
            }
            int sizeCount = 2;

            foreach (var size in sizes)
            {
                worksheet.Cells[sizeCount, 1] = size;
                sizeCount++;
            }


            TypeFilter seleFilter = new TypeFilter(DbElementTypeInstance.SELEC);
            DBElementCollection collection = new DBElementCollection(ceIspecExport, seleFilter);

            List<double> rows = sizes.ToList();
            


            int columnCount = 2;
            foreach (DbElement sele in collection)
            {
                
                if ( sele.GetAsString(DbAttributeInstance.TANS) != "INSU" )
                {
                    string ans = sele.GetAsString(DbAttributeInstance.ANSW);
                    ans = ans.Substring(0, ans.IndexOf("deg"));
                    string maxans = sele.GetAsString(DbAttributeInstance.MAXA);
                    maxans = maxans.Substring(0, maxans.IndexOf("deg"));

                    string temp = $"From {ans} To {maxans}"; 
                    worksheet.Cells[1,columnCount] = temp;
                    DBElementCollection tempCollection = new DBElementCollection(sele, spcoFilter);

                    foreach (DbElement spco in tempCollection)
                    {
                        try
                        {
                            DbElement scom = spco.GetElement(DbAttributeInstance.CATR);
                            double[] para = scom.GetDoubleArray(DbAttributeInstance.PARA);

                            double tempRowCount = 2 + rows.IndexOf(spco.GetDouble(DbAttributeInstance.ANSW));

                            worksheet.Cells[tempRowCount, columnCount] = para[0] / 2;
                            tempRowCount++;
                        }
                        catch (System.Exception)
                        {

                        }
                        

                    }
                    columnCount++;
                }
                
            }
            excel.Range range = worksheet.UsedRange;
            var column = range.EntireColumn;
            column.AutoFit();

            try
            {
                workbook.SaveAs(filePath);
            }
            catch (System.Exception)
            {

            }
            
            workbook.Close();
            application.Quit();

            System.Windows.Forms.MessageBox.Show("Process completed");
        }
    }
}