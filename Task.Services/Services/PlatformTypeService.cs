using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Task.Contracts.Modes;
using Task.DAL.Interfaces;
using Task.Services.Interfaces;
using static System.String;

namespace Task.Services.Services
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IRepository<PlatformType> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PlatformTypeService(
            IRepository<PlatformType> repository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<PlatformType> Get(Expression<Func<PlatformType, bool>> predicate = null)
        {
            return _repository.Get(predicate);
        }

        public PlatformType GetById(int itemId)
        {
            return _repository.Get(itemId);
        }

        public void Delete(int itemId)
        {
            _repository.Delete(itemId);
            _unitOfWork.Save();
        }

        public void Update(PlatformType item)
        {
            _repository.Update(item);
            _unitOfWork.Save();
        }

        public void Create(PlatformType item)
        {
            _repository.Create(item);
            _unitOfWork.Save();
        }

        public PlatformType GetByName(string name)
        {
            //var item = _repository.Get(p => string.Equals(p.Type, name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var item = _repository.Get(g => g.Type.ToLower() == name.ToLower()).FirstOrDefault();
            return item;
        }
    }
}