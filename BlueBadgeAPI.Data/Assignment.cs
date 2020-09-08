using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
<<<<<<< HEAD
        public virtual Team Team { get; set; }
=======
        public virtual User Team { get; set; }


>>>>>>> Alex
    }
}
