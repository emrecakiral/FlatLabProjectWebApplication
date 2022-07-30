using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mail
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string ReceiverMail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(2000)]
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Importance { get; set; }
        public string Document { get; set; }
    }
}
