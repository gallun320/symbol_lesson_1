using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_api_lesson_1.Dto;

namespace rest_api_lesson_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/names
        [Route("names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetNames()
        {
            return await Task.FromResult(new string[] { "Rick", "James" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Get(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            return "value";
        }
        // GET api/values/name/message/?FirstName=Rick&LastName=Sanches
        [HttpGet("name/message")]
        public ActionResult<string> GetMessage([FromQuery] AuthorDto author)
        {
            return $"Здравствуй, {author.FirstName} из рода {author.LastName}";
        }

        // GET api/values/name/response/
        [HttpGet("name/response")]
        public HttpResponseMessage GetMessageHttp()
        {
            var keys = HttpContext.Request.Query.Keys;
            HttpResponseMessage res = null;
            if(keys.Count > 0)
            {
                res = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                res = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return res;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // POST api/values/names
        [HttpPost]
        [Route("names")]
        public ActionResult<string> PostNames([FromBody] string names)
        {
            return names.Split(':')[0];
        }

        // POST api/values/names/form
        [HttpPost]
        [Route("names/form")]
        public ActionResult<string> PostNamesForm([FromForm] string names)
        {
            return names.Split(':')[0];
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
