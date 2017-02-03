using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FilesConverter.Sales;

namespace FilesConverter
{

    public class LogWriter
    {
        private string _logFilePath = string.Empty;
        public LogWriter(/*CommonResultList commonResultList*/)
        {
           // LogWrite(commonResultList);
        }

        public void LogWrite(CommonResultList commonResultList)
        {
            _logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(_logFilePath + @"\" + "log.txt"))
                {
                    Log(commonResultList, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(CommonResultList commonResultList, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                var logMessageList = commonResultList.GetInformationForLogging();
                foreach (var logMessage in logMessageList)
                {
                    txtWriter.WriteLine("  {0}", logMessage);
                }
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

        public void LogException(Exception e)
        {
            
            _logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(_logFilePath + @"\" + "log.txt"))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
                    w.WriteLine("  {0}", e.Message);
                    if(e.InnerException != null) w.WriteLine("  {0}", e.InnerException.Message);


                    /*   Log(commonResultList, w);*/
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
