using GetTheBook.DAL;
using GetTheBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTheBook
{
    public class BookService
    {
        private BookRepository _bookRepository;


        public string Msg { get; set; }

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public List<BookBL> GetAllBooks(int numberOfBooks = 0)
        {
            List<BookBL> bookList = new List<BookBL>();

            foreach (var book in _bookRepository.GetAll(numberOfBooks))
            {
                BookBL bookBl = DalToBL(book);
                bookList.Add(bookBl);
            }

            return bookList;
        }

        public List<BookBL> GetAllBorrowedBooks()
        {
            List<BookBL> bookList = new List<BookBL>();

            foreach (var book in _bookRepository.GetAll(0).Where(x => x.Borrowed == 1))
            {
                BookBL bookBl = DalToBL(book);
                bookList.Add(bookBl);
            }

            return bookList;
        }

        public List<BookBL> GetAllReturnedBooks()
        {
            List<BookBL> bookList = new List<BookBL>();

            foreach (var book in _bookRepository.GetAll(0).Where(x => x.Borrowed == 0))
            {
                BookBL bookBl = DalToBL(book);
                bookList.Add(bookBl);
            }

            return bookList;
        }


        public BookBL GetBookByISBN(string isbn)
        {
            using (var _context = new BookDBContext())
            {
                var books = _context.Books;
                Book book = books.SingleOrDefault(x => x.Isbn == isbn);

                return DalToBL(book);
            }
        }

        public BookBL BorrowSelectedBook(string isbn)
        {
            using (var _context = new BookDBContext())
            {
                var books = _context.Books;
                Book book = books.SingleOrDefault(x => x.Isbn == isbn);

                if (book == null)
                {
                    Msg = "Book not found, incorrect ISBN code";
                    return null;
                }

                if (book.Borrowed == 1)
                {
                    Msg = "Book already borrowed, please pick another book.";
                    return null;
                }

                book.Borrowed = 1;

                _context.SaveChanges();

                BookBL bookBL = DalToBL(book);
                return bookBL;
            }
        }

        public BookBL ReturnSelectedBook(string isbn)
        {
            using (var _context = new BookDBContext())
            {
                var books = _context.Books;
                Book book = books.SingleOrDefault(x => x.Isbn == isbn);

                if (book == null)
                {
                    Msg = "Book not found, incorrect ISBN code";
                    return null;
                }

                if (book.Borrowed == 0)
                {
                    Msg = "Book already returned.";
                    return null;
                }

                book.Borrowed = 0;
                _context.SaveChanges();

                BookBL bookBL = DalToBL(book);
                return bookBL;
            }
        }

        private BookBL DalToBL(Book book)
        {
            BookBL bookBl = new BookBL();

            bookBl.Id = book.Id;
            bookBl.Title = book.Title;
            bookBl.Isbn = book.Isbn;
            bookBl.Authors = book.Authors;
            bookBl.AverageRating = (decimal)book.AverageRating;
            bookBl.Isbn = book.Isbn;
            bookBl.Isbn13 = book.Isbn13;
            bookBl.LanguageCode = book.LanguageCode;
            bookBl.NumPages = book.NumPages.ToString();
            bookBl.RatingsCount = book.RatingsCount.ToString();
            bookBl.TextReviewsCount = book.TextReviewsCount.ToString();
            bookBl.PublicationDate = book.PublicationDate.Value;
            bookBl.Publisher = book.Publisher;
            bookBl.Borrowed = book.Borrowed;
            return bookBl;
        }
    }
}
