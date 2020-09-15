using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlueBadgeAPI.Web.Controllers
{
    public class LogListItems
    {
        [Key]
        public int LogId { get; set; }
        public string WhatHappened { get; set; }

    }
}