using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Task.Contracts.Interfaces;
using Task.Contracts.Modes;
using Task.DAL.Interfaces;
using Task.Services.Interfaces;

namespace Task.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _repository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ILoggerManager _logger;

        public GameService(
            IRepository<Game> repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Game> Get(Expression<Func<Game, bool>> predicate = null)
        {
            return _repository.Get(predicate);
        }

        public Game GetById(int itemId)
        {
            return _repository.Get(itemId);
        }

        public void Delete(int itemId)
        {
            _repository.Delete(itemId);
            _unitOfWork.Save();
        }

        public void Update(Game item)
        {
            _repository.Update(item);
            _unitOfWork.Save();
        }

        public void Create(Game item)
        {
            _repository.Create(item);
            _unitOfWork.Save();
        }

        public void DeleteByKey(string key)
        {
            var game = _repository.Get(g => g.Key == key).FirstOrDefault();
            if (game != null)
                game.IsDeleted = true;
            _repository.Update(game);
            _unitOfWork.Save();
        }

        public Game GetByKey(string key)
        {
            var item = _repository.Get(i => i.Key == key).FirstOrDefault();
            return item;
        }

        public IEnumerable<Game> GetByGenre(string genre)
        {
            var items = _repository.Get(g => g.Genres.Any(a => a.Name.Contains(genre)));
            return items;
        }

        public IEnumerable<Game> GetByPlatformType(string platformType)
        {
            var items = _repository.Get(g => g.Platforms.Any(a => a.Type.Contains(platformType)));
            return items;
        }
    }
}