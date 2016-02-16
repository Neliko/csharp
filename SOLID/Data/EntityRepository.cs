﻿using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Data
{
    internal class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public readonly List<TEntity> _storage = new List<TEntity>();
        private readonly IExceptionHandler exceptionHandler;

        public EntityRepository(IExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public void Add(TEntity entity)
        {
            try
            {
                _storage.Add(entity);
            }
            catch (Exception e)
            {
                exceptionHandler.Handle(e);
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
                exceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return _storage.ToArray();
        }
    }
}
