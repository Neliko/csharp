using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork.Data.Model;
using HomeWork.UI.Model;

namespace HomeWork.UI.ModelConverter
{
    class ContactConverter
    {
        public static ContactModel ConvertEntityToModel(Contact contacts)
        {
           return new ContactModel{Value = contacts.Value};
        }
    }
}
