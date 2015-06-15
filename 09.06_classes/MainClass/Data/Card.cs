using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Card
    {
        private string _name;
        private long _synCode;
        private long _projectId;

        public Card()
        {
            _name = null;
            _synCode = 0;
            _projectId = 0;
        }

        public Card(string name, long synCode, long id)
        {
            _name = name;
            _synCode = synCode;
            _projectId = id;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetSynCode(long synCode)
        {
            _synCode = synCode;
        }

        public void SetProjectIs(long id)
        {
            _projectId = id;
        }

        public void GetData()
        {
            Console.WriteLine("Название проекта:"+ _name);
            Console.WriteLine("SynCode:" + _synCode);
            Console.WriteLine("Идентификатор:" + _projectId);
        }

      

    }



}
