using AMCBookStoreApi.Models;

namespace AMCBookStoreApi.ModelQueries
{
    public class BookReviewQuery
    {
        public int MaxReturn { get; set; }
        public BookReview BookReview { get; set; }
    }
}
