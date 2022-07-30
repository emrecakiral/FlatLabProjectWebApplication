using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMailService
    {
        List<Mail> GetListInbox(string receiverMail);
        List<Mail> GetSendInbox(string senderMail);
        void MailAdd(Mail mail);
        Mail GetByID(int id);
        void MailDelete(Mail mail);
    }
}
