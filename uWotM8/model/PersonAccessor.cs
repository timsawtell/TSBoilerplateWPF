using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uWotM8.model
{
    class PersonAccessor
    {
        static public void addPerson(Person person)
        {
            Model.Instance.people.Add(person);
        }
    }
}
