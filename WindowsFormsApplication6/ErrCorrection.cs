using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace Replece_error_XML
{
    class ErrCorrection
    {
        #region variable
        string NameFilePM, NameFileSM, NameFileLM, NameFileSTM, NameFileHM;
        XDocument XmlDocHM, XmlDocSM, XmlDocLM;
        #endregion


        private void LoadHm(string nameHm)  // загрузка файла HM
        {
            if (System.IO.File.Exists(nameHm))
            {
                XmlDocHM = XDocument.Load(nameHm);
            }
            else
            {
                Logger.Log.Warn("Файл HM не найден");
                return;
            }
        }

        private void LoadPM() // Загрузка файла PM
        {
            if (System.IO.File.Exists(NameFilePM))
            {
                XmlDocSM = XDocument.Load(NameFilePM); //   загружаем файл PM
            }
            else if (System.IO.File.Exists(NameFileSM))
            {
                XmlDocSM = XDocument.Load(NameFileSM); //   загружаем файл SM
            }
            else if (System.IO.File.Exists(NameFileSTM))
            {
                XmlDocSM = XDocument.Load(NameFileSTM); //   загружаем файл SM высокотехнологичной

            }
            else
            {
                Logger.Log.Warn("Файл PM/SM не найден");
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
                Logger.Log.Warn("Файл LM не найден");
                return;
            }
        }
    }
}
