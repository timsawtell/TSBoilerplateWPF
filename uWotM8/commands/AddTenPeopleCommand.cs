using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uWotM8.model;

namespace uWotM8.commands
{
    class AddTenPeopleCommand 
    {
        public Exception exception; // if there is a problem somewhere in the command, encapsulate it here

        public void execute()
        {
            Console.WriteLine(Thread.CurrentThread.IsBackground.ToString());
            for (int i = 1; i < 11; i++)
            {
                Person person = new Person();
                person.phone = i.ToString();
                person.name = String.Format("Johny {0}", i);
                PersonAccessor.addPerson(person);
            }
        }
    }
}
