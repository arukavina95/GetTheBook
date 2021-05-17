using System;
using System.Collections.Generic;
using System.Text;

namespace GetTheBook
{
    public class UserBL
    {
        private int _id;
        private string _username;


        public UserBL()
        {
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

      
    }
}
