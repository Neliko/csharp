using System;
using System.Collections.Generic;
using System.Linq;
using Data.Infrostructure;

namespace Data.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity :  IEntity
    {    
        protected readonly List<TEntity> Storage = new List<TEntity>();
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IWriter _writer;

        public Repository(IExceptionHandler exceptionHandler, IWriter writer)
        {
            if (exceptionHandler == null)
            {
                throw new Exception("Необходимо указать exceptionHandler");
            }
            _exceptionHandler = exceptionHandler;

            if (writer == null)
            {
                throw new Exception("Необходимо указать writer");
            }
            _writer = writer;
        }
        public void Add(TEntity entity)
        {
            try
            {
                Storage.Add(entity);
                _writer.Write(entity.ToString());
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity entity)
        {
            Storage.Remove(entity);
        }

        public TEntity GetById(long id)
        {
            return Storage.First(x => x.Id == id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return Storage;
        }
    }
}
