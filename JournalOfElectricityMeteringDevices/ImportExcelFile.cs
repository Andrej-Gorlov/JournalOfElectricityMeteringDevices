using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class ImportExcelFile
    {
        public void Import(System.Windows.Forms.DataGridView gridView, System.Windows.Forms.OpenFileDialog openFile )
        {
            try
            {
                gridView.Rows.Clear();
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
                Microsoft.Office.Interop.Excel.Range xlRange;
                int xlRow;
                string strFileName;
                openFile.Filter = "Excel Office|*.xls; *xlsx";
                openFile.ShowDialog();
                strFileName = openFile.FileName;
                if (strFileName != "")
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(strFileName);
                    xlWorksheet = xlWorkbook.Worksheets["Лист1"];
                    xlRange = xlWorksheet.UsedRange;
                    int i = 0;
                    for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                    {
                        if (xlRange.Cells[xlRow, 1].Text != "")
                        {
                            i++;
                            gridView.Rows.Add(i, xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text,
                                xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text,
                                xlRange.Cells[xlRow, 6].Text, xlRange.Cells[xlRow, 7].Text, xlRange.Cells[xlRow, 8].Text,
                                xlRange.Cells[xlRow, 9].Text, xlRange.Cells[xlRow, 10].Text, xlRange.Cells[xlRow, 11].Text);
                        }
                    }
                    xlWorkbook.Close();
                    xlApp.Quit();
                }
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
