using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IGenreService
    {
        List<Genre> GetEntities();
        Genre Create();
        void Create(Genre model);
        void Delete(int id);
        Genre Edit(int id);
        void Edit(Genre model);
    }
}
