using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DTO;
using OnlineShopping.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor accessor;

        public ProductsController(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            this.accessor = accessor;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.Products.GetByCondition(a => a.IsDeleted == false).Select(a => new ProductCategoryDTO()
            {
                ID = a.ID,
                CateogryID = a.CateogryID,
                Image = accessor.HttpContext.Request.Scheme + "://" + accessor.HttpContext.Request.Host + "/api/Picture?name=" + a.ImageURL,
                Name = a.Name,
                Price = a.Price
            });
            return Ok(products);
        }
        [HttpGet("{id?}")]
        public IActionResult GetProductByID(int ? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var product = _unitOfWork.Products.GetByID(id.Value);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("cateogry/{id?}")]
        public IActionResult GetProductCategory(int? id)
        {
            if(id == null)
            {
                return BadRequest("The ID is not specified");
            }

            
           return Ok( _unitOfWork.Products.GetByCondition(a => a.CateogryID == id && a.IsDeleted ==false).Select(a=> new ProductCategoryDTO() { 
               ID =a.ID,
               CateogryID = a.CateogryID,
               Image =accessor.HttpContext.Request.Scheme+"://" +accessor.HttpContext.Request.Host+"/api/Picture?name="+a.ImageURL,
               Name = a.Name,
               Price= a.Price
           }));
        }
        
    }
}
