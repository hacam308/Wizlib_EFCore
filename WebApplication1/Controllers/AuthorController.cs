using Microsoft.AspNetCore.Mvc;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;
using Wizlib_Model.ViewModels;

namespace Wizlib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Author> objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult UpSert(int? Id)
        {
            Author obj = new Author();
            if (Id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(BookVM obj)
        {
            if (obj.Book.Book_Id == 0)
            {
                //create
                _db.Books.Add(obj.Book);
            }
            else
            {
                //update
                _db.Books.Update(obj.Book);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var objFormDb = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            _db.Books.Remove(objFormDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
