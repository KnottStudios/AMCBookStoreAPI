using AMCBookStoreApi.Models;

namespace AMCBookStoreApi.ModelQueries
{
    public class AuthorQuery 
    {
        public int MaxReturn { get; set; }
        public Author Author { get; set; }
    }
}
