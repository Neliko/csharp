using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BL
{
    public interface IWriterService
    {
        void WriteAll(IReadOnlyCollection<IEntity> entities);
        void Write(IEntity entity);
    }
}
