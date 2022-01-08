using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface ILanguageService
    {
        List<Language> GetEntities();
        Language Create();
        void Create(Language model);
        void Delete(int id);
        Language Edit(int id);
        void Edit(Language model);
    }
}
