using System;
using System.Collections.Generic;

#nullable disable

namespace GetTheBook.DAL.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public decimal? AverageRating { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string LanguageCode { get; set; }
        public int? NumPages { get; set; }
        public int? RatingsCount { get; set; }
        public int? TextReviewsCount { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Publisher { get; set; }
        public int? UserId { get; set; }
        public byte Borrowed { get; set; }

        public virtual User User { get; set; }
    }
}
