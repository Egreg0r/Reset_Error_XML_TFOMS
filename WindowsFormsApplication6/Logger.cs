using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Replece_error_XML
{

    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
