using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace VueBlog.Controllers
{
    public class ArticleController : ApiController
    {
        [Authorize]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return Ok();
        }
    }
}