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
                    BookIds = new List<int>(){ 3,4 },
                    CategoryIds = new List<int>() { 2,4 }
                },
                new Author(){
                    Id = 2,
                    FirstName = "Jon",
                    LastName = "Gordon",
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
        public static List<AuthorVM> GetAuthorVMs(string baseUrl, AuthorQuery query = null) 
        {
            var returnAuthors = Authors; //.Where(x => x.FirstName == query.Author.FirstName);
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
                vm.Books.AddRange(LinkListHelper.GetBookLinks(baseUrl, aut.BookIds));
                vm.Categories.AddRange(LinkListHelper.GetCategoryLinks(baseUrl, aut.CategoryIds));
                vm.SetDefaultLinks(baseUrl, "author");
                authorVMs.Add(vm);
            }
            return authorVMs;
        }
    }
}
