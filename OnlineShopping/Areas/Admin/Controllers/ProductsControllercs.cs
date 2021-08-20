using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Areas.Admin.ViewModels;
using OnlineShopping.Repository.Interfaces;
using OnlineShopping.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;

        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetProducts(int start = 0, int length = 10)
        {
            string search = HttpContext.Request.Query["search[value]"];
            return Json(unitOfWork.Products.GetDataTableProduct(start,length,a=>a.IsDeleted == false && a.Name.Contains(search),a=>a.ID));
        }
        public ActionResult Create()
        {
            ViewBag.QuantityTypeID = new SelectList(unitOfWork.QuantityTypes.GetAll(),"ID","Name");
            ViewBag.CateogryID = new SelectList(unitOfWork.Categories.GetAll(),"ID", "Name");
            ViewBag.CompanyID = new SelectList(unitOfWork.Companies.GetAll(), "ID", "Name");
             //product size if there is a size for a product 
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }
            //use auto mapper but i don't have internet connection
            var product = new Product()
            {
                CateogryID = productViewModel.CateogryID,
                CompanyID = productViewModel.CompanyID,
                ImageURL =!String.IsNullOrEmpty( productViewModel.ImageBase64)? ConvertMainImage(productViewModel.ImageBase64):"",
                Description = productViewModel.Description,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity,
                QuantityTypeID = productViewModel.QuantityTypeID,


            };
            unitOfWork.Products.Add(product);
            unitOfWork.Completed();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The ID is not Found");
            }
           var product = unitOfWork.Products.GetByID(ID.Value);
            ViewBag.CateogryID = new SelectList(unitOfWork.Categories.GetAll(), "ID", "Name",product.CateogryID);
            ViewBag.CompanyID = new SelectList(unitOfWork.Companies.GetAll(), "ID", "Name", product.CompanyID);
            ViewBag.QuantityTypeID = new SelectList(unitOfWork.QuantityTypes.GetAll(), "ID", "Name", product.QuantityTypeID);
            var productEditViewModel = new ProductEditViewModel()
            {
                ID = product.ID,
                CompanyID = product.CompanyID,
                CateogryID = product.CateogryID,
                ImageBase64 = null,
                ImageUrl = product.ImageURL,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityTypeID = product.QuantityTypeID
            };

            return View(productEditViewModel);

        }
        [HttpPost]
        public ActionResult Edit(ProductEditViewModel productEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productEditViewModel);
            }
            

            return RedirectToAction(nameof(Index));
        }

        private string ConvertMainImage(string imageBase64)
        {
            var array = Convert.FromBase64String(imageBase64.Split(";base64,")[1]);
            string imageName = Guid.NewGuid().ToString() + ".png";
            using (FileStream file = new FileStream($"{this.environment.WebRootPath}//images//{imageName}", FileMode.CreateNew, FileAccess.Write))
            {
                file.Write(array, 0, array.Length);
            }
            return imageName;

        }

    }
}
