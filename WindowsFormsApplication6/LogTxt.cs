using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Replece_error_XML
{
    class LogTxt
    {
        public static void addLogFile(
            string path, //имя файла
            string nusl, // номер случая
            string nameV // имя процедуры
            )
        {
            path = path.Replace(".xml", "Log.txt");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(nusl + " " + nameV);
                sw.Close();
            }
        }

    }
}
