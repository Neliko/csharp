using HomeWork.Model;

namespace HomeWork.Validation
{
    public interface IValidator<in TEntity> where TEntity: IEntity
    {
        bool IsValid(TEntity entity);
    }
}
