using System;
using System.Collections.Generic;
using Data.Infrostructure;

namespace Data.BL
{
    public class WriterService : IWriterService
    {
        private readonly IWriter _writer;
        public WriterService(IWriter writer)
        {
            if (writer == null)
            {
                throw new Exception("Необходимо указать writer");
            }
            _writer = writer;
        }

        public void WriteAll(IReadOnlyCollection<IEntity> entities )
        {
            foreach (var entity in entities)
            {
                _writer.Write(entity.GetType().Name);
                _writer.Write(entity.ToString());
            }
        }

        public void Write(IEntity entity)
        {
            _writer.Write(entity.ToString());  
        }
    }
}
