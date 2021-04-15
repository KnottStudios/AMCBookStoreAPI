using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace AMCBookStoreApi.Collections
{
    public static class AuthorCollection
    {
        public static List<Author> Authors { get; set; } = new List<Author>();
        static AuthorCollection()
        {
            Authors = new List<Author>()
            {
                new Author(){
                    Id = 1,
                    FirstName = "Scott",
                    LastName = "Adams",
                    HeadshotImageUrl = "https://www.gstatic.com/webp/gallery3/squares.png",
                    BookIds = new List<int>(){ 3,4 },
                    CategoryIds = new List<int>() { 2,4 }
                },
                new Author(){
                    Id = 2,
                    FirstName = "Jon",
                    LastName = "Gordon",
                    HeadshotImageUrl = "https://www.gstatic.com/webp/gallery/4.sm.jpg",
                    BookIds = new List<int>(){ 1,2 },
                    CategoryIds = new List<int>() { 1,2 }
                },
                new Author(){
                    Id = 3,
                    FirstName = "Robert",
                    LastName = "Jordan",
                    BookIds = new List<int>(){ 5 },
                    CategoryIds = new List<int>() { 3 }
                }
            };
        }
        public static List<AuthorVM> GetAuthorVMs(string baseUrl, QuerySearch query = null) 
        {
            var returnAuthors = QueryHelper.QueryList<Author>(query, "author");
            var authorVMs = new List<AuthorVM>();
            foreach (var aut in returnAuthors)
            {
                var vm = new AuthorVM()
                {
                    FirstName = aut.FirstName,
                    LastName = aut.LastName,
                    Id = aut.Id,
                    HeadshotImageUrl = aut.HeadshotImageUrl
                };
                vm.SetDefaultLinks(baseUrl, "author", $"{aut.FirstName} {aut.LastName}");
                vm.Embed = new Embed(books : BookCollection.GetBookEmbed(baseUrl, aut.BookIds), categories : CategoryCollection.GetCategoryEmbed(baseUrl, aut.CategoryIds));
                authorVMs.Add(vm);
            }
            return authorVMs;
        }
        public static List<AuthorVM> GetAuthorEmbed(string baseUrl, List<int> authorIds)
        {
            var returnAuthors = Authors.Where(x => authorIds.Contains(x.Id));
            var authorVMs = new List<AuthorVM>();
            foreach (var aut in returnAuthors)
            {
                var vm = new AuthorVM()
                {
                    Id = aut.Id,
                    FirstName = aut.FirstName,
                    LastName = aut.LastName,
                };
                vm.SetDefaultLinks(baseUrl, "author", $"{aut.FirstName} {aut.LastName}");
                authorVMs.Add(vm);
            }
            return authorVMs;
        }
    }
}
