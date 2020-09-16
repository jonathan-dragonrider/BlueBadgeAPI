using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models
{
    public class AssignmentCreate
    {
        public string UserName { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }
    }
}
