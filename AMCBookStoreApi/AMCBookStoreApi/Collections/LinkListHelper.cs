using AMCBookStoreApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace AMCBookStoreApi.Collections
{
    public static class LinkListHelper
    {
        public static List<Dink> GetBookReviewLinks(string baseUrl, List<int> bookReviewIds)
        {
            var linkList = new List<Dink>();
            foreach (var brId in bookReviewIds)
            {
                var thisBkRv = BookReviewCollection.BookReviews.FirstOrDefault(x => x.Id == brId);
                linkList.Add(new Dink()
                {
                    Id = brId,
                    Label = $"Review By: {thisBkRv.ReviewerName}",
                    Href = $"{baseUrl}/api/Category/{brId}"
                });
            }

            return linkList;
        }
        public static List<Dink> GetBookLinks(string baseUrl, List<int> bookIds)
        {
            var linkList = new List<Dink>();
            foreach (var bookId in bookIds)
            {
                var thisBook = BookCollection.Books.FirstOrDefault(x => x.Id == bookId);
                linkList.Add(new Dink()
                {
                    Id = bookId,
                    Label = $"{thisBook.Title}",
                    Href = $"{baseUrl}/api/Book/{bookId}"
                });
            }
            return linkList;
        }

        public static List<Dink> GetCategoryLinks(string baseUrl, List<int> categoryIds)
        {
            var linkList = new List<Dink>();
            foreach (var catId in categoryIds)
            {
                var thisCat = CategoryCollection.Categories.FirstOrDefault(x => x.Id == catId);
                linkList.Add(new Dink()
                {
                    Id = catId,
                    Label = $"{thisCat.Name}",
                    Href = $"{baseUrl}/api/Category/{catId}"
                });
            }
            return linkList;
        }

        public static List<Dink> GetAuthorLinks(string baseUrl, List<int> authorIds)
        {
            var linkList = new List<Dink>();
            foreach (var authId in authorIds)
            {
                var thisAuth = AuthorCollection.Authors.FirstOrDefault(x => x.Id == authId);
                linkList.Add(new Dink()
                {
                    Id = authId,
                    Label = $"{thisAuth.FirstName} {thisAuth.LastName}",
                    Href = $"{baseUrl}/api/Author/{authId}"
                });
            }
            return linkList;
        }
    }
}
