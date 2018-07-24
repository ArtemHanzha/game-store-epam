using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Task.Contracts.Modes;
using Task.DAL.Interfaces;
using Task.Services.Interfaces;

namespace Task.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(
            IUnitOfWork unitOfWork,
            IRepository<Genre> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<Genre> Get(Expression<Func<Genre, bool>> predicate = null)
        {
            return _repository.Get(predicate);
        }

        public Genre GetById(int itemId)
        {
            return _repository.Get(itemId);
        }

        public void Delete(int itemId)
        {
            _repository.Delete(itemId);
        }

        public void Update(Genre item)
        {
            _repository.Update(item);
        }

        public void Create(Genre item)
        {
            _repository.Create(item);
        }

        public Genre GetByName(string name)
        {
            //var genres = _repository.Get(g => string.Equals(g.Name, name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var genres = _repository.Get(g => g.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return genres;
        }
    }
}