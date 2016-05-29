using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Data
{
    internal class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public readonly List<TEntity> Storage = new List<TEntity>();
        private readonly IExceptionHandler _exceptionHandler;

        public EntityRepository(IExceptionHandler exceptionHandler)
        {
            if (exceptionHandler == null)
            {
                throw new ArgumentNullException("exceptionHandler");
            }

            _exceptionHandler = exceptionHandler;
        }

        public void Add(TEntity entity)
        {
            try
            {
                Storage.Add(entity);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity contact)
        {
            Storage.Remove(contact);
        }

        public TEntity GetById(long id)
        {
            try
            {
                return Storage.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return Storage.ToArray();
        }
    }
}
