using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models
{
    public class AssignmentDetails
    {
        public int AssignmentId { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
    }
}
