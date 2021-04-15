using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using System.Collections.Generic;

namespace AMCBookStoreApi.Collections
{
    public static class CategoryCollection
    {
        public static List<Category> Categories { get; set; }
        static CategoryCollection()
        {
            Categories = new List<Category>()
            {
                new Category() { 
                    Id = 1,
                    Name = "Self Improvement",
                    BookIds = { 1,2 },
                    AuthorIds = { 2 }
                },
                new Category(){ 
                    Id = 2,
                    Name = "Audio Book",
                    BookIds = { 1,2,3,4 },
                    AuthorIds = { 2 }
                },
                new Category(){ 
                    Id = 3,
                    Name = "Science Fiction",
                    BookIds = { 5 },
                    AuthorIds = { 3 }
                },
                new Category(){ 
                    Id = 4,
                    Name = "Comedy",
                    BookIds = { 3,4 },
                    AuthorIds = { 1 }
                }
            };
        }
        public static List<CategoryVM> GetCategoryVMs(string baseUrl, CategoryQuery query = null)
        {
            var returnCats = Categories;//.Where(x => x.FirstName == query.Author.FirstName);
            var categoryVMs = new List<CategoryVM>();
            foreach (var cat in returnCats)
            {
                var vm = new CategoryVM()
                {
                    Name = cat.Name,
                    Id = cat.Id,
                };
                vm.Books.AddRange(LinkListHelper.GetBookLinks(baseUrl, cat.BookIds));
                vm.Authors.AddRange(LinkListHelper.GetAuthorLinks(baseUrl, cat.AuthorIds));
                vm.SetDefaultLinks(baseUrl, "category");
                categoryVMs.Add(vm);
            }
            return categoryVMs;
        }
    }
}
