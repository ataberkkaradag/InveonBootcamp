using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP
{
    internal class OrderProcessor
    {
        private readonly INotifier _notifier;

        public OrderProcessor(INotifier notifier)
        {
            _notifier = notifier;

        }

        public void ProcessOrder(string order)
        {
            _notifier.Send(order);
        }
    }
}
