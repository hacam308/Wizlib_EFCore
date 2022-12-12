using Microsoft.AspNetCore.Mvc;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;

namespace Wizlib.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Publisher> objList = _db.Publishers.ToList();
            return View(objList);
        }

        public IActionResult UpSert(int? Id)
        {
            Publisher obj = new Publisher();
            if (Id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //create
                    _db.Publishers.Add(obj);
                }
                else
                {
                    //update
                    _db.Publishers.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var objFormDb = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            _db.Publishers.Remove(objFormDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
