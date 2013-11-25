using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uWotM8.commands
{
    class CommandCenter
    {
        public static void AddTenPeople(Action<Exception> completionBlock)
        {
            AddTenPeopleCommand cmd = new AddTenPeopleCommand();
            Task countToTenTask = Task.Factory.StartNew(() => { cmd.execute(); });
            Task completionTask = countToTenTask.ContinueWith(finishHim => {
                completionBlock(cmd.exception); // runs on the same thread as CommandCenter caller, i.e. main thread
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
