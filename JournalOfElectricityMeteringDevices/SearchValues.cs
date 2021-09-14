using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class SearchValues
    {
        public void ResultSearch(DataGridView gridView,TextBox textBox)
        {
            try
            {
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    gridView.Rows[i].Selected = false;
                    for (int j = 0; j < gridView.ColumnCount; j++)
                        if (gridView.Rows[i].Cells[j].Value != null)
                            if (gridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                            {
                                gridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
