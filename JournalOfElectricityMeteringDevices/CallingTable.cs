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
    class CallingTable
    {
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private SqlConnection connection = null;
        public void Calling(DataGridView dataGridView, string nameBD)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
            connection.Open();
            try
            {
                dataGridView.Rows.Clear();

                int i = 0;
                command = new SqlCommand($"SELECT * FROM [{nameBD}]", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    dataGridView.Rows.Add(i, reader["Applicant"].ToString(), reader["Object"].ToString(), reader["NutritionCenter"].ToString(),
                        reader["Power"].ToString(), reader["PUtype"].ToString(), reader["TUnumber"].ToString(),
                        reader["RelayPosition"].ToString(), reader["FactoryNumber"].ToString(), reader["VerificationDate"].ToString(),
                        reader["Status"].ToString());
                }
                reader.Close();
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { connection.Close();}
        }
    }
}
