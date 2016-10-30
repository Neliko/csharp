using HomeWork.Data;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.BL
{
   public class AddingService<TEntity> : IService<TEntity> where TEntity : IEntity
    {
        private readonly IValidatorFactory _validatorFactory;

        public AddingService(IValidatorFactory validatorFactory)
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
