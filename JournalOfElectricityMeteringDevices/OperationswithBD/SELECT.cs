using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class SELECT
    {
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlConnection connection = null;
        public void Inquiry(DataGridView gridView, string select)
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
                connection.Open();

                if (select != null)
                {
                    dataAdapter = new SqlDataAdapter(select, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    gridView.DataSource = dataSet.Tables[0];
                }
                else
                    MessageBox.Show("Введите запрос");
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
