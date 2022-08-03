using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Manager : IHuman
    {
        [Key]
        public int ManagerID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(16)]
        public string Password { get; set; }
        public string MailAddress { get; set; }
        public string Role { get; set; }


        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
    }
}
