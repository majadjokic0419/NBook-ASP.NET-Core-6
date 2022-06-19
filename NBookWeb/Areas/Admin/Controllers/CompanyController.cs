using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NBook.DataAccess;
using NBook.DataAccess.Repository.IRepository;
using NBook.Models;

using NBook.Models.ViewModels;
using NBook.Utility;

namespace NBookWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }

     
       
        //GET
        public IActionResult Upsert(int? id)
        {
            //ProductVM productVM = new()
            //{
            //    Product = new(),
            //    CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            //    {
            //        Text = i.Name,
            //        Value = i.Id.ToString()
            //    }),
            //    CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem()
            //    {
            //        Text = i.Name,
            //        Value = i.Id.ToString()
            //    })
            //};

            Company company = new();

            if (id == null || id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(company);
            }
            else
            {
               company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);
                //Update product
            }
            

            
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
           
            if (ModelState.IsValid)
            {

               

                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company created successfully";

                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }





        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll() ;
            return Json(new { data = companyList });
        }



        [HttpDelete]
       
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new {success=false,message="Error while deleting"});
            }

            
                
            

            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            
            return Json(new {success=true,message="Delete Successful"});

        }
        #endregion
    }


}

