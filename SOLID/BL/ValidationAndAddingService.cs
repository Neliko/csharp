using HomeWork.Data;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.BL
{
    class ValidationAndAddingService<TEntity> where TEntity : IEntity
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidationAndAddingService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public void ValidateAndAddEntity(IRepository<TEntity> repository, TEntity entity)
        {
            var validator = _validatorFactory.Create(entity);
            if (validator.IsValid(entity))
                repository.Add(entity);
        }
    }
}
