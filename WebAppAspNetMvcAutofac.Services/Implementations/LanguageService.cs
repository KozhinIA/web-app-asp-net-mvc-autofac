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
    public class LanguageService : ILanguageService
    {
        private readonly Lazy<IRepository<Language>> _languageRepository;

        public LanguageService(Lazy<IRepository<Language>> languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public List<Language> GetEntities()
        {
            return _languageRepository.Value.GetQuery().ToList();
        }

        public Language Create()
        {
            return new Language();
        }
        public void Create(Language model)
        {
            _languageRepository.Value.Add(model);
            _languageRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var language = _languageRepository.Value.FirstOrDefault(x => x.Id == id);
            if (language == null)
                throw new Exception("Language not found");

            _languageRepository.Value.Delete(language);
            _languageRepository.Value.SaveChanges();
        }
        public Language Edit(int id)
        {
            var language = _languageRepository.Value.FirstOrDefault(x => x.Id == id);
            if (language == null)
                throw new Exception("Language not found");

            return language;
        }
        public void Edit(Language model)
        {
            var language = _languageRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (language == null)
                throw new Exception("Language not found");

            MappingLanguage(model, language);

            _languageRepository.Value.Update(language);
            _languageRepository.Value.SaveChanges();
        }

        private void MappingLanguage(Language sourse, Language destination)
        {
            destination.Name = sourse.Name;
        }
    }
}
