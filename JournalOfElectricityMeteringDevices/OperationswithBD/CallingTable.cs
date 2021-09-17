using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class CallingTable
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private DataSet dataSet = null;

       

        public void Calling(DataGridView dataGridView, string strNameTable)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
            connection.Open();
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
                connection.Open();

                dataGridView.Rows.Clear();

                dataAdapter = new SqlDataAdapter($"SELECT *, N'Удалить' AS [Delete] FROM [{strNameTable}]", connection);

                sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
                sqlCommandBuilder.GetInsertCommand();
                sqlCommandBuilder.GetUpdateCommand();
                sqlCommandBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, strNameTable);
                dataGridView.DataSource = dataSet.Tables[strNameTable];

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewLinkCell dataGridViewLinkCell = new DataGridViewLinkCell();
                    dataGridView[11, i] = dataGridViewLinkCell;
                }
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally { connection.Close(); }
        }
    }
}
