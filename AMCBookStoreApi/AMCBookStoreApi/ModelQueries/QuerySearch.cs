using AMCBookStoreApi.Models;
using System.Collections.Generic;

namespace AMCBookStoreApi.ModelQueries
{
    public class QuerySearch
    {
        public int MaxReturn { get; set; } = 4;
        public string AuthorFirst { get; set; }
        public string AuthorLast { get; set; }
        public string CategoryName { get; set; }
        public string BookName { get; set; }
        public string ReviewerName { get; set; }
    }
}
