using AMCBookStoreApi.Models;
using System;

namespace AMCBookStoreApi.ViewModels
{
    public class BookReviewVM : ViewModel
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public int BookId { get; set; }
        public Dink Book { get; set; }
    }
}
