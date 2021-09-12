using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class DeletTable
    {
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        SqlConnection connection = null;
        public void EraseTable(string nameTable)
        {
            try
            {
                if (nameTable != null)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
                    connection.Open();

                    dataAdapter = new SqlDataAdapter($"DROP TABLE {nameTable};", connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    connection.Close();

                    MessageBox.Show("Журнал удалён", "Сообщение", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("введите названия журнала в поле ввода");

            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
