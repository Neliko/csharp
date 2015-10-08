using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HomeWork.UI.Model
{
    public interface IModel<in TEntity>
    {
        void SetValue(TEntity entity);
    }
}
