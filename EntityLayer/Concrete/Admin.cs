using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : IHuman
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(16)]
        public string Password { get; set; }
        public string MailAddress { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Image { get; set; }
    }
}
