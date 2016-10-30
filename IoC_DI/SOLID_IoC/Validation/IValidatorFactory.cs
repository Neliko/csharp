using HomeWork.Model;

namespace HomeWork.Validation
{
    public interface IValidatorFactory
    {
        IValidator<TEntity> Create<TEntity>(TEntity entity) where TEntity : IEntity;
    }
}
