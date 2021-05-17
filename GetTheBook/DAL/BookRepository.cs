using GetTheBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTheBook.DAL
{
    public class BookRepository
    {
        public List<Book> GetAll(int numberOfBooks)
        {
            using (var _context = new BookDBContext())
            {
                if (numberOfBooks == 0)
                {
                    return _context.Books.ToList();
                }
                return _context.Books.Take(numberOfBooks).ToList();
            }

        }

    }
}
