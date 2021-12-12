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
    public class CategoryController : ApiController
    {
        [HttpPost]
        [Route("add/category")]
        public IHttpActionResult Add(CategoryModel n)
        {
            if (CategoryService.Add(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("edit/category")]
        public IHttpActionResult Edit(CategoryModel n)
        {
            if (CategoryService.Edit(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("delete/category")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (CategoryService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/category")]
        public IHttpActionResult Get([FromUri] int id)
        {
            var data = CategoryService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/category/all")]
        public IHttpActionResult Get()
        {
            var data = CategoryService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
