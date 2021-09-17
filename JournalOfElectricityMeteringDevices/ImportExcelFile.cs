using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;
//using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data;

namespace JournalOfElectricityMeteringDevices
{
    class ImportExcelFile
    {
        public void Import(DataGridView gridView, OpenFileDialog openFile,string y )
        {

            gridView.DataSource = null;
            gridView.Rows.Clear();

            gridView.Columns.Add("Column1", "№");
            gridView.Columns.Add("Column2", "Заявитель");
            gridView.Columns.Add("Column3", "Объект");
            gridView.Columns.Add("Column4", "Центр питания");
            gridView.Columns.Add("Column5", "Мощность");
            gridView.Columns.Add("Column6", "Тип ПУ");
            gridView.Columns.Add("Column7", "№ ТУ");
            gridView.Columns.Add("Column8", "Реле");
            gridView.Columns.Add("Column9", "Заводской номер");
            gridView.Columns.Add("Column10", "Дата поверки");
            gridView.Columns.Add("Column11", "Статус");

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
                        gridView.Rows.Add(i,
                            xlRange.Cells[xlRow, 1].Text,
                            xlRange.Cells[xlRow, 2].Text,
                            xlRange.Cells[xlRow, 3].Text,
                            xlRange.Cells[xlRow, 4].Text,
                            xlRange.Cells[xlRow, 5].Text,
                            xlRange.Cells[xlRow, 6].Text,
                            xlRange.Cells[xlRow, 7].Text,
                            xlRange.Cells[xlRow, 8].Text,
                            xlRange.Cells[xlRow, 9].Text,
                            xlRange.Cells[xlRow, 10].Text,
                            xlRange.Cells[xlRow, 11].Text);
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
        }
    }
}
