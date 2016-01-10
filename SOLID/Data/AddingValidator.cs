using System;
using System.Collections.Generic;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.Data
{
    internal class AddingValidator<TEntity> where TEntity : IEntity
    {
        private static readonly IDictionary<string, object> ValidatorGetterDictionary =
            new Dictionary<string, object>
            {
                {
                   "Email",  new EmailValidator()
                },
                {
                   "Phone",  new PhoneValidator() 
                }
            };

        public static void ValidateAndAddEntity(List<TEntity> entities, TEntity entity)
        {
            var entityType = entity.GetType().Name;

            if (ValidatorGetterDictionary.ContainsKey(entityType))
            {
                var entityValidator = ValidatorGetterDictionary[entityType];

                if (!((IValidator<TEntity>)entityValidator).IsValid(entity))
                    throw new Exception(string.Format("Произошла ошибка валидации для сущности с типом {0}", entityType));
            }
            entities.Add(entity);
        }
    }
}