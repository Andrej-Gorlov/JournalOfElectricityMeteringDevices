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
using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;

using System.Data.OleDb;
using System.Data.Odbc;

namespace JournalOfElectricityMeteringDevices
{
    public partial class Form1 : Form
    {
        //private SqlConnection connection = null;
        //private SqlDataAdapter dataAdapter = null;
        //private DataSet dataSet = null;

        Lazy<Curtain> curtain = new Lazy<Curtain>();
        Lazy<AppearancesCollor> appearancesCollor = new Lazy<AppearancesCollor>();
        Lazy<BackgroundColor> backgroundColor = new Lazy<BackgroundColor>();
        Lazy<TurnControl> turnControl = new Lazy<TurnControl>();
        Lazy<CallingTable> callingTable = new Lazy<CallingTable>();
        Lazy<SaveTableData> saveTable = new Lazy<SaveTableData>();
        Lazy<ImportExcelFile> importExcel = new Lazy<ImportExcelFile>();
        Lazy<ExportExcelFile> ExcelFile = new Lazy<ExportExcelFile>();
        Lazy<AddTable> addTable = new Lazy<AddTable>();
        Lazy<DeletTable> deletTable = new Lazy<DeletTable>();
        Lazy<SELECT> select = new Lazy<SELECT>();
        Lazy<ListTables> listTables = new Lazy<ListTables>();

        Process processOpenFiel;
        
        string strNameTable { get; set; }

        bool CanOpenCurtain = true;
        bool ColorB = true;
        bool BSearch = true; 

        public Form1()
        {
            InitializeComponent();

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName("MediumAquamarine"); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };

            buttonChangeBackground.Click += (s, a) => { panelBackground.Visible = true; };
            buttonChoice.Click += (s, a) => { panelChoic.Visible = true; };
            pictureBoxSearch.Click += (s, a) => 
            {
                if (BSearch == true) { panelSearch.Visible = true; BSearch = false; }
                else { panelSearch.Visible = false; BSearch = true; }
            };
            comboBoxV.MouseClick += (s, a) => { listTables.Value.OpenList(comboBoxV); };

            dataGridView1.MouseEnter += (s, a) => { panelBackground.Visible = false; panelChoic.Visible = false; };
            panelSettings.MouseEnter += (s, a) => { panelBackground.Visible = false; panelChoic.Visible = false; };

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.GorelektrosetNew;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBlue.Image = Properties.Resources.blue;
            pictureBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Properties.Resources.gren;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSearch.Image = Properties.Resources.pngSearch2;
            pictureBoxSearch.SizeMode = PictureBoxSizeMode.StretchImage;

            labelOptions.Location = new Point { X = panelSettings.Location.X + 260, Y = panelSettings.Location.Y + 200 };
            panelSQL.Size = new Size { Width = 1121, Height = 50 };
            panelSQL.Location = new Point { X = 69, Y = 712 };
            panelBackground.Location = new Point { X=buttonChangeBackground.Location.X+199, Y = panelSettings.Location.Y};
            panelChoic.Location = new Point { X = buttonImportExcel.Location.X + 199, Y = panelSettings.Location.Y + 360 };

            buttonChangeBackground.Visible = false;
            buttonExportExcel.Visible = false;
            buttonImportExcel.Visible = false;
            buttonChoice.Visible = false;
            buttonSave.Visible = false;
            panelBackground.Visible = false;
            panelChoic.Visible = false;
            panelSearch.Visible = false;

            comboBoxSearch.SelectedIndex = 1;

            turnControl.Value.TurnLebel(labelOptions, 270, "MediumSeaGreen");
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
                                labelOptions.Visible = false;
                                curtain.Value.OpenLeft(panelSettings, -1, 2, 2);
                                if (ColorB==true)
                                {
                                    byte[] foreColorInitia = { 60, 180, 113 };
                                    byte[] foreColorFina = { 0, 0, 0 };
                                    appearancesCollor.Value.ForeColorAppearances(buttonChangeBackground, foreColorInitia, foreColorFina, 3, 9, 5, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonExportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 250);
                                    appearancesCollor.Value.ForeColorAppearances(buttonImportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 150);
                                    appearancesCollor.Value.ForeColorAppearances(buttonChoice, foreColorInitia, foreColorFina, 3, 9, 5, 50, 50);
                                }
                                else if (ColorB==false)
                                {
                                    byte[] foreColorInitia = { 153, 180, 209 };
                                    byte[] foreColorFina = { 0, 0, 0 };
                                    appearancesCollor.Value.ForeColorAppearances(buttonChangeBackground, foreColorInitia, foreColorFina, 7, 9, 10, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonExportExcel, foreColorInitia, foreColorFina, 7, 9, 10, 50, 250);
                                    appearancesCollor.Value.ForeColorAppearances(buttonImportExcel, foreColorInitia, foreColorFina, 7, 9, 10, 50, 150);
                                    appearancesCollor.Value.ForeColorAppearances(buttonChoice, foreColorInitia, foreColorFina, 7, 9, 10, 50, 50);
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
                            buttonChoice.Visible = false;
                            curtain.Value.CloseRight(panelSettings, -250, 15);

                            labelOptions.Visible = true;
                            //byte[] foreColorInitial = { 60, 180, 113 };
                            //byte[] foreColorFinal = { 0, 0, 0 };
                            //appearancesCollor.Value.ForeColorAppearances(labelOptions, foreColorInitial, foreColorFinal, 3, 9, 5, 70, 350);// не работает планое появление
                        };

                        dataGridView1.MouseEnter += (a, s) =>
                        {
                            CanOpenCurtain = true;
                            buttonChangeBackground.Visible = false;
                            buttonExportExcel.Visible = false;
                            buttonImportExcel.Visible = false;
                            buttonChoice.Visible = false;
                            curtain.Value.CloseRight(panelSettings, -250, 15);

                            labelOptions.Visible = true;
                            //byte[] foreColorInitial = { 60, 180, 113 };
                            //byte[] foreColorFinal = { 0, 0, 0 };
                            //appearancesCollor.Value.ForeColorAppearances(labelOptions, foreColorInitial, foreColorFinal, 3, 9, 5, 70, 350);// не работает планое появление
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
            string selec = textBoxSELECT.Text;
            select.Value.Inquiry(dataGridView1,selec);
        }
        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            ExcelFile.Value.Export(dataGridView1);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ColorB = false;
            СhangeColor("ActiveCaption", "GradientInactiveCaption");
            panelBackground.Visible = false;
            turnControl.Value.TurnLebel(labelOptions, 180, "ActiveCaption");// если указать 360 градусов,то результат будет некорректный
            turnControl.Value.TurnLebel(labelOptions, 180, "ActiveCaption");// если указать 360 градусов,то результат будет некорректный
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColorB = true;
            СhangeColor("MediumSeaGreen", "MediumAquamarine");
            panelBackground.Visible = false;
            turnControl.Value.TurnLebel(labelOptions, 180, "MediumSeaGreen");// если указать 360 градусов,то результат будет некорректный
            turnControl.Value.TurnLebel(labelOptions, 180, "MediumSeaGreen");// если указать 360 градусов,то результат будет некорректный
        }
        private void СhangeColor(string mainColor, string secondaryColor)
        {
            panel1.BackColor = Color.FromName(mainColor);
            dataGridView1.BackgroundColor = Color.FromName(secondaryColor);
            dataGridView1.GridColor = Color.FromName(secondaryColor);
            textBoxSELECT.BackColor = Color.FromName(secondaryColor);
            panelBackground.BackColor = Color.FromName(mainColor);
            panelSettings.BackColor = Color.FromName(mainColor);
            panelSQL.BackColor = Color.FromName(mainColor);
            comboBoxV.BackColor= Color.FromName(secondaryColor);
            textAddJ.BackColor = Color.FromName(secondaryColor);
            textBoxDeleteJ.BackColor = Color.FromName(secondaryColor);
            panelChoic.BackColor = Color.FromName(mainColor);
            panelSearch.BackColor = Color.FromName(mainColor);
            comboBoxSearch.BackColor= Color.FromName(secondaryColor);
            textBoxSearch.BackColor= Color.FromName(secondaryColor);

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
            backgroundColor.Value.AskColor(panelChoic);
            backgroundColor.Value.AskColor(panelSearch);
        }
        private void buttonImportExcel_Click(object sender, EventArgs e)
        {
            importExcel.Value.Import(dataGridView1, openFD);

            if (ColorB == true)
            {
                byte[] foreColorInitia = { 60, 180, 113 };
                byte[] foreColorFina = { 0, 0, 0 };
                appearancesCollor.Value.ForeColorAppearances(buttonSave, foreColorInitia, foreColorFina, 3, 9, 5, 50);
            }
            else if (ColorB == false)
            {
                byte[] foreColorInitia = { 153, 180, 209 };
                byte[] foreColorFina = { 0, 0, 0 };
                appearancesCollor.Value.ForeColorAppearances(buttonSave, foreColorInitia, foreColorFina, 7, 9, 10, 50);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveTable.Value.Save(dataGridView1, strNameTable);
            buttonSave.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string nameTable = textAddJ.Text;
            addTable.Value.СreateTable(nameTable);
            textAddJ.Clear();
        }
        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            string nameTable = textBoxDeleteJ.Text;
            deletTable.Value.EraseTable(nameTable);
            textBoxDeleteJ.Clear();
        }
        private void button4_Click(object sender, EventArgs e)//изменить названия кнопки
        {
            string nameTable = strNameTable= comboBoxV.Text;
            callingTable.Value.Calling(dataGridView1, nameTable);
        }
    }
}
