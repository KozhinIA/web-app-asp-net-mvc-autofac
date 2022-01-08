using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IBookService
    {
        List<Book> GetEntities();
        Book Create();
        void Create(Book model);
        void Delete(int id);
        Book Edit(int id);
        void Edit(Book model);
        BookImage GetImage(int id, HttpServerUtilityBase server);
    }
}
