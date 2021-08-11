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
    public class CompaniesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork work)
        {
            this._unitOfWork = work;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCompanies(int start = 0, int length = 10)
        {
            string search = HttpContext.Request.Query["search[value]"];

            return Json(_unitOfWork.Companies.GetDataTable(start, length, a => a.Name.Contains(search) && a.IsDeleted == false, a => a.ID));
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind("Name","ArabicName")] Company company)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Company Data is not completed");
            }
            _unitOfWork.Companies.Add(company);
            _unitOfWork.Completed();

            return Created("", company);
        }
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("The ID is not Specified");
            }
            var cateogry = _unitOfWork.Companies.GetByID(ID.Value);
            return PartialView(cateogry);

        }
        public ActionResult Edit(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Company is not completed");
            }
            _unitOfWork.Companies.Edit(company);
            _unitOfWork.Completed();
            return NoContent();
        }
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("Company is not specified");
            }
            var company = _unitOfWork.Companies.GetByID(ID.Value);
            if (company == null)
            {
                return NotFound("Company Type doesn't Exist");
            }
            _unitOfWork.Companies.Delete(company);
            _unitOfWork.Completed();


            return NoContent();

        }
    }
}
