﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public string Priority { get; set; }


        [StringLength(50)]
        public string Title { get; set; }


        [StringLength(1000)]
        public string Contents { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime CreationDate { get; set; }


        [StringLength(100)]
        public string Document { get; set; }
        public bool Status { get; set; }


        public int? ManagerID { get; set; }
        public virtual Manager Manager { get; set; }

        public List<int> PersonnelsIDs { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
    }
}
