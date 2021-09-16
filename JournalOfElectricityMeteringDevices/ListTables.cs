using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class ListTables
    {
        private SqlConnection connection = null;
        public void OpenList(ComboBox box)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
            connection.Open();

            try
            {
                box.Items.Clear();
                string cmdstr = "select * from sys.tables";
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmdstr, connection);
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    box.Items.Add(row["name"]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
