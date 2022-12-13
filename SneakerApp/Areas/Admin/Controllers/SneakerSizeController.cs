using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerApp.DataAccess;
using SneakerApp.DataAccess.Repository.IRepository;
using SneakerApp.Models;
using SneakerApp.Utility;

namespace SneakerApp.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = SD.admin_user)]
	public class SneakerSizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public SneakerSizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<SneakerSize> objSneakerList = _unitOfWork.SneakerSize.GetAll();
            return View(objSneakerList);
        }

        //GET Action Method - View of Create Page
        public IActionResult Create()
        {
            return View();
        }

        //POST Action Method - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SneakerSize obj)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.SneakerSize.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Sneaker Size Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Action Method - View of Edit Page
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var sneakerSizeDb = _unitOfWork.SneakerSize.GetFirstOrDefault(u => u.Id == id);

            if (sneakerSizeDb == null)
            {
                return NotFound();
            }

            return View(sneakerSizeDb);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SneakerSize obj)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.SneakerSize.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Sneaker Size Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var sneakerSizeDb = _unitOfWork.SneakerSize.GetFirstOrDefault(u => u.Id == id);

            if (sneakerSizeDb == null)
            {
                return NotFound();
            }

            return View(sneakerSizeDb);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.SneakerSize.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.SneakerSize.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Sneaker Size Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
