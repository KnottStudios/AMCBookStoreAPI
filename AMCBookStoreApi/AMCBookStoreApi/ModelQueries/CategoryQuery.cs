using AMCBookStoreApi.Models;

namespace AMCBookStoreApi.ModelQueries
{
    public class CategoryQuery
    {
        public int MaxReturn { get; set; }
        public Category Category { get; set; }
    }
}
