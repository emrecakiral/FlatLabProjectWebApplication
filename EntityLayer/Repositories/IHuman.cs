using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public interface IHuman
    {
        string Name { get; set; }
        string SurName { get; set; }
        string Image { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string MailAddress { get; set; }
    }
}
