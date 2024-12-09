using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    public class EmailNotifier
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }

    }


    public class OrderModule
    {
        EmailNotifier emailNotifier = new EmailNotifier();

        public void ProcessOrder(string order)
        {
            emailNotifier.Send($"{order} siparişi alındı");

        }
    }
}
