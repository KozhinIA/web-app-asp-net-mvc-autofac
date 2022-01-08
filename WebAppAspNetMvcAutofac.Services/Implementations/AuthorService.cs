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
    public class AuthorService : IAuthorService
    {
        private readonly Lazy<IRepository<Author>> _authorRepository;

        public AuthorService(Lazy<IRepository<Author>> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public List<Author> GetEntities()
        {
            return _authorRepository.Value.GetQuery().ToList();
        }

        public Author Create()
        {
            return new Author();
        }
        public void Create(Author model)
        {
            _authorRepository.Value.Add(model);
            _authorRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var author = _authorRepository.Value.FirstOrDefault(x => x.Id == id);
            if (author == null)
                throw new Exception("Author not found");

            _authorRepository.Value.Delete(author);
            _authorRepository.Value.SaveChanges();
        }
        public Author Edit(int id)
        {
            var author = _authorRepository.Value.FirstOrDefault(x => x.Id == id);
            if (author == null)
                throw new Exception("Author not found");

            return author;
        }
        public void Edit(Author model)
        {
            var author = _authorRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (author == null)
                throw new Exception("Author not found");

            MappingAuthor(model, author);

            _authorRepository.Value.Update(author);
            _authorRepository.Value.SaveChanges();
        }

        private void MappingAuthor(Author sourse, Author destination)
        {
            destination.FirestName = sourse.FirestName;
            destination.LastName = sourse.LastName;
            destination.Birthday = sourse.Birthday;
            destination.Gender = sourse.Gender;
        }
    }
}
