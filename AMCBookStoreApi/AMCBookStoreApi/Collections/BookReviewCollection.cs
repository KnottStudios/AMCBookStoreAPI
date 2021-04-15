using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMCBookStoreApi.Collections
{
    public static class BookReviewCollection
    {
        public static List<BookReview> BookReviews { get; set; }
        static BookReviewCollection()
        {
            BookReviews = new List<BookReview>()
            {
                new BookReview(){
                    Id = 1,
                    ReviewText = "I didn't find the help I needed.",
                    BookId = 1,
                    Rating = 3.5M,
                    ReviewerName = "The Meta Critic",
                    PublishDate = DateTime.Now
                },
                new BookReview(){
                    Id = 2,
                    ReviewText = "I am now CEO.",
                    BookId = 2,
                    Rating = 5M,
                    ReviewerName = "The Curd Nurd",
                    PublishDate = DateTime.Now.AddYears(-1)
                },
                new BookReview(){
                    Id = 3,
                    ReviewText = "Still a Grunt",
                    BookId = 2,
                    Rating = 1.5M,
                    ReviewerName = "Hardly Working",
                    PublishDate = DateTime.Now.AddYears(-2)
                },
                new BookReview(){
                    Id = 4,
                    ReviewText = "Funny",
                    BookId = 4,
                    Rating = 2.0M,
                    ReviewerName = "Funny Bone",
                    PublishDate = DateTime.Now.AddYears(-3)
                },
                new BookReview(){
                    Id = 5,
                    ReviewText = "Even Funnier.",
                    BookId = 3,
                    Rating = 5.0M,
                    ReviewerName = "Funny Bone",
                    PublishDate = DateTime.Now.AddYears(-4)
                },
                new BookReview(){
                    Id = 6,
                    ReviewText = "It made my eyes pop.",
                    BookId = 5,
                    Rating = 4.5M,
                    ReviewerName = "Whaddya Mean",
                    PublishDate = DateTime.Now.AddYears(-5)
                }

            };
        }
        public static List<BookReviewVM> GetBookReviewVMs(string baseUrl, QuerySearch query = null)
        {
            var returnBookReviews = QueryHelper.QueryList<BookReview>(query, "bookReview");
            var bookReviewVMs = new List<BookReviewVM>();
            foreach (var br in returnBookReviews)
            {
                var vm = new BookReviewVM()
                {
                    Id = br.Id,
                    ReviewerName = br.ReviewerName,
                    ReviewText = br.ReviewText,
                    PublishDate = br.PublishDate,
                    BookId = br.BookId,
                    Rating = br.Rating,
                };
                vm.SetDefaultLinks(baseUrl, "bookreview", br.ReviewerName);
                vm.Embed = new Embed(books: BookCollection.GetBookEmbed(baseUrl, new List<int>() { br.BookId }));
                bookReviewVMs.Add(vm);
            }
            return bookReviewVMs;
        }
        public static List<BookReviewVM> GetBookReviewEmbed(string baseUrl, List<int> bookReviewIds)
        {
            var returnBookReviews = BookReviews.Where(x => bookReviewIds.Contains(x.Id)); //.Where(x => x.FirstName == query.Author.FirstName);
            var bookReviewVMs = new List<BookReviewVM>();
            foreach (var br in returnBookReviews)
            {
                var vm = new BookReviewVM()
                {
                    Id = br.Id,
                    ReviewerName = br.ReviewerName,
                    PublishDate = br.PublishDate,
                    Rating = br.Rating,
                };
                vm.SetDefaultLinks(baseUrl, "bookreview", br.ReviewerName);
                bookReviewVMs.Add(vm);
            }
            return bookReviewVMs;
        }
    }
}
