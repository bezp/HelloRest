using HelloRest.Service.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HelloRest.Service.Controllers
{
    [EnableCors("AllowNode")]
    [Consumes("application/xml")]
    [Produces("application/json")]
    [Route("api/[controller]")] //no action b/c we are dealing w/ API's b/c we are leveraging the http verbs
    public class MovieController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Get()
        {
            //Response.StatusCode = (int)HttpStatusCode.Accepted;
            //return new JsonResult(null);
            //return Ok(null); //why ok? b/c we want to use HTTP status code
            return Ok(MovieHelper.Movies);

        }

        [HttpGet("{pick:int}")]
        public IActionResult Get(uint pick)  //uint makes it positive only  
        {
            //var x = Request.QueryString.HasValue ? Request.Query["name"].ToString() : ""; //[HttpGet("{name: string}")]
            //var s = Response.Headers["content-type"] = "application/json, application/xml, application/text"; //[Produces("json")] same thing


           return pick > MovieHelper.Movies.Count ? (IActionResult)NotFound() : Ok(MovieHelper.Movies[(int)pick - 1]);


        }

    }
}
