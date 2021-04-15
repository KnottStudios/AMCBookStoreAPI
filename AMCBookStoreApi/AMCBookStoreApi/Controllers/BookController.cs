using AMCBookStoreApi.Collections;
using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AMCBookStoreApi.Controllers
{
    /// <summary>
    /// The Controller for getting books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private readonly IHttpContextAccessor _accessor;

        public BookController(ILogger<BookController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accessor = httpContextAccessor;
        }
        /// <summary>
        /// GET: api/Book
        /// This includes a query string for searching for specific results. 
        /// 
        /// USE THIS TO FETCH THE FIRST 10 BOOKS BY SCOTT ADAMS IN THE AUDIO BOOK CATEGORY.    
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<BookVM>> Get([FromQuery] QuerySearch query)
        {
            return BookCollection.GetBookVMs(_accessor.HttpContext.Request.Host.Value, query)?.ToList();
        }
        /// <summary>
        /// GET api/Book/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:long}")]
        public ActionResult<BookVM> Get(long id)
        {
            return BookCollection.GetBookVMs(_accessor.HttpContext.Request.Host.Value)?.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// POST api/Book/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            book.Id = BookCollection.Books.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            BookCollection.Books.Add(book);
        }

        /// <summary>
        /// PUT api/Book/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            book.Id = id;
            BookCollection.Books.Add(book);
        }

        /// <summary>
        /// Delete api/Book/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = BookCollection.Books.FirstOrDefault(x => x.Id == id);
            BookCollection.Books.Remove(delete);
        }
    }
}
