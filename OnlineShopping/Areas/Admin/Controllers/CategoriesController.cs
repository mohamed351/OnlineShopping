using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using OnlineShopping.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork work)
        {
            this._unitOfWork = work;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCateogry(int start = 0, int length = 10)
        {
            string search = HttpContext.Request.Query["search[value]"];

            return Json(_unitOfWork.Categories.GetDataTable(start, length, a => a.Name.Contains(search) && a.IsDeleted == false, a => a.ID));
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind("Name", "ArabicName")] Category category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Category Data is not completed");
            }
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Completed();

            return Created("", category);
        }
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The ID is not Specified");
            }
           var cateogry = _unitOfWork.Categories.GetByID(ID.Value);
            return PartialView(cateogry);

        }
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Category Data is not completed");
            }
            _unitOfWork.Categories.Edit(category);
            _unitOfWork.Completed();
            return NoContent();
        }
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("The ID is not specified");
            }
            var book = _unitOfWork.Categories.GetByID(ID.Value);
            if (book == null)
            {
                return NotFound("The Category doesn't Exist");
            }
            _unitOfWork.Categories.Delete(book);
            _unitOfWork.Completed();


            return NoContent();

        }

    }
}
