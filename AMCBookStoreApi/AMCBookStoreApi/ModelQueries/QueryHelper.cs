using AMCBookStoreApi.Collections;
using AMCBookStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.ModelQueries
{
    public static class QueryHelper
    {
        public static List<T> QueryList<T>(QuerySearch query, string className)
        {
            if (query == null)
            {
                query = new QuerySearch();
            }
            IEnumerable<Book> books = new List<Book>();
            IEnumerable<Author> authors = new List<Author>();
            IEnumerable<Category> categories = new List<Category>();
            IEnumerable<BookReview> bookReviews = new List<BookReview>();
            if (!string.IsNullOrWhiteSpace(query.BookName))
            {
                books = BookCollection.Books.Where(x => x.Title == query.BookName);
            }
            if (!string.IsNullOrWhiteSpace(query.AuthorFirst) && !string.IsNullOrWhiteSpace(query.AuthorLast))
            {
                authors = AuthorCollection.Authors.Where(x => x.FirstName == query.AuthorFirst && x.LastName == query.AuthorLast);
            }
            else if (!string.IsNullOrWhiteSpace(query.AuthorFirst))
            {
                authors = AuthorCollection.Authors.Where(x => x.FirstName == query.AuthorFirst);
            }
            else if (!string.IsNullOrWhiteSpace(query.AuthorLast))
            {
                authors = AuthorCollection.Authors.Where(x => x.LastName == query.AuthorLast);
            }
            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                categories = CategoryCollection.Categories.Where(x => x.Name == query.CategoryName);
            }
            if (!string.IsNullOrWhiteSpace(query.ReviewerName))
            {
                bookReviews = BookReviewCollection.BookReviews.Where(x => x.ReviewerName == query.ReviewerName);
            }

            if (className == "author")
            {
                if (!authors.Any()) {
                    authors = AuthorCollection.Authors;
                }
                if (books.Any())
                {
                    var bookIds = books.Select(x => x.Id);
                    authors = authors.Where(x => bookIds.Any(y => x.BookIds.Contains(y)));
                }
                if (categories.Any())
                {
                    var catIds = categories.Select(x => x.Id);
                    authors = authors.Where(x => catIds.Any(y => x.CategoryIds.Contains(y)));
                }

                return authors?.Take(query.MaxReturn).ToList() as List<T>;
            }

            if (className == "bookReview")
            {
                if (!bookReviews.Any()) {
                    bookReviews = BookReviewCollection.BookReviews;
                }

                if (books.Any())
                {
                    var bookIds = books.Select(x => x.Id);
                    bookReviews = bookReviews.Where(x => bookIds.Contains(x.BookId));
                }
                return bookReviews?.Take(query.MaxReturn).ToList() as List<T>;
            }

            if (className == "category")
            {
                if (!categories.Any())
                {
                    categories = CategoryCollection.Categories;
                }

                if (books.Any())
                {
                    var bookIds = books.Select(x => x.Id);
                    categories = categories.Where(x => bookIds.Any(y => x.BookIds.Contains(y)));
                }
                if (authors.Any())
                {
                    var autIds = authors.Select(x => x.Id);
                    categories = categories.Where(x => autIds.Any(y => x.AuthorIds.Contains(y)));
                }
                return categories?.Take(query.MaxReturn).ToList() as List<T>;
            }

            if (!books.Any())
            {
                books = BookCollection.Books;
            }
            if (authors.Any())
            {
                var autIds = authors.Select(x => x.Id);
                books = books.Where(x => autIds.Any(y => x.AuthorIds.Contains(y)));
            }
            if (categories.Any())
            {
                var catIds = categories.Select(x => x.Id);
                books = books.Where(x => catIds.Any(y => x.CategoryIds.Contains(y)));
            }
            if (bookReviews.Any())
            {
                var brIds = bookReviews.Select(x => x.Id);
                books = books.Where(x => brIds.Any(y => x.BookReviewIds.Contains(y)));
            }
            return books?.Take(query.MaxReturn).ToList() as List<T>;
        }
    }
}
