using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Hal;

namespace AMCBookStoreApi.ViewModels
{
    public class ViewModel
    {
        public int Id { get; set; }

        [JsonProperty("_links")]
        public List<BSLink> Links { get; set; } = new List<BSLink>();

        [JsonProperty("_embedded")]
        public Embed Embed { get; set; } = null;

        public void SetDefaultLinks(string baseUrl, string className, string title = null)
        {
            AddLink(new BSLink
            {
                Rel = $"self",
                Title = title,
                Href = $"{baseUrl}/api/{className}/{Id}"
            });
            /*
            AddLink(new BSLink
            {
                Id = 2,
                Rel = $"list",
                Href = $"{baseUrl}/api/{className}"
            }); ;
            */
        }

        public void AddLink(BSLink link)
        {
            Links.Add(link);
        }
    }
    public class Embed
    {
        public Embed(List<BookReviewVM> bookReviews = null, List<AuthorVM> authors = null, List<CategoryVM> categories = null, List<BookVM> books = null)
        {
            BookReviews = bookReviews;
            Authors = authors;
            Categories = categories;
            Books = books;
        }
        public List<BookReviewVM> BookReviews { get; set; } = null;
        public List<AuthorVM> Authors { get; set; } = null;
        public List<CategoryVM> Categories { get; set; } = null;
        public List<BookVM> Books { get; set; } = null;
    }
}
