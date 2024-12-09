using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP
{
    public interface INotifier
    {
        void Send(string message);
    }
}
