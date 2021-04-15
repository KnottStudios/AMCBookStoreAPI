using AMCBookStoreApi.Models;
using System.Collections.Generic;

namespace AMCBookStoreApi.ViewModels
{
    public class AuthorVM : ViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeadshotImageUrl { get; set; }
        public List<Dink> Books { get; set; } = new List<Dink>();
        public List<Dink> Categories { get; set; } = new List<Dink>();
    }
}
