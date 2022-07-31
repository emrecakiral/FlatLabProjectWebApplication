using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FlatLabProjectWebApplication.Roles
{
    public class LoginRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string mail)
        {
            Context c = new Context();
            Personnel perinfo = c.Personnels.FirstOrDefault(x => x.MailAddress == mail);
            Manager maninfo = c.Managers.FirstOrDefault(x => x.MailAddress == mail);
            Admin admininfo = c.Admins.FirstOrDefault(x => x.MailAddress == mail);

            if (perinfo != null)
            {
                return new string[] { perinfo.Role };
            }
            else if (maninfo != null)
            {
                return new string[] { maninfo.Role };
            }

                return new string[] { admininfo.Role };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}