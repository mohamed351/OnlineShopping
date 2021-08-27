using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork work;

        public CategoriesController(IUnitOfWork work)
        {
            this.work = work;
        }
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(work.Categories.GetAll());
        }
    }
}
