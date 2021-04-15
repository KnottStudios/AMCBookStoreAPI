using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                    AuthorIds = { 1,2 }
                },
                new Category(){ 
                    Id = 3,
                    Name = "Fantasy",
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
        public static List<CategoryVM> GetCategoryVMs(string baseUrl, QuerySearch query = null)
        {
            var returnCats = QueryHelper.QueryList<Category>(query, "category");
            var categoryVMs = new List<CategoryVM>();
            foreach (var cat in returnCats)
            {
                var vm = new CategoryVM()
                {
                    Name = cat.Name,
                    Id = cat.Id,
                };
                vm.SetDefaultLinks(baseUrl, "category", cat.Name);
                vm.Embed = new Embed(authors: AuthorCollection.GetAuthorEmbed(baseUrl, cat.AuthorIds), books: BookCollection.GetBookEmbed(baseUrl, cat.BookIds));
                categoryVMs.Add(vm);
            }
            return categoryVMs;
        }
        public static List<CategoryVM> GetCategoryEmbed(string baseUrl, List<int> categoryIds)
        {
            var returnCats = Categories.Where(x => categoryIds.Contains(x.Id));
            var categoryVMs = new List<CategoryVM>();
            foreach (var cat in returnCats)
            {
                var vm = new CategoryVM()
                {
                    Id = cat.Id,
                    Name = cat.Name,
                };
                vm.SetDefaultLinks(baseUrl, "category", cat.Name);
                categoryVMs.Add(vm);
            }
            return categoryVMs;
        }
    }
}
