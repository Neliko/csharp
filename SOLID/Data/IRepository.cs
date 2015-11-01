using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.Data
{
    internal interface IRepository<TEntity, TValidator> where TEntity : IEntity, new() where TValidator : IValidator<TEntity>
    {
        void Add(TEntity contact);

        void Remove(TEntity contact);

        TEntity GetById(long id);

        TEntity[] GetAll();
    }
}
