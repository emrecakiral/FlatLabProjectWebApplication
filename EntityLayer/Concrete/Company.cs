using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [StringLength(100)]
        public string CompanyTitle { get; set; }

        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }



        public ICollection<Manager> Managers { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
    }
}
