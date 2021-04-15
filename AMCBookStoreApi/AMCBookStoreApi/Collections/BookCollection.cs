using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMCBookStoreApi.Collections
{
    public static class BookCollection
    {
        public static List<Book> Books { get; set; } = new List<Book>();

        static BookCollection()
        {
            Books = new List<Book>() {
                new Book() {
                    Id = 1,
                    Description = "1 hrs and 53 minutes",
                    Title = "The Energy Bus",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(2007, 12, 30),
                    AuthorIds = new List<int>() { 2 },
                    BookReviewIds = new List<int>() { 1 },
                    CategoryIds = new List<int>() { 1, 2 },
                },
                new Book(){
                    Id = 2,
                    Description = "four hours and 3 minutes",
                    Title = "The Power of Positive Leadership",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(2017, 5, 8),
                    AuthorIds = new List<int>() { 2 },
                    BookReviewIds = new List<int>() { 2, 3 },
                    CategoryIds = new List<int>() { 1, 2 },
                },
                new Book(){
                    Id = 3,
                    Description = "8 hours and 48 minutes.",
                    Title = "How To Fail At Almost Everything and Still Win Big",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(2019, 11, 19),
                    AuthorIds = new List<int>() { 1 },
                    BookReviewIds = new List<int>() { 5 },
                    CategoryIds = new List<int>() { 2, 4 },
                },
                new Book(){
                    Id = 4,
                    Description = "A Dilbert moment.",
                    Title = "Stick to Drawing Comics, Monkey Brain!",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(2007, 10, 24),
                    AuthorIds = new List<int>() { 1 },
                    BookReviewIds = new List<int>() { 4 },
                    CategoryIds = new List<int>() { 2, 4 },
                },
                new Book(){
                    Id = 5,
                    Description = "Sic",
                    Title = "The Eye of the World",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(1990, 01, 15),
                    AuthorIds = new List<int>() { 3 },
                    CategoryIds = new List<int>() { 3 },
                    BookReviewIds = new List<int>() { 6 },
                },
                new Book(){
                    Id = 6,
                    Description = "True",
                    Title = "Always Postpone Meetings with Time-Wasting Morons",
                    CoverImageUrl = "https://via.placeholder.com/150",
                    PublishDate = new DateTime(1992, 10, 01),
                    AuthorIds = new List<int>() { 1 },
                    CategoryIds = new List<int>() { 4 },
                    BookReviewIds = new List<int>() { },
                }
            };
        }
        public static List<BookVM> GetBookVMs(string baseUrl, QuerySearch query = null)
        {
            var returnBooks = QueryHelper.QueryList<Book>(query, "book");
            var bookVMs = new List<BookVM>();
            foreach (var book in returnBooks)
            {
                var vm = new BookVM(book.Id, baseUrl)
                {
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublishDate = book.PublishDate,
                };
                vm.SetDefaultLinks(baseUrl, "book", book.Title);
                vm.Embed = new Embed(BookReviewCollection.GetBookReviewEmbed(baseUrl, book.BookReviewIds), AuthorCollection.GetAuthorEmbed(baseUrl, book.AuthorIds), CategoryCollection.GetCategoryEmbed(baseUrl, book.CategoryIds));

                bookVMs.Add(vm);
            }
            return bookVMs;
        }
        public static List<BookVM> GetBookEmbed(string baseUrl, List<int> bookIds)
        {
            var returnBooks = Books.Where(x => bookIds.Contains(x.Id));
            var bookVMs = new List<BookVM>();
            foreach (var book in returnBooks)
            {
                var vm = new BookVM(book.Id, baseUrl)
                {
                    Title = book.Title,
                    PublishDate = book.PublishDate
                };
                vm.SetDefaultLinks(baseUrl, "book", book.Title);
                bookVMs.Add(vm);
            }
            return bookVMs;
        }
    }
}
