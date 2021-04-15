using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeadshotImageUrl { get; set; }
        public List<int> BookIds { get; set; } = new List<int>();
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
