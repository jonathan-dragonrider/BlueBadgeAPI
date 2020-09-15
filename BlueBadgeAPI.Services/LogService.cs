using BlueBadgeAPI.Data;
using BlueBadgeAPI.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class LogService
    {
        public LogService()
        {
        }

        public bool LogCreate(string model)
        {
            var newLog = new Log()
            {
                WhatHappened = model
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Logs.Add(newLog);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Log> GetLogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collection = new List<Log>();
                foreach (var item in ctx.Logs)
                {
                    var newLogListItems = new Log
                    {
                        WhatHappened = item.WhatHappened
                    };
                    collection.Add(newLogListItems);
                }
                return collection;
            }
        }
    }
}
