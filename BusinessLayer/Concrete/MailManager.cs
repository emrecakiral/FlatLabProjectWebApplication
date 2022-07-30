using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public Mail GetByID(int id)
        {
            return _mailDal.Get(x => x.ID == id);
        }

        public List<Mail> GetList()
        {
            return _mailDal.List();
        }

        public List<Mail> GetListInbox(string receiverMail)
        {
            return _mailDal.List(x => x.ReceiverMail == receiverMail);
        }

        public List<Mail> GetSendInbox(string senderMail)
        {
            return _mailDal.List(x => x.SenderMail == senderMail);
        }

        public void MailAdd(Mail mail)
        {
            _mailDal.Insert(mail);
        }

        public void MailDelete(Mail mail)
        {
            _mailDal.Delete(mail);
        }
    }
}
