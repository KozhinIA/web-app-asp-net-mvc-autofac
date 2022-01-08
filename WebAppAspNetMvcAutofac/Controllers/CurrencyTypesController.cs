using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class CurrencyTypesController : Controller
    {
        private ICurrencyTypeService _currencyTypeService;
        public CurrencyTypesController(ICurrencyTypeService currencyTypeService)
        {
            _currencyTypeService = currencyTypeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currencyTypes = _currencyTypeService.GetEntities().ToList();

            return View(currencyTypes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var currencyType = _currencyTypeService.Create();
            return View(currencyType);
        }

        [HttpPost]
        public ActionResult Create(CurrencyType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _currencyTypeService.Create(model);

            return RedirectPermanent("/CurrencyTypes/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _currencyTypeService.Delete(id);

            return RedirectPermanent("/CurrencyTypes/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var currencyType = _currencyTypeService.Edit(id);

            return View(currencyType);
        }

        [HttpPost]
        public ActionResult Edit(CurrencyType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _currencyTypeService.Edit(model);

            return RedirectPermanent("/CurrencyTypes/Index");
        }

       
    }
}