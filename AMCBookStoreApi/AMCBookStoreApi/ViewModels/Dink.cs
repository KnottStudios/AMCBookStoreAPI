using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.ViewModels
{
    public class Dink
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Href { get; set; }
        public string Method { get; set; } = "GET";
    }
}
