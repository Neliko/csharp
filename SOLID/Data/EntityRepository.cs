using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Data
{
<<<<<<< HEAD
    internal class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
     
        public readonly List<TEntity> _storage = new List<TEntity>();
        ExceptionHandler exceptionHandler = new ExceptionHandler();

        public void Add(TEntity entity)
        {
            try
            {
                AddingValidator<TEntity>.ValidateAndAddEntity(_storage, entity);
            }
            catch (Exception e)
            {
                exceptionHandler.Handle(e);
=======
    internal class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly List<TEntity> _storage = new List<TEntity>();
        private readonly ExceptionHandler _exceptionHandler = new ExceptionHandler();
        public void Add(TEntity contact)
        {
            try
            {
                _storage.Add(contact);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
>>>>>>> master
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
<<<<<<< HEAD
                exceptionHandler.Handle(e);
=======
                _exceptionHandler.Handle(e);
>>>>>>> master
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return _storage.ToArray();
        }
    }
}
