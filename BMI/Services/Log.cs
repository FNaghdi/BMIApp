using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Interfaces;

namespace BMIApp.Services
{
    internal class Log : ILog
    {


        public void LogInfo(string message)
        {

            var address = "D:\\MyLogs\\log"+DateTime.Now.ToString("yyyy_MM_dd_h")+".txt";
            File.AppendAllText(address, "\n////////////////////////////////////////////////");
            File.AppendAllText(address,"\n"+ DateTime.Now.ToLongDateString());
            File.AppendAllText(address,"\n"+ message);
            File.AppendAllText(address,"\n"+ "------------------------------------------------");
        }
    }
}
