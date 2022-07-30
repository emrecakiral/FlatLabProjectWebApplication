using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
