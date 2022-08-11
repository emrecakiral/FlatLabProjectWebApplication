using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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
        Context c = new Context();

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public List<Mail> FindByCriter(Func<Mail, bool> item, List<Mail> mails)
        {
            return mails.Where(item).ToList();
        }

        public List<Mail> FindByCriter(Func<Mail, bool> item)
        {
            return c.Mails.Where(item).ToList();
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
            return _mailDal.List(x => x.ReceiverMail == receiverMail).OrderByDescending(x => x.Date).ToList();
        }

        public List<Mail> GetSendInbox(string senderMail)
        {
            return _mailDal.List(x => x.SenderMail == senderMail).OrderByDescending(x => x.Date).ToList();
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
