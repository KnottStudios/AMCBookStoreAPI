using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> AuthorIds { get; set; } = new List<int>();
        public List<int> BookIds { get; set; } = new List<int>();
    }
}
