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
    public class BookService: IBookService
    {
        private readonly string _key = "123456Qq";
        private readonly Lazy<IRepository<Book>> _bookRepository;
        private readonly Lazy<IRepository<Language>> _languageRepository;
        private readonly Lazy<IRepository<Author>> _authorRepository;
        private readonly Lazy<IRepository<BookImage>> _bookImageRepository;

        public BookService(Lazy<IRepository<Book>> bookRepository,
            Lazy<IRepository<Language>> languageRepository,
            Lazy<IRepository<Author>> authorRepository,
            Lazy<IRepository<BookImage>> bookImageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _authorRepository = authorRepository;
            _bookImageRepository = bookImageRepository;
        }
        public List<Book> GetEntities()
        {
            return _bookRepository.Value.GetQuery().ToList();
        }

        public Book Create()
        {
            return new Book();
        }
        public void Create(Book model)
        {
            model.CreateAt = DateTime.Now;

            if (model.BookImageFile != null)
            {
                var data = new byte[model.BookImageFile.ContentLength];
                model.BookImageFile.InputStream.Read(data, 0, model.BookImageFile.ContentLength);

                model.BookImage = new BookImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = model.BookImageFile.ContentType,
                    FileName = model.BookImageFile.FileName
                };
            }

            if (model.AuthorIds != null && model.AuthorIds.Any())
            {
                var author = _authorRepository.Value.GetQuery().Where(s => model.AuthorIds.Contains(s.Id)).ToList();
                model.Authors = author;
            }

            if (model.LanguageIds != null && model.LanguageIds.Any())
            {
                var language = _languageRepository.Value.GetQuery().Where(s => model.LanguageIds.Contains(s.Id)).ToList();
                model.Languages = language;
            }

            _bookRepository.Value.Add(model);
            _bookRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var book = _bookRepository.Value.FirstOrDefault(x => x.Id == id);
            if (book == null)
                throw new Exception("Book not found");

            _bookRepository.Value.Delete(book);
            _bookRepository.Value.SaveChanges();
        }
        public Book Edit(int id)
        {
            var book = _bookRepository.Value.FirstOrDefault(x => x.Id == id);
            if (book == null)
                throw new Exception("Book not found");

            return book;
        }
        public void Edit(Book model)
        {
            var book = _bookRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (book == null)
                throw new Exception("Book not found");

            if (model.Key != _key)
                throw new Exception("Ключ для создания/изменения записи указан не верно");


            MappingBook(model, book);

            _bookRepository.Value.Update(book);
            _bookRepository.Value.SaveChanges();
        }
        public BookImage GetImage(int id, HttpServerUtilityBase server)
        {
            var image = _bookImageRepository.Value.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                image = new BookImage()
                {
                    ContentType = "image/jpeg",
                    Data = fileData
                };
            }

            return image;
        }



        private void MappingBook(Book sourse, Book destination)
        {
            destination.Name = sourse.Name;
            destination.Isbn = sourse.Isbn;
            destination.Year = sourse.Year;
            destination.Cost = sourse.Cost;
            destination.GenreId = sourse.GenreId;
            destination.Genre = sourse.Genre;
            destination.CurrencyTypeId = sourse.CurrencyTypeId;
            destination.CurrencyType = sourse.CurrencyType;
            destination.IsArchive = sourse.IsArchive;
            destination.Annotation = sourse.Annotation;
            destination.Key = sourse.Key;                   //из-за Required

            if (destination.Authors != null)
                destination.Authors.Clear();

            if (sourse.AuthorIds != null && sourse.AuthorIds.Any())
                destination.Authors = _authorRepository.Value.GetQuery().Where(s => sourse.AuthorIds.Contains(s.Id)).ToList();

            if (destination.Languages != null)
                destination.Languages.Clear();

            if (sourse.LanguageIds != null && sourse.LanguageIds.Any())
                destination.Languages = _languageRepository.Value.GetQuery().Where(s => sourse.LanguageIds.Contains(s.Id)).ToList();


            if (sourse.BookImageFile != null)
            {
                var image = _bookImageRepository.Value.FirstOrDefault(x => x.Id == sourse.Id);
                if (image != null)
                {
                    _bookImageRepository.Value.Delete(image);
                    _bookImageRepository.Value.SaveChanges();
                }
                   

                var data = new byte[sourse.BookImageFile.ContentLength];
                sourse.BookImageFile.InputStream.Read(data, 0, sourse.BookImageFile.ContentLength);

                destination.BookImage = new BookImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.BookImageFile.ContentType,
                    FileName = sourse.BookImageFile.FileName
                };
            }
        }
    }
}
