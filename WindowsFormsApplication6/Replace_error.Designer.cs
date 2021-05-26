namespace Replece_error_XML
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Error = new System.Windows.Forms.TabPage();
            this.groupBoxStac = new System.Windows.Forms.GroupBox();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonOleDb = new System.Windows.Forms.Button();
            this.buttonStPrem = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkedListStac = new System.Windows.Forms.CheckedListBox();
            this.buttonRepCheck = new System.Windows.Forms.Button();
            this.groupBoxJK = new System.Windows.Forms.GroupBox();
            this.button_repPRVS = new System.Windows.Forms.Button();
            this.SpecFic280 = new System.Windows.Forms.Button();
            this.checkedListPol = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonRepCheclPol = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFile2Name = new System.Windows.Forms.TextBox();
            this.textBoxCodError = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDellTfomsError = new System.Windows.Forms.Button();
            this.dataGridViewDbf = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataSet1 = new Replece_error_XML.DataSet1();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Error.SuspendLayout();
            this.groupBoxStac.SuspendLayout();
            this.groupBoxJK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDbf)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "(*.xml)|*.xml";
            this.openFileDialog1.InitialDirectory = "W:\\!ОТЧЕТЫ 2016 ГОД";
            // 
            // Error
            // 
            this.Error.Controls.Add(this.dataGridViewDbf);
            this.Error.Controls.Add(this.buttonDellTfomsError);
            this.Error.Controls.Add(this.label1);
            this.Error.Controls.Add(this.label3);
            this.Error.Controls.Add(this.label2);
            this.Error.Controls.Add(this.textBoxFileName);
            this.Error.Controls.Add(this.textBoxCodError);
            this.Error.Controls.Add(this.textBoxFile2Name);
            this.Error.Controls.Add(this.button2);
            this.Error.Controls.Add(this.button1);
            this.Error.Controls.Add(this.groupBoxJK);
            this.Error.Controls.Add(this.groupBoxStac);
            this.Error.Location = new System.Drawing.Point(4, 22);
            this.Error.Name = "Error";
            this.Error.Padding = new System.Windows.Forms.Padding(3);
            this.Error.Size = new System.Drawing.Size(914, 538);
            this.Error.TabIndex = 0;
            this.Error.Text = "Ошибки";
            this.Error.UseVisualStyleBackColor = true;
            // 
            // groupBoxStac
            // 
            this.groupBoxStac.Controls.Add(this.buttonRepCheck);
            this.groupBoxStac.Controls.Add(this.checkedListStac);
            this.groupBoxStac.Controls.Add(this.button5);
            this.groupBoxStac.Controls.Add(this.buttonStPrem);
            this.groupBoxStac.Controls.Add(this.buttonOleDb);
            this.groupBoxStac.Controls.Add(this.buttonReplace);
            this.groupBoxStac.Location = new System.Drawing.Point(456, 88);
            this.groupBoxStac.Name = "groupBoxStac";
            this.groupBoxStac.Size = new System.Drawing.Size(440, 145);
            this.groupBoxStac.TabIndex = 14;
            this.groupBoxStac.TabStop = false;
            this.groupBoxStac.Text = "Сационар";
            // 
            // buttonReplace
            // 
            this.buttonReplace.Enabled = false;
            this.buttonReplace.Location = new System.Drawing.Point(6, 48);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(148, 23);
            this.buttonReplace.TabIndex = 0;
            this.buttonReplace.Text = "Удаление USL из SM";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonOleDb
            // 
            this.buttonOleDb.Location = new System.Drawing.Point(6, 19);
            this.buttonOleDb.Name = "buttonOleDb";
            this.buttonOleDb.Size = new System.Drawing.Size(148, 23);
            this.buttonOleDb.TabIndex = 6;
            this.buttonOleDb.Text = "Проверить dbf";
            this.buttonOleDb.UseVisualStyleBackColor = true;
            this.buttonOleDb.Click += new System.EventHandler(this.buttonOleDb_Click);
            // 
            // buttonStPrem
            // 
            this.buttonStPrem.Location = new System.Drawing.Point(7, 78);
            this.buttonStPrem.Name = "buttonStPrem";
            this.buttonStPrem.Size = new System.Drawing.Size(147, 23);
            this.buttonStPrem.TabIndex = 10;
            this.buttonStPrem.Text = "Ext 3  для приемника СТ";
            this.buttonStPrem.UseVisualStyleBackColor = true;
            this.buttonStPrem.Click += new System.EventHandler(this.buttonStPrem_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 108);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Пер. Иск вент";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkedListStac
            // 
            this.checkedListStac.CheckOnClick = true;
            this.checkedListStac.FormattingEnabled = true;
            this.checkedListStac.Items.AddRange(new object[] {
            "Исправ. Новорожденных",
            "Профиль койки 39 дет. реан"});
            this.checkedListStac.Location = new System.Drawing.Point(170, 19);
            this.checkedListStac.Name = "checkedListStac";
            this.checkedListStac.Size = new System.Drawing.Size(238, 34);
            this.checkedListStac.Sorted = true;
            this.checkedListStac.TabIndex = 20;
            // 
            // buttonRepCheck
            // 
            this.buttonRepCheck.Location = new System.Drawing.Point(170, 106);
            this.buttonRepCheck.Name = "buttonRepCheck";
            this.buttonRepCheck.Size = new System.Drawing.Size(132, 25);
            this.buttonRepCheck.TabIndex = 21;
            this.buttonRepCheck.Text = "Исправить";
            this.buttonRepCheck.UseVisualStyleBackColor = true;
            this.buttonRepCheck.Click += new System.EventHandler(this.buttonRepCheck_Click);
            // 
            // groupBoxJK
            // 
            this.groupBoxJK.Controls.Add(this.buttonRepCheclPol);
            this.groupBoxJK.Controls.Add(this.button4);
            this.groupBoxJK.Controls.Add(this.checkedListPol);
            this.groupBoxJK.Controls.Add(this.SpecFic280);
            this.groupBoxJK.Controls.Add(this.button_repPRVS);
            this.groupBoxJK.Location = new System.Drawing.Point(20, 88);
            this.groupBoxJK.Name = "groupBoxJK";
            this.groupBoxJK.Size = new System.Drawing.Size(419, 145);
            this.groupBoxJK.TabIndex = 13;
            this.groupBoxJK.TabStop = false;
            this.groupBoxJK.Text = "ЖК";
            // 
            // button_repPRVS
            // 
            this.button_repPRVS.Enabled = false;
            this.button_repPRVS.Location = new System.Drawing.Point(8, 49);
            this.button_repPRVS.Name = "button_repPRVS";
            this.button_repPRVS.Size = new System.Drawing.Size(163, 23);
            this.button_repPRVS.TabIndex = 10;
            this.button_repPRVS.Text = "Исправить Profil 160 ";
            this.button_repPRVS.UseVisualStyleBackColor = true;
            this.button_repPRVS.Click += new System.EventHandler(this.button_repPRVS_Click);
            // 
            // SpecFic280
            // 
            this.SpecFic280.Enabled = false;
            this.SpecFic280.Location = new System.Drawing.Point(8, 78);
            this.SpecFic280.Name = "SpecFic280";
            this.SpecFic280.Size = new System.Drawing.Size(161, 23);
            this.SpecFic280.TabIndex = 16;
            this.SpecFic280.Text = "Исп. у врачей 280,281";
            this.SpecFic280.UseVisualStyleBackColor = true;
            this.SpecFic280.Click += new System.EventHandler(this.SpecFic280_Click);
            // 
            // checkedListPol
            // 
            this.checkedListPol.FormattingEnabled = true;
            this.checkedListPol.Items.AddRange(new object[] {
            "Исп. Приемника",
            "Удал. зап. (опц.)"});
            this.checkedListPol.Location = new System.Drawing.Point(175, 19);
            this.checkedListPol.Name = "checkedListPol";
            this.checkedListPol.Size = new System.Drawing.Size(238, 34);
            this.checkedListPol.TabIndex = 22;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 108);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Исп. Поез здор";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonRepCheclPol
            // 
            this.buttonRepCheclPol.Location = new System.Drawing.Point(282, 106);
            this.buttonRepCheclPol.Name = "buttonRepCheclPol";
            this.buttonRepCheclPol.Size = new System.Drawing.Size(131, 26);
            this.buttonRepCheclPol.TabIndex = 23;
            this.buttonRepCheclPol.Text = "Исправить";
            this.buttonRepCheclPol.UseVisualStyleBackColor = true;
            this.buttonRepCheclPol.Click += new System.EventHandler(this.buttonRepCheclPol_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Обзор";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(364, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Обзор";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxFile2Name
            // 
            this.textBoxFile2Name.Location = new System.Drawing.Point(80, 62);
            this.textBoxFile2Name.Name = "textBoxFile2Name";
            this.textBoxFile2Name.ReadOnly = true;
            this.textBoxFile2Name.Size = new System.Drawing.Size(278, 20);
            this.textBoxFile2Name.TabIndex = 16;
            // 
            // textBoxCodError
            // 
            this.textBoxCodError.Location = new System.Drawing.Point(533, 42);
            this.textBoxCodError.Name = "textBoxCodError";
            this.textBoxCodError.ReadOnly = true;
            this.textBoxCodError.Size = new System.Drawing.Size(49, 20);
            this.textBoxCodError.TabIndex = 4;
            this.textBoxCodError.Text = "523";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(80, 20);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(278, 20);
            this.textBoxFileName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Код ошибки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "VHM xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "HM Xml";
            // 
            // buttonDellTfomsError
            // 
            this.buttonDellTfomsError.Enabled = false;
            this.buttonDellTfomsError.Location = new System.Drawing.Point(463, 13);
            this.buttonDellTfomsError.Name = "buttonDellTfomsError";
            this.buttonDellTfomsError.Size = new System.Drawing.Size(119, 23);
            this.buttonDellTfomsError.TabIndex = 19;
            this.buttonDellTfomsError.Text = "Убрать VHM из HM";
            this.buttonDellTfomsError.UseVisualStyleBackColor = true;
            this.buttonDellTfomsError.Click += new System.EventHandler(this.buttonDellTfomsError_Click);
            // 
            // dataGridViewDbf
            // 
            this.dataGridViewDbf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDbf.Location = new System.Drawing.Point(18, 264);
            this.dataGridViewDbf.Name = "dataGridViewDbf";
            this.dataGridViewDbf.Size = new System.Drawing.Size(878, 268);
            this.dataGridViewDbf.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Error);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 564);
            this.tabControl1.TabIndex = 20;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.инфоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // инфоToolStripMenuItem
            // 
            this.инфоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.инфоToolStripMenuItem.Name = "инфоToolStripMenuItem";
            this.инфоToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.инфоToolStripMenuItem.Text = "Инфо";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 610);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Исправление ошибок";
            this.Error.ResumeLayout(false);
            this.Error.PerformLayout();
            this.groupBoxStac.ResumeLayout(false);
            this.groupBoxJK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDbf)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Replece_error_XML.DataSet1 dataSet1;
        private System.Windows.Forms.TabPage Error;
        private System.Windows.Forms.DataGridView dataGridViewDbf;
        private System.Windows.Forms.Button buttonDellTfomsError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox textBoxCodError;
        private System.Windows.Forms.TextBox textBoxFile2Name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxJK;
        private System.Windows.Forms.Button buttonRepCheclPol;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckedListBox checkedListPol;
        private System.Windows.Forms.Button SpecFic280;
        private System.Windows.Forms.Button button_repPRVS;
        private System.Windows.Forms.GroupBox groupBoxStac;
        private System.Windows.Forms.Button buttonRepCheck;
        private System.Windows.Forms.CheckedListBox checkedListStac;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonStPrem;
        private System.Windows.Forms.Button buttonOleDb;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инфоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

