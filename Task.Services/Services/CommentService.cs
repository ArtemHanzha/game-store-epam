using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Task.Contracts.Modes;
using Task.DAL.Interfaces;
using Task.Services.Interfaces;

namespace Task.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IRepository<Game> _gameRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(
            IRepository<Comment> repository, 
            IUnitOfWork unitOfWork, IRepository<Game> gameRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
        }

        public IEnumerable<Comment> Get(Expression<Func<Comment, bool>> predicate = null)
        {
            var items = _repository.Get(predicate);
            return items.ToList();
        }

        public Comment GetById(int itemId)
        {
            var item = _repository.Get(itemId);
            return item;
        }

        public IEnumerable<Comment> GetByGameKey(string gameKey)
        {
            var items = _repository.Get(c => c.Game.Key == gameKey);
            return items.ToList();
        }

        public void Delete(int itemId)
        {
            _repository.Delete(itemId);
            _unitOfWork.Save();
        }

        public void Update(Comment item)
        {
            _repository.Update(item);
            _unitOfWork.Save();
        }

        public void Create(Comment item)
        {
            _repository.Create(item);
            _unitOfWork.Save();
        }

        public void CreateForComment(Comment item, int gameId, int parrentCommentId = -1)
        {
            var game = _gameRepository.Get(gameId);
            var parrent = _repository.Get(parrentCommentId);
           
            item.Parrent = parrent;
            item.Game = game;

            game.Comments.Add(item);
            _repository.Create(item);

            _unitOfWork.Save();
        }
    }
}