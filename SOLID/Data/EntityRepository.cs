using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.Data
{
    internal class EntityRepository<TEntity, TValidator> : IRepository<TEntity, TValidator>
        where TEntity : class, IEntity, new()
        where TValidator : IValidator<TEntity>, new()
    {
        private readonly List<TEntity> _storage = new List<TEntity>();
        private readonly IException _exceptionHandler = new ExceptionHandler(new FileLogger());
        private readonly IValidator<TEntity> _validator = new TValidator();
        public void Add(TEntity entity)
        {
            try
            {
                if (_validator.IsValid(entity))
                    _storage.Add(entity);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity contact)
        {
            _storage.Remove(contact);
        }

        public TEntity GetById(long id)
        {
            try
            {
                return _storage.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return _storage.ToArray();
        }
    }
}
