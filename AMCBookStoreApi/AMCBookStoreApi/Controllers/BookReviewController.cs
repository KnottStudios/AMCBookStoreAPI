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
    /// The Controller for getting BookReviews.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewController : Controller
    {
        private readonly ILogger<BookReviewController> _logger;

        private readonly IHttpContextAccessor _accessor;

        public BookReviewController(ILogger<BookReviewController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accessor = httpContextAccessor;
        }
        /// <summary>
        /// GET: api/BookReview
        /// This includes a query string for searching for specific results. 
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<BookReviewVM>> Get([FromQuery] QuerySearch query)
        {
            return BookReviewCollection.GetBookReviewVMs(_accessor.HttpContext.Request.Host.Value, query)?.ToList();
        }
        /// <summary>
        /// GET api/BookReview/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:long}")]
        public ActionResult<BookReviewVM> Get(long id)
        {
            return BookReviewCollection.GetBookReviewVMs(_accessor.HttpContext.Request.Host.Value)?.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// POST api/BookReview/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] BookReview BookReview)
        {
            BookReview.Id = BookReviewCollection.BookReviews.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            BookReviewCollection.BookReviews.Add(BookReview);
        }

        /// <summary>
        /// PUT api/BookReview/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookReview BookReview)
        {
            BookReview.Id = id;
            BookReviewCollection.BookReviews.Add(BookReview);
        }

        /// <summary>
        /// Delete api/BookReview/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = BookReviewCollection.BookReviews.FirstOrDefault(x => x.Id == id);
            BookReviewCollection.BookReviews.Remove(delete);
        }
    }
}
