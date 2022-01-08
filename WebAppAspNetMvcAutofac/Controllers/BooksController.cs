using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var books = _bookService.GetEntities();

            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var book = _bookService.Create();
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _bookService.Create(model);

            return RedirectPermanent("/Books/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return RedirectPermanent("/Books/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = _bookService.Edit(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book model)
        {            
            if (!ModelState.IsValid)
                return View(model);

            _bookService.Edit(model);

            return RedirectPermanent("/Books/Index");
        }

       

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var image = _bookService.GetImage(id, Server);

            return File(new MemoryStream(image.Data), image.ContentType);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var book = _bookService.Edit(id);

            return View(book);
        }
        
    }
}