using System;

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
            AddLink(new BSLink
            {
                Rel = "Cart",
                Title = $"Add To Cart",
                Href = $"{baseUrl}/api/MyCart/{Id}",
                Method = "Post"
            });
        }
    }
}
