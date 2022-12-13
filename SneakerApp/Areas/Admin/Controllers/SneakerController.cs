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
	public class SneakerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public SneakerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Sneaker> objSneakerList = _unitOfWork.Sneaker.GetAll();
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
        public IActionResult Create(Sneaker obj)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.Sneaker.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Sneaker Created Successfully!";
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

            var sneakerSizeDb = _unitOfWork.Sneaker.GetFirstOrDefault(u => u.Id == id);

            if (sneakerSizeDb == null)
            {
                return NotFound();
            }

            return View(sneakerSizeDb);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sneaker obj)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.Sneaker.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Sneaker Updated Successfully!";
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

            var sneakerSizeDb = _unitOfWork.Sneaker.GetFirstOrDefault(u => u.Id == id);

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
            var obj = _unitOfWork.Sneaker.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Sneaker.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Sneaker Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
