
namespace JournalOfElectricityMeteringDevices
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.buttonChangeBackground = new System.Windows.Forms.Button();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.buttonImportExcel = new System.Windows.Forms.Button();
            this.panelSQL = new System.Windows.Forms.Panel();
            this.labelCommandSelest = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSELECT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBlue = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelBackground.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.panelBackground);
            this.panel1.Controls.Add(this.panelSettings);
            this.panel1.Controls.Add(this.panelSQL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 761);
            this.panel1.TabIndex = 0;
            // 
            // panelBackground
            // 
            this.panelBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelBackground.Controls.Add(this.pictureBox3);
            this.panelBackground.Controls.Add(this.pictureBlue);
            this.panelBackground.Location = new System.Drawing.Point(305, 139);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(250, 200);
            this.panelBackground.TabIndex = 24;
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelSettings.AutoSize = true;
            this.panelSettings.Controls.Add(this.buttonChangeBackground);
            this.panelSettings.Controls.Add(this.buttonExportExcel);
            this.panelSettings.Controls.Add(this.buttonImportExcel);
            this.panelSettings.Location = new System.Drawing.Point(-250, 122);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(300, 545);
            this.panelSettings.TabIndex = 0;
            // 
            // buttonChangeBackground
            // 
            this.buttonChangeBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChangeBackground.FlatAppearance.BorderSize = 0;
            this.buttonChangeBackground.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonChangeBackground.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonChangeBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeBackground.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeBackground.Location = new System.Drawing.Point(46, 86);
            this.buttonChangeBackground.Name = "buttonChangeBackground";
            this.buttonChangeBackground.Size = new System.Drawing.Size(200, 80);
            this.buttonChangeBackground.TabIndex = 2;
            this.buttonChangeBackground.Text = "Изменить Фон ";
            this.buttonChangeBackground.UseVisualStyleBackColor = true;
            this.buttonChangeBackground.Click += new System.EventHandler(this.buttonChangeBackground_Click);
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportExcel.FlatAppearance.BorderSize = 0;
            this.buttonExportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExportExcel.Location = new System.Drawing.Point(46, 228);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(200, 80);
            this.buttonExportExcel.TabIndex = 1;
            this.buttonExportExcel.Text = "Экспорт в Excel ";
            this.buttonExportExcel.UseVisualStyleBackColor = true;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // buttonImportExcel
            // 
            this.buttonImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImportExcel.FlatAppearance.BorderSize = 0;
            this.buttonImportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonImportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImportExcel.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImportExcel.Location = new System.Drawing.Point(46, 370);
            this.buttonImportExcel.Name = "buttonImportExcel";
            this.buttonImportExcel.Size = new System.Drawing.Size(200, 80);
            this.buttonImportExcel.TabIndex = 0;
            this.buttonImportExcel.Text = "Импорт из Еxcel";
            this.buttonImportExcel.UseVisualStyleBackColor = true;
            this.buttonImportExcel.Click += new System.EventHandler(this.buttonImportExcel_Click);
            // 
            // panelSQL
            // 
            this.panelSQL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSQL.Controls.Add(this.labelCommandSelest);
            this.panelSQL.Controls.Add(this.buttonSelect);
            this.panelSQL.Controls.Add(this.label8);
            this.panelSQL.Controls.Add(this.textBoxSELECT);
            this.panelSQL.Location = new System.Drawing.Point(69, 152);
            this.panelSQL.Name = "panelSQL";
            this.panelSQL.Size = new System.Drawing.Size(1121, 608);
            this.panelSQL.TabIndex = 3;
            // 
            // labelCommandSelest
            // 
            this.labelCommandSelest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCommandSelest.AutoSize = true;
            this.labelCommandSelest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCommandSelest.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCommandSelest.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.labelCommandSelest.Location = new System.Drawing.Point(739, 570);
            this.labelCommandSelest.Name = "labelCommandSelest";
            this.labelCommandSelest.Size = new System.Drawing.Size(143, 19);
            this.labelCommandSelest.TabIndex = 23;
            this.labelCommandSelest.Text = "команды запросов ";
            this.labelCommandSelest.Click += new System.EventHandler(this.labelCommandSelest_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelect.FlatAppearance.BorderSize = 0;
            this.buttonSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelect.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSelect.Location = new System.Drawing.Point(888, 553);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(200, 52);
            this.buttonSelect.TabIndex = 22;
            this.buttonSelect.Text = "SELECT";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(467, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 27);
            this.label8.TabIndex = 21;
            this.label8.Text = "Command MySQL ";
            // 
            // textBoxSELECT
            // 
            this.textBoxSELECT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSELECT.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.textBoxSELECT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSELECT.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSELECT.Location = new System.Drawing.Point(27, 58);
            this.textBoxSELECT.Multiline = true;
            this.textBoxSELECT.Name = "textBoxSELECT";
            this.textBoxSELECT.Size = new System.Drawing.Size(1061, 489);
            this.textBoxSELECT.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1195, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MT Extra", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label2.Location = new System.Drawing.Point(1164, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MediumAquamarine;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(69, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1121, 545);
            this.dataGridView1.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(133, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 150);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBlue
            // 
            this.pictureBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBlue.Location = new System.Drawing.Point(16, 23);
            this.pictureBlue.Name = "pictureBlue";
            this.pictureBlue.Size = new System.Drawing.Size(100, 150);
            this.pictureBlue.TabIndex = 0;
            this.pictureBlue.TabStop = false;
            this.pictureBlue.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(16, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 150);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBackground.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSQL.ResumeLayout(false);
            this.panelSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Panel panelSQL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangeBackground;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.Button buttonImportExcel;
        private System.Windows.Forms.Label labelCommandSelest;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSELECT;
        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBlue;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

