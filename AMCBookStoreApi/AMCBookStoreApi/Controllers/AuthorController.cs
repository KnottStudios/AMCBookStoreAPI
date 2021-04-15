using AMCBookStoreApi.Collections;
using AMCBookStoreApi.ModelQueries;
using AMCBookStoreApi.Models;
using AMCBookStoreApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AMCAuthorStoreApi.Controllers
{
    /// <summary>
    /// The Controller for getting Authors.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;

        private readonly IHttpContextAccessor _accessor;

        public AuthorController(ILogger<AuthorController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accessor = httpContextAccessor;
        }
        /// <summary>
        /// GET: api/Author
        /// This includes a query string for searching for specific results. 
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<AuthorVM>> Get([FromQuery] AuthorQuery query)
        {
            return AuthorCollection.GetAuthorVMs(_accessor.HttpContext.Request.Host.Value)?.Take(query.MaxReturn)?.ToList();
        }
        /// <summary>
        /// GET api/Author/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:long}")]
        public ActionResult<AuthorVM> Get(long id)
        {
            return AuthorCollection.GetAuthorVMs(_accessor.HttpContext.Request.Host.Value)?.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// POST api/Author/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] Author Author)
        {
            Author.Id = AuthorCollection.Authors.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            AuthorCollection.Authors.Add(Author);
        }

        /// <summary>
        /// PUT api/Author/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author Author)
        {
            Author.Id = id;
            AuthorCollection.Authors.Add(Author);
        }

        /// <summary>
        /// Delete api/Author/id
        /// Would need OAuth to set this up well.
        /// </summary>
        /// <param name="value"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = AuthorCollection.Authors.FirstOrDefault(x => x.Id == id);
            AuthorCollection.Authors.Remove(delete);
        }
    }
}
