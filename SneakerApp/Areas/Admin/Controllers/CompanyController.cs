using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using SneakerApp.DataAccess;
using SneakerApp.DataAccess.Repository.IRepository;
using SneakerApp.Models;
using SneakerApp.Models.ViewModels;
using SneakerApp.Utility;

namespace SneakerApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.admin_user)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET Action Method - Upsert
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            {

                if (id == null || id == 0)
                {
                    return View(company);
                }
                else
                {
                    company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                    return View(company);
                }
            }
        }

        //POST Action Method - Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            if (ModelState.IsValid) // Server Side Validation
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company Created Successfully!";
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company Updated Successfully!";
                    _unitOfWork.Save();
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting record." });
            }

            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully." });
        }
        #endregion
    }
}
