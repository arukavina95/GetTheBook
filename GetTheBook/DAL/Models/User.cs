using System;
using System.Collections.Generic;

#nullable disable

namespace GetTheBook.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
