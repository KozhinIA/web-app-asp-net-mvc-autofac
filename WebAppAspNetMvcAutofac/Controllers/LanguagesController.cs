using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class LanguagesController : Controller
    {
        private ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var languages = _languageService.GetEntities();

            return View(languages);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var language = _languageService.Create();
            return View(language);
        }

        [HttpPost]
        public ActionResult Create(Language model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _languageService.Create(model);

            return RedirectPermanent("/Languages/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _languageService.Delete(id);

            return RedirectPermanent("/Languages/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var language = _languageService.Edit(id);

            return View(language);
        }

        [HttpPost]
        public ActionResult Edit(Language model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _languageService.Edit(model);

            return RedirectPermanent("/Languages/Index");
        }

       
    }
}