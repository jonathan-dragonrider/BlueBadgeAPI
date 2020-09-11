using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        //add min, max length in models
        public string Title { get; set; }

        //add min, max length in models
        public string Description { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ProjectCreator { get; set; }





    }
}
