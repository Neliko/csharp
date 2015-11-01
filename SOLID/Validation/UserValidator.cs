using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork.Model;

namespace HomeWork.Validation
{
    class UserValidator : IValidator<User>
    {
        public bool IsValid(User entity)
        {
            return entity.Name != null;
        }
    }
}
