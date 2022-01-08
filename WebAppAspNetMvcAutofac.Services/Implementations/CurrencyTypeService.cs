using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public class CurrencyTypeService : ICurrencyTypeService
    {
        private readonly Lazy<IRepository<CurrencyType>> _currencyTypeRepository;

        public CurrencyTypeService(Lazy<IRepository<CurrencyType>> currencyTypeRepository)
        {
            _currencyTypeRepository = currencyTypeRepository;
        }
        public List<CurrencyType> GetEntities()
        {
            return _currencyTypeRepository.Value.GetQuery().ToList();
        }

        public CurrencyType Create()
        {
            return new CurrencyType();
        }
        public void Create(CurrencyType model)
        {
            _currencyTypeRepository.Value.Add(model);
            _currencyTypeRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var currencyType = _currencyTypeRepository.Value.FirstOrDefault(x => x.Id == id);
            if (currencyType == null)
                throw new Exception("CurrencyType not found");

            _currencyTypeRepository.Value.Delete(currencyType);
            _currencyTypeRepository.Value.SaveChanges();
        }
        public CurrencyType Edit(int id)
        {
            var currencyType = _currencyTypeRepository.Value.FirstOrDefault(x => x.Id == id);
            if (currencyType == null)
                throw new Exception("CurrencyType not found");

            return currencyType;
        }
        public void Edit(CurrencyType model)
        {
            var currencyType = _currencyTypeRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (currencyType == null)
                throw new Exception("CurrencyType not found");

            MappingCurrencyType(model, currencyType);

            _currencyTypeRepository.Value.Update(currencyType);
            _currencyTypeRepository.Value.SaveChanges();
        }

        private void MappingCurrencyType(CurrencyType sourse, CurrencyType destination)
        {
            destination.Name = sourse.Name;
            destination.LetterCode = sourse.LetterCode;
            destination.NumericCode = sourse.NumericCode;
        }
    }
}
