using AMCBookStoreApi.Collections;
using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AMCBookStoreApi.Controllers
{
    /// <summary>
    /// The Controller for getting Categories.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly IHttpContextAccessor _accessor;

        public CategoryController(ILogger<CategoryController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accessor = httpContextAccessor;
        }
        /// <summary>
        /// GET: api/Category
        /// This includes a query string for searching for specific results. 
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryVM>> Get([FromQuery] QuerySearch query)
        {
            return CategoryCollection.GetCategoryVMs(_accessor.HttpContext.Request.Host.Value, query)?.ToList();
        }
        /// <summary>
        /// GET api/Category/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:long}")]
        public ActionResult<CategoryVM> Get(long id)
        {
            return CategoryCollection.GetCategoryVMs(_accessor.HttpContext.Request.Host.Value)?.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// POST api/Category/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] Category Category)
        {
            Category.Id = CategoryCollection.Categories.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            CategoryCollection.Categories.Add(Category);
        }

        /// <summary>
        /// PUT api/Category/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category Category)
        {
            Category.Id = id;
            CategoryCollection.Categories.Add(Category);
        }

        /// <summary>
        /// Delete api/Category/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = CategoryCollection.Categories.FirstOrDefault(x => x.Id == id);
            CategoryCollection.Categories.Remove(delete);
        }
    }
}
