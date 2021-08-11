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
    public class QuantityTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuantityTypeController(IUnitOfWork work)
        {
            this._unitOfWork = work;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuantityTypes(int start = 0, int length = 10)
        {
            string search = HttpContext.Request.Query["search[value]"];

            return Json(_unitOfWork.QuantityTypes.GetDataTable(start, length, a => a.Name.Contains(search) && a.IsDeleted == false, a => a.ID));
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind("Name","ArabicName")] QuantityType quantity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Quantity Data is not completed");
            }
            _unitOfWork.QuantityTypes.Add(quantity);
            _unitOfWork.Completed();

            return Created("", quantity);
        }
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("The ID is not Specified");
            }
            var cateogry = _unitOfWork.QuantityTypes.GetByID(ID.Value);
            return PartialView(cateogry);

        }
        public ActionResult Edit(QuantityType quantityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Quantity Type  is not completed");
            }
            _unitOfWork.QuantityTypes.Edit(quantityType);
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
            var quantityType = _unitOfWork.QuantityTypes.GetByID(ID.Value);
            if (quantityType == null)
            {
                return NotFound("The Quantity Type doesn't Exist");
            }
            _unitOfWork.QuantityTypes.Delete(quantityType);
            _unitOfWork.Completed();


            return NoContent();

        }
    }
}
