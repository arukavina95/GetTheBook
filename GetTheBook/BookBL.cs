using GetTheBook.DAL;
using GetTheBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTheBook
{
    public class BookBL
    {
        private int _id;
        private string _title;
        private string _authors;
        private decimal? _averageRating;
        private string _isbn;
        private string _isbn13;
        private string _languageCode;
        private int? _numPages;
        private int? _ratingsCount;
        private int? _textReviewsCount;
        private DateTime? _publicationDate;
        private string _publisher;
        private int? _userId;
        private byte _borrowed;

        private User _user;

        public BookBL()
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

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Authors
        {
            get
            {
                return _authors;
            }
            set
            {
                _authors = value;
            }
        }

        public decimal AverageRating
        {
            get
            {
                return _averageRating.Value;
            }
            set
            {
                _averageRating = value;
            }
        }

        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                if (value.Length != 10)
                {
                    _isbn = null;
                }
                else
                {
                    _isbn = value;
                }
            }
        }

        public string Isbn13
        {
            get
            {
                return _isbn13;
            }
            set
            {
                _isbn13 = value;
            }
        }
        public string LanguageCode
        {
            get
            {
                return _languageCode;
            }
            set
            {
                _languageCode = value;
            }
        }
        public string NumPages
        {
            get
            {
                return _numPages.ToString();
            }
            set
            {
                _numPages = value.Length;
            }
        }
        public string RatingsCount
        {
            get
            {
                return _ratingsCount.ToString();
            }
            set
            {
                _ratingsCount = value.Length;
            }
        }
        public string TextReviewsCount
        {
            get
            {
                return _textReviewsCount.ToString();
            }
            set
            {
                _textReviewsCount = value.Length;
            }
        }
        public DateTime PublicationDate
        {
            get
            {
                return _publicationDate.Value;
            }
            set
            {
                _publicationDate = value;
            }
        }
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                _publisher = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId.Value;
            }
            set
            {
                _userId = value;
            }
        }

        public byte Borrowed
        {
            get
            {
                return _borrowed;
            }
            set
            {
                _borrowed = value;
            }
        }
        public User User

        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
