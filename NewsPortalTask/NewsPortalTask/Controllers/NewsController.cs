using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortalTask.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("add/news")]
        public IHttpActionResult Add(NewsModel n)
        {
            if (NewsService.Add(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("edit/news")]
        public IHttpActionResult Edit(NewsModel n)
        {
            if (NewsService.Edit(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("delete/news")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if (NewsService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/news")]
        public IHttpActionResult Get([FromUri]int id)
        {
            var data = NewsService.Get(id);
            if (data!=null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/news/all")]
        public IHttpActionResult Get()
        {
            var data = NewsService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/news/bydate")]
        public IHttpActionResult Get([FromUri] DateTime dateTime)
        {
            var data = NewsService.GetByDate(dateTime);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/news/bycategory")]
        public IHttpActionResult Get([FromUri] string category)
        {
            var data = NewsService.GetByCategory(category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/news/bydate/category")]
        public IHttpActionResult Get([FromUri] DateTime dateTime, [FromUri] string category)
        {
            var data = NewsService.GetByDateCategory(dateTime, category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
