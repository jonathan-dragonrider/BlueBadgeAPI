using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBadgeAPI.Web.Controllers
{
    public class Log
    { 
        public string GetLogData(string oldLog)
        {
            List<string> stringList = new List<string>();
            stringList.Add(oldLog);
            string newLog = "";
            int count = 0;
            foreach (string item in stringList)
            {
                newLog += item[count] + "\n";
                count++;
            }
            return newLog;
        }
    }
}