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
    public class GenreService : IGenreService
    {
        private readonly Lazy<IRepository<Genre>> _genreRepository;

        public GenreService(Lazy<IRepository<Genre>> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public List<Genre> GetEntities()
        {
            return _genreRepository.Value.GetQuery().ToList();
        }

        public Genre Create()
        {
            return new Genre();
        }
        public void Create(Genre model)
        {
            _genreRepository.Value.Add(model);
            _genreRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var genre = _genreRepository.Value.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                throw new Exception("Genre not found");

            _genreRepository.Value.Delete(genre);
            _genreRepository.Value.SaveChanges();
        }
        public Genre Edit(int id)
        {
            var genre = _genreRepository.Value.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                throw new Exception("Genre not found");

            return genre;
        }
        public void Edit(Genre model)
        {
            var genre = _genreRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (genre == null)
                throw new Exception("Genre not found");

            MappingGenre(model, genre);

            _genreRepository.Value.Update(genre);
            _genreRepository.Value.SaveChanges();
        }

        private void MappingGenre(Genre sourse, Genre destination)
        {
            destination.Name = sourse.Name;
        }
    }
}
