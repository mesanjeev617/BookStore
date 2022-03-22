
using BookESale.DataAccess.Data;
using BookESale.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookESale.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
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
                 _db.Categories.Add(obj);
                 _db.SaveChanges();
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
            var categoryFromDb = _db.Categories.Find(id);
            //if we use firstordefault then we can use 
            //var categortFromDbFirst = _db.Categories.FirstOrDefault(u=> u.id == id);
            //var categortFromDbSingle = _db.Categories.SingleOrDefault(u=> u.id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
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
                _db.Categories.Update(obj);
                _db.SaveChanges();
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
            var categoryFromDb = _db.Categories.Find(id);
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
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category successfully deleted...";
            return RedirectToAction("Index");
        }
    }
}
