using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMCBookStoreApi.ViewModels
{
    public class ViewModel
    {
        public int Id { get; set; }
        public List<Dink> Dinks { get; set; } = new List<Dink>();

        public void SetDefaultLinks(string baseUrl, string className)
        {
            AddLink(new Dink
            {
                Id = 1,
                Label = $"self",
                Href = $"{baseUrl}/api/{className}/{Id}"
            });
            AddLink(new Dink
            {
                Id = 2,
                Label = $"Get List",
                Href = $"{baseUrl}/api/{className}"
            });
        }

        public void AddLink(Dink link)
        {
            var exists = Dinks.FirstOrDefault(x => x.Id == link.Id);
            if (exists != null)
            {
                Dinks.Remove(exists);
            }

            Dinks.Add(link);
        }
    }
}
