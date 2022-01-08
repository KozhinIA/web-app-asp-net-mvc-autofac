using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class GenresController : Controller
    {
        private IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var genres = _genreService.GetEntities();

            return View(genres);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genre = _genreService.Create();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Create(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _genreService.Create(model);

            return RedirectPermanent("/Genres/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _genreService.Delete(id);

            return RedirectPermanent("/Genres/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = _genreService.Edit(id);

            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _genreService.Edit(model);

            return RedirectPermanent("/Genres/Index");
        }

       
    }
}