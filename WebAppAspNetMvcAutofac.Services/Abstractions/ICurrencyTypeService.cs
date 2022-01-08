using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface ICurrencyTypeService
    {
        List<CurrencyType> GetEntities();
        CurrencyType Create();
        void Create(CurrencyType model);
        void Delete(int id);
        CurrencyType Edit(int id);
        void Edit(CurrencyType model);
    }
}
