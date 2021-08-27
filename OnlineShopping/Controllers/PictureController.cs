using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpGet("{name?}")]
        public IActionResult Get([FromQuery]string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }
            return File($"~/images/{name}", "image/png");
          
        }
    }
}
