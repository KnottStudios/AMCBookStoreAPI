using System.Collections.Generic;

namespace AMCBookStoreApi.ViewModels
{
    public class CategoryVM : ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dink> Authors { get; set; } = new List<Dink>();
        public List<Dink> Books { get; set; } = new List<Dink>();
    }
}
