using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public int BookId { get; set; }
    }
}
