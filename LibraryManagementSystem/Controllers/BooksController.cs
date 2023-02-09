using LibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LMSDBEntities db = new LMSDBEntities();

        // GET: Books View
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Books Data
        [HttpGet]
        public ActionResult GetData()
        {
            List<Book> bookList = new List<Book>();
            bookList = db.Books.ToList<Book>();
            return Json(new { data = bookList }, JsonRequestBehavior.AllowGet);
        }

        // GET: Add or Edit View
        [HttpGet]
        public ActionResult AddOREdit(string isbn = null)
        {
            if (isbn == null)
            {
                return View(new Book());
            }
            else
            {
                var book = db.Books.Where(x => x.ISBN == isbn).FirstOrDefault<Book>();
                return View(book);
            }
        }

        // POST: Add or Edit Book Data
        [HttpPost]
        public ActionResult AddOREdit(Book book)
        {
            var check = db.Books.Where(x => x.ISBN == book.ISBN).Any<Book>();
            if (!check)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // DELETE: Delete Book Data
        [HttpPost]
        public ActionResult Delete(string isbn)
        {
            var book = db.Books.Where(x => x.ISBN == isbn).FirstOrDefault<Book>();
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Can't Delete!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}