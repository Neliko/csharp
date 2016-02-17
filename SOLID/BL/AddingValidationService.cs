using System.Collections.Generic;
using System.Linq;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.BL
{
    class ValidationAndAddingService<TEntity> where TEntity : IEntity
    {
        private IValidator<TEntity> validator;

        public ValidationAndAddingService(IValidator<TEntity> validator)
        {
            this.validator = validator;
        }

        public void ValidateAndAddEntity(IRepository<TEntity> repository, TEntity entity)
        {
            if (validator.IsValid(entity))
                repository.Add(entity);
        }
    }
}
