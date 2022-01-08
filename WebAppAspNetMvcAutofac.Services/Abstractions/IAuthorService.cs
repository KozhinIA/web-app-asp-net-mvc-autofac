using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IAuthorService
    {
        List<Author> GetEntities();
        Author Create();
        void Create(Author model);
        void Delete(int id);
        Author Edit(int id);
        void Edit(Author model);
    }
}
