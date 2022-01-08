using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var authors = _authorService.GetEntities();

            return View(authors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var author = _authorService.Create();
            return View(author);
        }

        [HttpPost]
        public ActionResult Create(Author model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _authorService.Create(model);

            return RedirectPermanent("/Authors/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _authorService.Delete(id);

            return RedirectPermanent("/Authors/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var author = _authorService.Edit(id);

            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _authorService.Edit(model);

            return RedirectPermanent("/Authors/Index");
        }

       
    }
}