using AMCBookStoreApi.Models;
using System.Collections.Generic;

namespace AMCBookStoreApi.ModelQueries
{
    public class BookQuery
    {
        public int MaxReturn { get; set; }
        public List<Author> Authors { get; set; }
    }
}
