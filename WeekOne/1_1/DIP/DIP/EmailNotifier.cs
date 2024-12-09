using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP
{
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
