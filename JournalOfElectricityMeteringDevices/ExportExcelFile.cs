using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace JournalOfElectricityMeteringDevices
{
    class ExportExcelFile
    {
        public void Export(DataGridView gridView)
        {
            try
            {
                if (gridView.Rows.Count > 0)
                {
                    Excel.Application application = new Excel.Application();
                    application.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < gridView.Columns.Count + 1; i++)
                        application.Cells[1, i] = gridView.Columns[i - 1].HeaderText;
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < gridView.Columns.Count; j++)
                            application.Cells[i + 2, j + 1] = gridView.Rows[i].Cells[j].Value;
                    }
                    application.Columns.AutoFit();
                    application.Visible = true;
                }
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
