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
    class AddTable
    {
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        SqlConnection connection = null;
        public void СreateTable(string nameTable)
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
                connection.Open();
                if (nameTable != null)
                {
                    dataAdapter = new SqlDataAdapter($"CREATE TABLE[dbo].[{nameTable}]" +
               $"([Id] INT IDENTITY(1, 1) NOT NULL," +
               $"[Applicant]        NVARCHAR (50) NULL," +
               $"[Object]           NVARCHAR (50) NULL," +
               $"[NutritionCenter]  NVARCHAR (50) NULL," +
               $"[Power]            NVARCHAR (50) NULL," +
               $"[PUtype]           NVARCHAR (50) NULL," +
               $"[TUnumber]         NVARCHAR (50) NULL," +
               $"[RelayPosition]    NVARCHAR (50) NULL," +
               $"[FactoryNumber]    NVARCHAR (50) NULL," +
               $"[VerificationDate] NVARCHAR (50) NULL," +
               $"[Status]           NVARCHAR (50) NULL," +
               $"PRIMARY KEY CLUSTERED ([Id] ASC)); ", connection);

                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    connection.Close();
                    MessageBox.Show("Журнал создан", "Сообщение", MessageBoxButtons.OK);
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
