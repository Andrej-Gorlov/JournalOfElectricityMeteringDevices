using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class SaveTableData
    {
        private SqlCommand command = null;
        SqlConnection connection = null;
        public void Save(DataGridView gridView, string nameTable)
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);

                for (int i = 0; i < gridView.Rows.Count-1; i++)
                {
                    connection.Open();
                    command = new SqlCommand($"INSERT INTO {nameTable}" +
                        $" (Applicant,Object,NutritionCenter,Power,PUtype,TUnumber,RelayPosition,FactoryNumber,VerificationDate,Status)" +
                        $"VALUES" +
                        $"(@Applicant,@Object,@NutritionCenter,@Power,@PUtype,@TUnumber,@RelayPosition,@FactoryNumber,@VerificationDate,@Status)", connection);
                    command.Parameters.AddWithValue("@Applicant", gridView.Rows[i].Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@Object", gridView.Rows[i].Cells[2].Value.ToString());
                    command.Parameters.AddWithValue("@NutritionCenter", gridView.Rows[i].Cells[3].Value.ToString());
                    command.Parameters.AddWithValue("@Power", gridView.Rows[i].Cells[4].Value.ToString());
                    command.Parameters.AddWithValue("@PUtype", gridView.Rows[i].Cells[5].Value.ToString());
                    command.Parameters.AddWithValue("@TUnumber", gridView.Rows[i].Cells[6].Value.ToString());
                    command.Parameters.AddWithValue("@RelayPosition", gridView.Rows[i].Cells[7].Value.ToString());
                    command.Parameters.AddWithValue("@FactoryNumber", gridView.Rows[i].Cells[8].Value.ToString());
                    command.Parameters.AddWithValue("@VerificationDate", gridView.Rows[i].Cells[9].Value.ToString());
                    command.Parameters.AddWithValue("@Status", gridView.Rows[i].Cells[10].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Сохранение произошло", "Сообщение", MessageBoxButtons.OK);
                for (int i = 1; i < 12; i++)
                {
                    gridView.Columns.Remove($"Column{i}");
                }
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
