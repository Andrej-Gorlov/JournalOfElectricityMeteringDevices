using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace JournalOfElectricityMeteringDevices
{
    public partial class Form1 : Form
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;

        Lazy<Curtain> curtain = new Lazy<Curtain>();
        Lazy<AppearancesCollor> appearancesCollor = new Lazy<AppearancesCollor>();
        Process processOpenFiel;

        bool CanOpenCurtain = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LMD"].ConnectionString);
            connection.Open();

            pictureBox1.Image = Properties.Resources.GorelektrosetNew;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            panelSQL.Size = new Size { Width = 1121, Height = 50 };
            panelSQL.Location = new Point { X = 69, Y = 712 };

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName("MediumAquamarine"); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };
            panelSQL.Paint += (s,a) => 
            {
                ControlPaint.DrawBorder(a.Graphics, this.panelSQL.ClientRectangle,
                Color.FromName("MediumAquamarine"), ButtonBorderStyle.Solid);
            };

           Thread threadPanelSQL = new Thread(() => 
            {
                panelSQL.MouseEnter += (s, a) =>
                {
                    if (CanOpenCurtain == true)
                    {
                        curtain.Value.OpenUp(dataGridView1, panelSQL);

                        byte[] backColorInitial = { 60, 179, 113 };
                        byte[] backColorFinal = { 102, 205, 170 };
                        byte[] foreColorInitial = { 60, 180, 113 };
                        byte[] foreColorFinal = { 0, 0, 0 };

                        appearancesCollor.Value.BackColorAppearances(textBoxSELECT, backColorInitial, backColorFinal, 2, 2, 4, 25);
                        appearancesCollor.Value.ForeColorAppearances(labelCommandSelest, foreColorInitial, foreColorFinal, 3, 9, 5, 50);
                        appearancesCollor.Value.ForeColorAppearances(buttonSelect, foreColorInitial, foreColorFinal, 3, 9, 5, 50);
                        CanOpenCurtain = false;
                    }
                };

                panel1.MouseEnter += (a, s) =>
                {
                    CanOpenCurtain = true;
                    buttonSelect.Visible = false;
                    labelCommandSelest.Visible = false;
                    textBoxSELECT.Visible = false;
                    curtain.Value.CloseDown(dataGridView1, panelSQL);
                };

                dataGridView1.MouseEnter += (a, s) =>
                {
                    CanOpenCurtain = true;
                    buttonSelect.Visible = false;
                    labelCommandSelest.Visible = false;
                    textBoxSELECT.Visible = false;
                    curtain.Value.CloseDown(dataGridView1, panelSQL);
                };
            });
            threadPanelSQL.Start();
        }
        private async void labelCommandSelest_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                    processOpenFiel = Process.Start("Основные_команды_SQL_и_БД_СНТ.txt", myPath);
                    processOpenFiel.WaitForExit();
                });
            }
            catch (Exception isk)
            {
                MessageBox.Show(isk.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                processOpenFiel.Close();
            }
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSELECT.Text != null)
                {
                    dataAdapter = new SqlDataAdapter(textBoxSELECT.Text, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
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
