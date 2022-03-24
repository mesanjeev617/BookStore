
using BookESale.DataAccess.Data;
using BookESale.DataAccess.Repository.IRepository;
using BookESale.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookESale.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        //get action method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                //This is adding new error in the name property in the controller model...
                ModelState.AddModelError("name", "Name and display order cannot be same...");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                //if we need to go to different control action method then we can use 
                //return RedirectToAction("action", "controller");
                TempData["success"] = "Category successfully created...";
                 return RedirectToAction("Index");
            }
                return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
          //var categoryFromDb = _db.Categories.Find(id);
            //if we use firstordefault then we can use 
           var categortFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u=> u.Id == id);
            //var categortFromDbSingle = _db.Categories.SingleOrDefault(u=> u.id == id);
            if(categortFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categortFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //This is adding new error in the name property in the controller model...
                ModelState.AddModelError("name", "Name and display order cannot be same...");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                //if we need to go to different control action method then we can use 
                //return RedirectToAction("action", "controller");
                TempData["success"] = "Category successfully updated...";
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
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //if we use firstordefault then we can use 
            //var categortFromDbFirst = _db.Categories.FirstOrDefault(u=> u.id == id);
            //var categortFromDbSingle = _db.Categories.SingleOrDefault(u=> u.id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category successfully deleted...";
            return RedirectToAction("Index");
        }
    }
}
