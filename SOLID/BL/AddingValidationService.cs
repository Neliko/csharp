using System.Collections.Generic;
using System.Linq;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.BL
{
    class AddingValidationService<TEntity> where TEntity : IEntity
    {
        private ILogger logger;
        private readonly IDictionary<string, object> ValidatorGetterDictionary;

        public AddingValidationService(ILogger logger)
        {
            this.logger = logger;
            ValidatorGetterDictionary = new Dictionary<string, object>
            {
                {
                   "Email",  new EmailValidator(logger)
                },
                {
                   "Phone",  new PhoneValidator(logger) 
                }
            };
        }

        public void ValidateAndAddEntity(IRepository<TEntity> repository, TEntity entity)
        {
            var entityType = entity.GetType().Name;

            if (ValidatorGetterDictionary.ContainsKey(entityType))
            {
                var entityValidator = ValidatorGetterDictionary[entityType];
                
                if(((IValidator<TEntity>)entityValidator).IsValid(entity))
                    repository.Add(entity); 
            }  
        }
    }
}
