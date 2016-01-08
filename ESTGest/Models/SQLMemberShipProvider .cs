using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ESTGest.Models
{
    public class SQLMemberShipProvider
    {
        private ESTGestDbEntities2 _db;
        public SQLMemberShipProvider()
        {
            _db = new ESTGestDbEntities2();

        }


        public bool ValidateUser(string name, string password)
        {

            var model = from u in _db.Users where u.u_name == name && u.u_password == password select u;
            if (model != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User GetUser(string userName)
        {
            var user = _db.Users.SingleOrDefault(u => u.u_name == userName);
            return user;
        }

        public User GetUser(string userName, string password)
        {
            var user = _db.Users.SingleOrDefault(u => u.u_name ==
                           userName && u.u_password == password);
            return user;
        }

        public void AddUserRole(UserRole userRole)
        {
            var roleEntry = _db.UserRoles.SingleOrDefault(r => r.UserId == userRole.UserId);
            if (roleEntry != null)
            {
                _db.UserRoles.Remove(roleEntry);
                _db.SaveChanges();
            }
            _db.UserRoles.Add(userRole);
            _db.SaveChanges();
        }
    }
}