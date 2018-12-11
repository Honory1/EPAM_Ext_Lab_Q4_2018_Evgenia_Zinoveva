namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Log
    {
        public static void SaveToLog(Exception ex)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(pathToLog))
            {
                Directory.CreateDirectory(pathToLog);
            }

            var writer = new StreamWriter("log/Log1.log", true);
            writer.WriteLine("{0}: {1}\n {2}", DateTime.Now, ex.Message, ex.StackTrace);
            writer.Close();
        }
    }
}
