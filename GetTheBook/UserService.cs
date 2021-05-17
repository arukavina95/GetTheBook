using GetTheBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTheBook
{
    public class UserService
    {
        public string Msg { get; set; }

        private UserBL DalToBL(User user)
        {
            UserBL userBl = new UserBL();

            userBl.Id = user.Id;
            userBl.Username = user.Username;

            return userBl;
        }
        public UserBL GetUserByUsername(string username)
        {
            using (var _context = new BookDBContext())
            {
                var users = _context.Users;
                User user = users.SingleOrDefault(x => x.Username == username);

                if (user == null)
                {
                    Msg = "User does not exist";
                    return null;
                }

                return DalToBL(user);
            }
        }

    }
}
