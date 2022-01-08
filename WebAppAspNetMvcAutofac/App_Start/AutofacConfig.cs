using Autofac;
using Autofac.Integration.Mvc;
using Common.Autofac.Modules;
using Common.Entity;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<LibraryContext>().AsSelf().InstancePerHttpRequest();
            builder.RegisterModule(new ModuleRegisterBaseRepository<IDataContext, LibraryContext>());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<CurrencyTypeService>().As<ICurrencyTypeService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<LanguageService>().As<ILanguageService>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
