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
        private Point point;

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
        Lazy<SearchValues> searchValues = new Lazy<SearchValues>();
        Lazy<ButtonBoundaryChanges> boundaryChanges = new Lazy<ButtonBoundaryChanges>();
        Process processOpenFiel;
        string strNameTable { get; set; }

        bool CanOpenCurtain = true;
        bool ColorB = true;
        bool BSearch = true;
        bool SizeWindows = true;

        public Form1()
        {
            InitializeComponent();

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName("MediumAquamarine"); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };

            buttonChangeBackground.Click += (s, a) => { panelBackground.Visible = true; };
            buttonChoice.Click += (s, a) => { panelChoic.Visible = true; };
            pictureBoxSearch.Click += (s, a) =>
            {
                if (BSearch == true) { textBoxSearch.Visible = true; BSearch = false; }
                else { textBoxSearch.Visible = false; BSearch = true; }
            };
            comboBoxV.MouseClick += (s, a) => { listTables.Value.OpenList(comboBoxV); };
            labelClose.Click += (s, a) =>
            {
                if (MessageBox.Show("Вы действительно хотите выйти? ", "Закрытия приложения СНТ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Windows.Forms.Application.Exit();
            };
            labelCollapse.Click += (s, a) => { this.WindowState = FormWindowState.Minimized; };
            labelExpand.Click += (s, a) =>
            {
                if (SizeWindows == true)
                {
                    this.WindowState = FormWindowState.Maximized;
                    SizeWindows = false;
                }
                else if (SizeWindows == false)
                {
                    WindowState = FormWindowState.Normal;
                    this.Size = new Size(1264, 761);
                    SizeWindows = true;
                }

            };

            panel1.MouseMove += (s, a) =>
            {
                if (a.Button == MouseButtons.Left)
                {
                    this.Left += a.X - point.X;
                    this.Top += a.Y - point.Y;
                }
            };
            panel1.MouseDown += (s, a) => { point = new Point(a.X, a.Y); };

            dataGridView1.MouseEnter += (s, a) => { panelBackground.Visible = false; panelChoic.Visible = false; };
            panelSettings.MouseEnter += (s, a) => { panelBackground.Visible = false; panelChoic.Visible = false; };

            textBoxSearch.TextChanged += (s, a) => { searchValues.Value.ResultSearch(dataGridView1, textBoxSearch); };
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
            panelBackground.Location = new Point { X = buttonChangeBackground.Location.X + 199, Y = panelSettings.Location.Y };
            panelChoic.Location = new Point { X = buttonImportExcel.Location.X + 199, Y = panelSettings.Location.Y + 360 };

            buttonChangeBackground.Visible = false;
            buttonExportExcel.Visible = false;
            buttonImportExcel.Visible = false;
            buttonChoice.Visible = false;
            buttonSave.Visible = false;
            panelBackground.Visible = false;
            panelChoic.Visible = false;
            textBoxSearch.Visible = false;

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
                                if (ColorB == true)
                                {
                                    byte[] backColorInitial = { 60, 179, 113 };
                                    byte[] backColorFinal = { 102, 205, 170 };
                                    byte[] foreColorInitial = { 60, 180, 113 };
                                    byte[] foreColorFinal = { 0, 0, 0 };
                                    appearancesCollor.Value.BackColorAppearances(textBoxSELECT, backColorInitial, backColorFinal, 2, 2, 4, 25, 250);
                                    appearancesCollor.Value.ForeColorAppearances(labelCommandSelest, foreColorInitial, foreColorFinal, 3, 9, 5, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonSelect, foreColorInitial, foreColorFinal, 3, 9, 5, 50, 350);
                                }
                                else if (ColorB == false)
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
                                if (ColorB == true)
                                {
                                    byte[] foreColorInitia = { 60, 180, 113 };
                                    byte[] foreColorFina = { 0, 0, 0 };
                                    appearancesCollor.Value.ForeColorAppearances(buttonChangeBackground, foreColorInitia, foreColorFina, 3, 9, 5, 50, 350);
                                    appearancesCollor.Value.ForeColorAppearances(buttonExportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 250);
                                    appearancesCollor.Value.ForeColorAppearances(buttonImportExcel, foreColorInitia, foreColorFina, 3, 9, 5, 50, 150);
                                    appearancesCollor.Value.ForeColorAppearances(buttonChoice, foreColorInitia, foreColorFina, 3, 9, 5, 50, 50);
                                }
                                else if (ColorB == false)
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
            select.Value.Inquiry(dataGridView1, selec);
        }
        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            new Thread(() => { ExcelFile.Value.Export(dataGridView1); }).Start();
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
        private async void СhangeColor(string mainColor, string secondaryColor)
        {
            await Task.Delay(1);
            panel1.BackColor = Color.FromName(mainColor);
            dataGridView1.BackgroundColor = Color.FromName(secondaryColor);
            dataGridView1.GridColor = Color.FromName(secondaryColor);
            textBoxSELECT.BackColor = Color.FromName(secondaryColor);
            panelBackground.BackColor = Color.FromName(mainColor);
            panelSettings.BackColor = Color.FromName(mainColor);
            panelSQL.BackColor = Color.FromName(mainColor);
            comboBoxV.BackColor = Color.FromName(secondaryColor);
            textAddJ.BackColor = Color.FromName(secondaryColor);
            textBoxDeleteJ.BackColor = Color.FromName(secondaryColor);
            panelChoic.BackColor = Color.FromName(mainColor);
            textBoxSearch.BackColor = Color.FromName(secondaryColor);

            buttonChangeBackground.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonChangeBackground, 1, secondaryColor); };
            buttonExportExcel.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonExportExcel, 1, secondaryColor); };
            buttonImportExcel.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonImportExcel, 1, secondaryColor); };
            buttonSave.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonSave, 1, secondaryColor); };
            buttonChoice.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonChoice, 1, secondaryColor); };
            buttonSelect.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonSelect, 1, secondaryColor); };
            buttonDeleteTable.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonDeleteTable, 1, secondaryColor); };
            buttonLoadingTable.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonLoadingTable, 1, secondaryColor); };
            buttonAddTable.MouseEnter += (s, a) => { boundaryChanges.Value.Butotn(buttonAddTable, 1, secondaryColor); };

            buttonChangeBackground.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonChangeBackground, 0, mainColor); };
            buttonExportExcel.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonExportExcel, 0, mainColor); };
            buttonImportExcel.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonImportExcel, 0, mainColor); };
            buttonSave.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonSave, 0, mainColor); };
            buttonChoice.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonChoice, 0, mainColor); };
            buttonSelect.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonSelect, 0, mainColor); };
            buttonDeleteTable.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonDeleteTable, 0, mainColor); };
            buttonLoadingTable.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonLoadingTable, 0, mainColor); };
            buttonAddTable.MouseLeave += (s, a) => { boundaryChanges.Value.Butotn(buttonAddTable, 0, mainColor); };

            labelCommandSelest.MouseEnter += (s, a) => { labelCommandSelest.ForeColor = Color.FromName(secondaryColor); };
            labelCommandSelest.MouseLeave += (s, a) => { labelCommandSelest.ForeColor = Color.Black; };
            labelClose.MouseEnter += (s, a) => { labelClose.ForeColor = Color.FromName(secondaryColor); };
            labelClose.MouseLeave += (s, a) => { labelClose.ForeColor = Color.Black; };
            labelCollapse.MouseEnter += (s, a) => { labelCollapse.ForeColor = Color.FromName(secondaryColor); };
            labelCollapse.MouseLeave += (s, a) => { labelCollapse.ForeColor = Color.Black; };
            labelExpand.MouseEnter += (s, a) => { labelExpand.ForeColor = Color.FromName(secondaryColor); };
            labelExpand.MouseLeave += (s, a) => { labelExpand.ForeColor = Color.Black; };

            backgroundColor.Value.colorName = secondaryColor;
            backgroundColor.Value.AskColor(panelSQL);
            backgroundColor.Value.AskColor(panelSettings);
            backgroundColor.Value.AskColor(panelBackground);
            backgroundColor.Value.AskColor(pictureBlue);
            backgroundColor.Value.AskColor(pictureBox3);
            backgroundColor.Value.AskColor(panelChoic);
            backgroundColor.Value.AskColor(panel1);// при изминения размеров границ отстаются старые 
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
        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            string nameTable = textBoxDeleteJ.Text;
            new Thread(() => { deletTable.Value.EraseTable(nameTable); }).Start();
            textBoxDeleteJ.Clear();
        }
        private void buttonLoadingTable_Click(object sender, EventArgs e)
        {
            string nameTable = strNameTable = comboBoxV.Text;
            callingTable.Value.Calling(dataGridView1, nameTable);
        }
        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            string nameTable = textAddJ.Text;
            new Thread(() => { addTable.Value.СreateTable(nameTable); }).Start();
            textAddJ.Clear();
        }
    }
}
