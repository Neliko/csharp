using HomeWork.Model;

namespace HomeWork.Validation
{
    interface IValidatorFactory
    {
        IValidator<TEntity> Create<TEntity>(TEntity entity) where TEntity : IEntity;
    }
}
