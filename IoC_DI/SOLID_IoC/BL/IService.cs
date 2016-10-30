using HomeWork.Data;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.BL
{
    interface IService<TEntity> where TEntity: IEntity
    {
        void ValidateAndAddEntity(IRepository<TEntity> repository, TEntity entity);
    }
}
