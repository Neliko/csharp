using System;
using System.Collections.Generic;
using HomeWork.Model;

namespace HomeWork.Validation
{
class ValidatorFactory : IValidatorFactory
   {
       private readonly Dictionary<Type, object> _registry;

       public ValidatorFactory(Dictionary<Type, object> registry)
       {
           _registry = registry;
       }

       public IValidator<TEntity> Create<TEntity>(TEntity entity) where TEntity : IEntity
       {
           var entityType = entity.GetType();
           return (IValidator<TEntity>) _registry[entityType];
       }
   }
}
