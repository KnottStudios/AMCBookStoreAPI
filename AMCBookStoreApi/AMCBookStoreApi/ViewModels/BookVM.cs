using AMCBookStoreApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AMCBookStoreApi.ViewModels
{
    public class BookVM : ViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string CoverImageUrl { get; set; }

        public BookVM()
        {
        }
        public BookVM(int id, string baseUrl)
        {
            Id = id;
            SetDefaultLinks($"{baseUrl}", nameof(Book));
            AddLink(new Dink
            {
                Id = 3,
                Label = $"Add To Cart",
                Href = $"{baseUrl}/api/MyCart/{Id}",
                Method = "Post"
            });
        }
        public List<Dink> BookReviews { get; set; } = new List<Dink>();
        public List<Dink> Categories { get; set; } = new List<Dink>();
        public List<Dink> Authors { get; set; } = new List<Dink>();
    }
}
