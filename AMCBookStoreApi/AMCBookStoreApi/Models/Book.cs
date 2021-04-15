using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AMCBookStoreApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string CoverImageUrl { get; set; }
        public List<int> AuthorIds { get; set; } = new List<int>();
        public List<int> CategoryIds { get; set; } = new List<int>();
        public List<int> BookReviewIds { get; set; } = new List<int>();
    }
}
