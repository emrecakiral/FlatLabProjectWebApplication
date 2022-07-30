using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Personnel : IHuman
    {
        [Key]
        public int PersonnelID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(16)]
        public string Password { get; set; }
        public string MailAddress { get; set; }
        public string Role { get; set; }

        public virtual Manager Manager { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public virtual Company Company { get; set; }
    }
}
