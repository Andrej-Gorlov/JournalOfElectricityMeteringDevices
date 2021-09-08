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
using Excel = Microsoft.Office.Interop.Excel;

namespace JournalOfElectricityMeteringDevices
{
    public partial class Form1 : Form
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;

        Lazy<Curtain> curtain = new Lazy<Curtain>();
        Lazy<AppearancesCollor> appearancesCollor = new Lazy<AppearancesCollor>();
        Lazy<BackgroundColor> backgroundColor = new Lazy<BackgroundColor>();
        Process processOpenFiel;

        bool CanOpenCurtain = true;
        bool ColorB = true;

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
            pictureBlue.Image = Properties.Resources.blue;
            pictureBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Properties.Resources.gren;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            panelSQL.Size = new Size { Width = 1121, Height = 50 };
            panelSQL.Location = new Point { X = 69, Y = 712 };
            panelBackground.Location = new Point { X=buttonChangeBackground.Location.X+259, Y = panelSettings.Location.Y+17};// КООРДИНАТЫ

            buttonChangeBackground.Visible = false;
            buttonExportExcel.Visible = false;
            buttonImportExcel.Visible = false;
            panelBackground.Visible = false;

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName("MediumAquamarine"); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };

            СhangeColor("MediumSeaGreen", "MediumAquamarine");

            Parallel.Invoke(
                () =>
                {
                    new Thread(() =>
                    {
                        panelSQL.MouseEnter += (s, a) =>
                        {
                            if (CanOpenCurtain == true)
                            {
                                curtain.Value.OpenUp(dataGridView1, panelSQL);
                                if (ColorB==true)
                                {
                                    byte[] backColorInitial = { 60, 179, 113 };
                                    byte[] backColorFinal = { 102, 205, 170 };
                                    byte[] foreColorInitial = { 60, 180, 113 };
                                    byte[] foreColorFinal = { 0, 0, 0 };
                                    appearancesCollor.Value.BackColorAppearances(textBoxSELECT, backColorInitial, backColorFinal, 2, 2, 4, 25, 250);
                                    appearancesCollor.Value.ForeColorAppearances(labelCommandSelest, foreColorInitial, foreColorFinal, 3, 9, 5, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonSelect, foreColorInitial, foreColorFinal, 3, 9, 5, 50, 350);
                                }
                                else if (ColorB==false)
                                {
                                    byte[] backColorInitial = { 153, 180, 209 };
                                    byte[] backColorFinal = { 215, 228, 242 };
                                    byte[] foreColorInitial = { 153, 180, 209 };
                                    byte[] foreColorFinal = { 0, 0, 0 };
                                    appearancesCollor.Value.BackColorAppearances(textBoxSELECT, backColorInitial, backColorFinal, 6, 5, 3, 25, 250);
                                    appearancesCollor.Value.ForeColorAppearances(labelCommandSelest, foreColorInitial, foreColorFinal, 7, 9, 10, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonSelect, foreColorInitial, foreColorFinal, 7, 9, 10, 50, 350);
                                }
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
                    }).Start();
                },
                () =>
                {
                    new Thread(() =>
                    {
                        panelSettings.MouseEnter += (s, a) =>
                        {
                            if (CanOpenCurtain == true)
                            {
                                curtain.Value.OpenLeft(panelSettings, -1, 2, 2);
                                buttonChangeBackground.Visible = false;
                                buttonExportExcel.Visible = false;
                                buttonImportExcel.Visible = false;
                                if (ColorB==true)
                                {
                                    byte[] foreColorInitia = { 60, 180, 113 };
                                    byte[] foreColorFina = { 0, 0, 0 };
                                    appearancesCollor.Value.ForeColorAppearances(buttonChangeBackground, foreColorInitia, foreColorFina, 3, 9, 5, 50, 250);
                                    appearancesCollor.Value.ForeColorAppearances(buttonExportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 150);
                                    appearancesCollor.Value.ForeColorAppearances(buttonImportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 50);
                                }
                                else if (ColorB==false)
                                {
                                    byte[] foreColorInitia = { 153, 180, 209 };
                                    byte[] foreColorFina = { 0, 0, 0 };
                                    appearancesCollor.Value.ForeColorAppearances(buttonChangeBackground, foreColorInitia, foreColorFina, 7, 9, 10, 50, 250);
                                    appearancesCollor.Value.ForeColorAppearances(buttonExportExcel, foreColorInitia, foreColorFina, 7, 9, 10, 50, 150);
                                    appearancesCollor.Value.ForeColorAppearances(buttonImportExcel, foreColorInitia, foreColorFina, 7, 9, 10, 50, 50);
                                }
                                CanOpenCurtain = false;
                            }
                        };

                        panel1.MouseEnter += (a, s) =>
                        {
                            CanOpenCurtain = true;
                            buttonChangeBackground.Visible = false;
                            buttonExportExcel.Visible = false;
                            buttonImportExcel.Visible = false;
                            curtain.Value.CloseRight(panelSettings, -250, 15);
                        };

                        dataGridView1.MouseEnter += (a, s) =>
                        {
                            CanOpenCurtain = true;
                            buttonChangeBackground.Visible = false;
                            buttonExportExcel.Visible = false;
                            buttonImportExcel.Visible = false;
                            curtain.Value.CloseRight(panelSettings, -250, 15);
                        };
                    }).Start();
                }
            );
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

        private void buttonChangeBackground_Click(object sender, EventArgs e)
        {
            panelBackground.Visible = true;
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Excel.Application application = new Excel.Application();
                    application.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        application.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                        }
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

        private void buttonImportExcel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ColorB = false;
            СhangeColor("ActiveCaption", "GradientInactiveCaption");
            panelBackground.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColorB = true;
            СhangeColor("MediumSeaGreen", "MediumAquamarine");
            panelBackground.Visible = false;
        }
        private void СhangeColor(string mainColor, string secondaryColor)
        {
            panel1.BackColor = Color.FromName(mainColor);
            dataGridView1.BackgroundColor = Color.FromName(secondaryColor);
            textBoxSELECT.BackColor = Color.FromName(secondaryColor);
            panelBackground.BackColor = Color.FromName(mainColor);
            panelSettings.BackColor = Color.FromName(mainColor);
            panelSQL.BackColor = Color.FromName(mainColor);

            //buttonChangeBackground.MouseEnter += (s, a) => { buttonChangeBackground.BackColor = Color.FromName("GradientInactiveCaption"); };
            //buttonExportExcel.MouseEnter += (s, a) => { buttonExportExcel.BackColor = Color.FromName("GradientInactiveCaption"); };
            //buttonImportExcel.MouseEnter += (s, a) => { buttonImportExcel.BackColor = Color.FromName("GradientInactiveCaption"); };
            //buttonSelect.MouseEnter += (s, a) => { buttonSelect.BackColor = Color.FromName("GradientInactiveCaption"); };
            //buttonChangeBackground.MouseLeave += (s, a) => { buttonChangeBackground.BackColor = Color.FromName("ActiveCaption"); };
            //buttonExportExcel.MouseLeave += (s, a) => { buttonExportExcel.BackColor = Color.FromName("ActiveCaption"); };
            //buttonImportExcel.MouseLeave += (s, a) => { buttonImportExcel.BackColor = Color.FromName("ActiveCaption"); };
            //buttonSelect.MouseLeave += (s, a) => { buttonSelect.BackColor = Color.FromName("ActiveCaption"); };

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName(secondaryColor); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };

            backgroundColor.Value.colorName = secondaryColor;
            backgroundColor.Value.AskColor(panelSQL);
            backgroundColor.Value.AskColor(panelSettings);
            backgroundColor.Value.AskColor(panelBackground);
            backgroundColor.Value.AskColor(pictureBlue);
            backgroundColor.Value.AskColor(pictureBox3);
        }
    }
}
