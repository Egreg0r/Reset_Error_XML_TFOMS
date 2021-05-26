using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.OleDb;
using System.IO;


namespace Replece_error_XML
{
    public partial class Form1 : Form
    {
        #region PUBLIC Variable
        public string NameFilePM, NameFileSM, NameFileLM, NameFileSTM, NameFileHM; // Пути к загружаемым файлам.
        public XDocument XmlDocHM, XmlDocPM, XmlDocLM; // переменные файлов обмена
        #endregion

        #region VOID
        private void LoadHm()  // загрузка файла HM
        {
            if (System.IO.File.Exists(textBoxFileName.Text))
            {
                XmlDocHM = XDocument.Load(NameFileHM);
            }
            else
            {
                MessageBox.Show("Файл HM не обнаружен в каталоге");
                return;
            }
        }

        private void LoadPM() // Загрузка файла PM
        {
            if (System.IO.File.Exists(NameFilePM))
            {
                XmlDocPM = XDocument.Load(NameFilePM); //   загружаем файл PM
            }
            else if (System.IO.File.Exists(NameFileSM))
            {
                XmlDocPM = XDocument.Load(NameFileSM); //   загружаем файл SM
            }
            else if (System.IO.File.Exists(NameFileSTM))
            {
                XmlDocPM = XDocument.Load(NameFileSTM); //   загружаем файл SM высокотехнологичной

            }
            else
            {
                MessageBox.Show("Файл SM или PM не обнаружен в каталоге");
                return;
            }
        }

        private void LoadLm()  // загрузка файла LM
        {
            if (System.IO.File.Exists(NameFileLM))
            {
                XmlDocLM = XDocument.Load(NameFileLM);
            }
            else
            {
                MessageBox.Show("Файл LM не обнаружен в каталоге");
                return;
            }
        }

        private void replaceUSL() // Удаление USL из доп файла SM которых нет в  основном файле HM (не работает) 13.02.2019
        {
            int n = 0; // счетчик

            LoadHm();
            LoadPM();

            // Выборка структур  удалениие USL из SM не содержащихся в HM

            var DocPM = from Usl in XmlDocPM.Root.Descendants("USL").AsParallel()
                        where (!(XmlDocHM.Descendants("Z_SL").Elements("USL").Any(x => x.Element("IDSERV").Value == Usl.Element("IDSERV").Value)))
                        select Usl;
            n = DocPM.Count();
            DocPM.Remove();
            MessageBox.Show("изменено " + n + " записей");
            XmlDocPM.Save(NameFileSM + "1");

        }

        private void ispPriemnica() // Исправление записей для случаев отказа в госпитализации в приемном отделении
        {
            LoadHm();
            int n = 0;
            IEnumerable<XElement> ber;
            List<string> nusl = new List<string>(); // номера случаев
            ber = XmlDocHM.Root.Descendants("ZAP").Where(x => x.Element("Z_SL").Element("SL").Element("PROFIL").Value == "160").ToList();
            foreach (var x in ber)
            {
                x.Element("Z_SL").SetElementValue("VIDPOM", "13");
                //x.Element("Z_SL").SetElementValue("IDSP", "41");
                try
                {
                    x.Element("Z_SL").Element("SL").Element("P_CEL").SetValue("1.1");
                }
                catch { }
                try
                {
                    x.Element("Z_SL").Element("EXTR").Remove();
                }
                catch { }
                nusl.Add(x.Element("Z_SL").Element("IDCASE").Value.ToString());
                n = n + 1;
                LogTxt.addLogFile(NameFileHM, x.Element("N_ZAP").Value.ToString(), "Исп.Приемника");
            }
            LogTxt.addLogFile(NameFileSM, "----Завершено. Изменено " + n, " записей ----");

            ber = ber.Where(x => x.Element("PACIENT").Element("SMO_OK").Value != "05000").ToList(); // исправление Profil у инокраевых 
            int g = 0;
            foreach (var x in ber)
            {
                try
                {
                    x.Element("Z_SL").Element("SL").Element("PROFIL").Value = "136";
                    g = g + 1;
                    LogTxt.addLogFile(NameFileHM, x.Element("N_ZAP").Value.ToString(), "Исп.Приемника (Инокраевой)");
                }
                catch { };
            }
            LogTxt.addLogFile(NameFileSM, "----Завершено. Изменено " + g, " записей ----");
            XmlDocHM.Save(NameFileHM);

            //Проставляем посещение поликлиники в PM для случаев отказака от госпитализации  
            int m = 0;
            LoadPM();
            IEnumerable<XElement> berP;
            for (int i = 0; i < nusl.Count; i++)
            {
                berP = XmlDocPM.Root.Descendants("SL").Where(x => x.Element("SL_ID").Value == nusl[i]);
                //ber = XmlDocPM.Root.Descendants("SL").Where(x => x.Element("SPECFIC").Value == "232").ToList();
                foreach (var x in berP)
                {
                    x.SetElementValue("VISIT_POL", "1");
                    m = m + 1;
                    LogTxt.addLogFile(NameFileSM, x.Element("IDCASE").Value.ToString(), "Исп.Приемника"  );
                }
            }
            LogTxt.addLogFile(NameFileSM, "----Завершено. Изменено " + m, " записей ----");
            XmlDocPM.Save(NameFilePM);

            MessageBox.Show("Исправленно " + n + " записей в файлах HM и " + m + " в PM"); //сообщение о кол-ве исправ записей
        }

        private void novorgden() // изменение особый случай на 0 для новорожденных с регистрацией
        {
            LoadHm();
            int n = 0, m = 0;
            try
            {
                var ber = from x in XmlDocHM.Descendants("ZAP")
                          where (x.Element("PACIENT").Element("NOVOR").Value != "0") & ((string)x.Element("Z_SL").Element("OS_SLUCH") != "2") & (x.Element("Z_SL").Element("SL").Element("PROFIL").Value == "55")
                          select x.Element("Z_SL");

                //(string)x.Element("Z_SL").Value ?? ""

                foreach (var x in ber)
                {
                    x.SetElementValue("OS_SLUCH", "2");
                    n++;
                    LogTxt.addLogFile(NameFileHM, x.Element("IDCASE").Value.ToString(), "Исправ новорожденных OS_SLUCH = 2");
                }

                
                ber = from x in XmlDocHM.Descendants("ZAP")
                      where (x.Element("PACIENT").Element("NOVOR").Value == "0") & (x.Element("Z_SL").Element("SL").Element("PROFIL").Value == "55") & ((string)x.Element("Z_SL").Element("OS_SLUCH") != "")
                      select x.Element("Z_SL");
                foreach (var x in ber)
                {
                    x.Element("OS_SLUCH").Remove();
                    m++;
                    LogTxt.addLogFile(NameFileHM, x.Element("IDCASE").Value.ToString(), "Исправ новорожденных OS_SLUCH = 0");
                }
                

                XmlDocHM.Save(textBoxFileName.Text);
                MessageBox.Show("Исправленно " + n + " записей OS_SLUCH=2, и " +m+ " записей OS_SLUCH = 0");
            }

            catch { MessageBox.Show("Ошибка при выполнении процедуры novorgden"); return; }
        }

        private void profil39() // Замена Prof_k = 13 на 39  для детской реанимации 
        {
            LoadHm();
            int n = 0;
            try
            {
                IEnumerable<XElement> ber = XmlDocHM.Root.Descendants("Z_SL").Elements("SL").Where(x => (x.Element("PROFIL_K").Value == "13")).ToList();

                foreach (var x in ber)
                {
                    x.SetElementValue("PROFIL_K", "39");
                    n = n + 1;
                    LogTxt.addLogFile(NameFileHM, x.Element("SL_ID").Value.ToString(), "Койки в детской реанимации на 39");
                }
                XmlDocHM.Save(textBoxFileName.Text);
                MessageBox.Show("Исправленно " + n + " записей"); //сообщение о кол-ве исправ записей
            }
            catch
            { MessageBox.Show("Записей с PROFIL_K = 13 не найдено"); }
        }



        // Удаление ненужных строк из факлов ( в данном случае строки с неправильными кодами у номенклатуры у приемных врачей)
        private void lineDel()
        {
            LoadHm();
            LoadPM();
            int n = 0;
            try
            {
                var ber = from x in XmlDocHM.Descendants("USL")
                          where (string)x.Element("CODE_USL") == "B01.001.001"
                          select x;
                foreach (var x in ber)
                {
                    XmlDocPM.Descendants("USL").Where(y => (y.Element("IDSERV").Value == x.Element("IDSERV").Value)).Remove();
                    LogTxt.addLogFile(NameFilePM, x.Element("IDSERV").Value.ToString(), "Удаление строк (опц)");
                    LogTxt.addLogFile(NameFileHM, x.Element("IDSERV").Value.ToString(), "Удаление строк (опц)");
                    n++;
                }
                XmlDocHM.Descendants("USL").Where(x => (x.Element("CODE_USL").Value.ToString() == "B01.001.001")).Remove();

                MessageBox.Show("Исправленно " + n + " записей ");
            }
            catch (Exception ex)
            {
                MessageBox.Show( "При удалении строк возникла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log.Error(XmlDocHM + " При обработке команды LineDell()" + " возникла ошибка " + ex);
                return;
            }

            XmlDocHM.Save(NameFileHM);
            XmlDocPM.Save(NameFilePM);
            Logger.Log.Info(String.Format("{0} успешно завершена. Исправленно {1} записей", "lineDel", n));

        }

        /*
        private void perevodnie() // исправление вида перевода P_PER=4 
        {
            LoadHm();
            int n = 0;
            try
            {
                var ber = from p in XmlDocHM.Descendants("ZAP").Elements("Z_SL")
                          where (p.Element("OS_SLUCH").NextNode.ToString() == "<VB_P>1</VB_P>") & ((p.Element("SL").Element("P_PER").Value == "3"))
                          select p;


                foreach (var p in ber)
                {
                    p.Element("SL").SetElementValue("P_PER", "4");
                    //p.Element("SL").Element("P_PER").SetValue("4");
                    n++;
                    LogTxt.addLogFile(NameFileHM, p.Element("IDCASE").Value.ToString(), "P_Per=4");
                }
                XmlDocHM.Save(textBoxFileName.Text);

                MessageBox.Show("Исправленно " + n + " записей переводных  Где P_PER был равен 3 и RSLT = 101");
            }

            catch (Exception ex) { MessageBox.Show("Ошибка при выполнении процедуры perevodnie "); return; }
        }
        */

        #endregion

        public Form1()
        {
            
            InitializeComponent();
            Logger.Log.Info("Запуск программы");

        }
        

        private void buttonReplace_Click(object sender, EventArgs e) // Удаление USL из доп файла SM которых нет в  основном файле HM
        {
            replaceUSL();
        }

        private void buttonOleDb_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adapter;
            DataSet ds = new DataSet();
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\base;Extended Properties=dBase IV;"; //User ID = Admin; Password =;;
            var dBaseConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            //  OleDbCommand AR = new OleDbCommand("select * from AR200605", dBaseConnection); 
            try        // проверка на доступ к базе
            {
                dBaseConnection.Open();
                //  OleDbDataReader reader = AR.ExecuteReader();
                string Sql = "select NUSL from AR203607 where I_TYPE = " + textBoxCodError.Text;
                adapter = new OleDbDataAdapter(Sql, connectionString);
                adapter.Fill(ds);
                dataGridViewDbf.DataSource = ds.Tables[0];
                dBaseConnection.Close();
            }
            catch (Exception ex) //сообщение о недоступности базы
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
        }

        private void button_repPRVS_Click(object sender, EventArgs e) 
        {
            LoadHm();            // загружаем файл HM
            int n = 0;

              // Исправление PROFIL в USL у кольпоскопии ЖК
            string row = "A03.20.001"; //значение необходимой ячейки
           
            IEnumerable<XElement> Iddoct = XmlDocHM.Root.Descendants("USL").Where(x => x.Element("VID_VME").Value == row).ToList(); 
            foreach (XElement x in Iddoct) // обработка каждого x элеманта
            {
                x.SetElementValue("PROFIL", "136");
                n = n + 1;
            }

            XmlDocHM.Save(textBoxFileName.Text);
            MessageBox.Show("Исправленно " + n + " записей"); //сообщение о кол-ве исправ записей

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (openFileDialog1)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxFileName.Text = openFileDialog1.FileName;
                    NameFileHM = textBoxFileName.Text;
                }
            }
            if (textBoxFileName.Text.Contains("HM"))
                {
                NameFilePM = textBoxFileName.Text.Replace("HM", "PM");
                NameFileLM = textBoxFileName.Text.Replace("HM", "LM");
                NameFileSM = textBoxFileName.Text.Replace("HM", "SM");
            };
            if (textBoxFileName.Text.Contains("TM"))
            {
                NameFileSTM = textBoxFileName.Text.Replace("TM", "SM");
                NameFileSM = NameFileSTM;
            }
        }


        private void buttonDellTfomsError_Click(object sender, EventArgs e) // Убрать записи VHM из HM
        {
            string NameFilePM = textBoxFileName.Text.Replace("HM", "PM");
            var XmlDocHM = XDocument.Load(textBoxFileName.Text);            // загружаем файл HM
            var XmlDocPM = XDocument.Load(NameFilePM);       //   загружаем файл PM
            var XmlDocVHM = XDocument.Load(textBoxFile2Name.Text);   // загружаем файл VHM ошибок
            int n = 0;
            IEnumerable<XElement> Nzap = from x in XmlDocHM.Root.Descendants("ZAP") select x;
            foreach (XElement x in Nzap)
            {
                n = n + 1;
            }
            IEnumerable<XElement> DelNzap = from el in XmlDocVHM.Root.Descendants("N_ZAP") select el;
            foreach (XElement el in DelNzap)
            {
                Nzap.Where(x => x.Element("N_ZAP").Value == el.Value).Remove();   // Удаление записей VHM из HM
                XmlDocPM.Root.Descendants("Z_SL").Where(p => p.Element("IDCASE").Value == el.Value).Remove();
            }
            foreach (XElement x in Nzap)
            {
                // Console.WriteLine(x.Element("N_ZAP"));
                n = n - 1;
            }
            XmlDocHM.Save(textBoxFileName.Text.Replace("HM", "WtHM"));
            XmlDocPM.Save(NameFilePM.Replace("PM", "WtPM"));
            MessageBox.Show("Удалено " + n + " записей");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (openFileDialog1)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxFile2Name.Text = openFileDialog1.FileName;
                }
            }
        }

        // инфо о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vp =  Application.ProductVersion.ToString();
            MessageBox.Show("Версия продукта: " + vp, "Version", MessageBoxButtons.OK);
        }

        // Открыть папку с расположением файлов
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = Path.GetDirectoryName(NameFileHM);
            System.Diagnostics.Process.Start("explorer", name);
        }

        private void SpecFic280_Click(object sender, EventArgs e)
        {
            // исправляем записи в специальностях 280 и 281
            LoadHm();
            int n = 0;

            IEnumerable<XElement> ber = XmlDocHM.Root.Descendants("Z_SL").Where(x => (x.Element("PRVS").Value == "0") || (x.Element("PROFIL").Value == "")).ToList();
            //IEnumerable<XElement> ber = XmlDocHM.Root.Descendants("Z_SL").Where(x => (x.Element("PRVS").Value == "0")).ToList();
            foreach (var x in ber)
            {
                x.SetElementValue("VIDPOM", "13");
                x.SetElementValue("PRVS", "8");
                x.SetElementValue("PROFIL", "136");
                n = n + 1;
            }
            XmlDocHM.Save(textBoxFileName.Text);
            MessageBox.Show("Исправленно " + n + " записей"); //сообщение о кол-ве исправ записей

        }

        private void button4_Click(object sender, EventArgs e)  // исправление D_TYPE = Z для поезда здоровья
        {
            LoadPM();
            int n = 0;

            IEnumerable<XElement> ber = XmlDocPM.Root.Descendants("Z_SL").Where(x => (x.Element("PURP").Value == "33") || (x.Element("PURP").Value == "32")).ToList();
            foreach (var x in ber)
            {
                x.SetElementValue("D_TYPE", "Z");
                n = n + 1;
            }
            XmlDocPM.Save(NameFilePM);
            MessageBox.Show("Исправленно " + n + " записей"); //сообщение о кол-ве исправ записей
        }

        private void button5_Click(object sender, EventArgs e) // изменение кодировки услоги ИВЛ
        {
            LoadPM();
            LoadHm();
            int n = 0;
            try
            {
                var ber = from x in XmlDocHM.Descendants("USL")
                          where x.Element("CODE_USL").Value == "A16.09.011"
                          select x.Element("IDSERV").Value;


                foreach (var x in ber)
                {
                    var ber1 = XmlDocPM.Descendants("USL").Where(y => (y.Element("IDSERV").Value == x));
                    foreach (var y in ber1)
                    {
                        y.SetElementValue("PR_USL", "2");
                        Console.WriteLine(y.Element("IDSERV").Value);
                    }
                    n = n + 1;
                }
                XmlDocPM.Save(NameFileSM);
            }
            catch { n = 504847; }
            MessageBox.Show("Исправленно " + n + " записей"); //сообщение о кол-ве исправ записей
            

        }

     

        private void buttonRepCheck_Click(object sender, EventArgs e)
        {
            foreach (int x in checkedListStac.CheckedIndices)
            {
                switch (x)
                {
                    case 0:
                        Console.WriteLine("0");
                        novorgden();
                        checkedListStac.SetItemChecked(x, false);
                        break;
                    case 1:
                        Console.WriteLine("1");
                        profil39();
                        break;
                }
                checkedListStac.SetItemChecked(x, false);

            }

        }

        private void buttonRepCheclPol_Click(object sender, EventArgs e) // Исправление списка ошибок по поликлинике
        {
            foreach (int x in checkedListPol.CheckedIndices)
            {
                switch (x)
                {
                    case 0:
                        Console.WriteLine("0");
                        ispPriemnica();
                        break;
                    case 1:
                        Console.WriteLine("1");
                        lineDel();
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                }
                checkedListStac.SetItemChecked(x, false);

            }
        }


        /* private void button_41KSG_Click(object sender, EventArgs e)
         {
             LoadHm();
             LoadPM();
             int n = 0;
             try
             {
                 var ber = from x in XmlDocHM.Descendants("Z_SL")
                           where (x.Element("DS1").Value == "O80.0")
                           select x.Element("IDCASE");
                 foreach (var x in ber)
                 {
                     x.SetElementValue("OS_SLUCH", "0");
                     n++;
                 }
                 XmlDocHM.Save(textBoxFileName.Text);
                 MessageBox.Show("Исправленно " + n + " записей OS_SLUCH");
             }
             catch { MessageBox.Show("Ошибка при выполнении процедуры"); return; }
         }
         */

        private void buttonStPrem_Click(object sender, EventArgs e) // изменение Ext = 3 для form_pom = 2 приемник стационара, удаление NHISTORY
        {
            //var XmlDocHM = XDocument.Load(textBoxFileName.Text);            // загружаем файл
            int n = 0; 

            if (XmlDocHM.Root.Descendants("Z_SL").Where(x => x.Element("FOR_POM").Value == "2").FirstOrDefault() != null) //Проверка на существование значения в файле.
            {
                var DocHM = XmlDocHM.Root.Descendants("Z_SL").Where(x => x.Element("FOR_POM").Value == "2").ToList();
                foreach (var zap in DocHM)
                {
                    if ((zap.Element("EXTR").Value != "3") && (zap.Element("NHISTORY").Value != "0"))
                    {
                        zap.SetElementValue("EXTR", "3");
                        zap.SetElementValue("NHISTORY", "0");
                        n = n + 1;
                    }
                    else
                    {

                        if (zap.Element("NHISTORY") == null)
                        {
                            n = n + 1;
                            zap.Element("DET").AddAfterSelf(new XElement("NHISTORY", "0"));
                        }
                    }
                }
                XmlDocHM.Save(textBoxFileName.Text);
                MessageBox.Show("Исправленно " + n + " записей");
            }
            else MessageBox.Show("Нет записей с FORM_POM = 2");
            n = 0;
            //  доделать !!!!!!!!!!
        }
    }
}

