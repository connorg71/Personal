using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGameBlog.BLL.Managers;

namespace VideoGameBlog.UI.Controllers
{
    public class APIController : ApiController
    {
        [Route("api/staticpages/get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetStaticPages()
        {
            var manager = new StaticPageManager();
            var result = manager.GetAllStaticPage();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Payload);
            }
        }
    }
}
