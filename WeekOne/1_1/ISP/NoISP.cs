using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.NoISP
{
    public interface IWorker
    {
        void Work();
        void GetSalary();
        void Eat();
    }

    public class OfficeWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Ofis çalışanı çalışıyor");
        }

        public void GetSalary()
        {
            Console.WriteLine("Ofis çalışanı maaş alıyor");
        }

        public void Eat()
        {
            Console.WriteLine("Ofis çalışanı yemek yiyor");
        }
    }



    public class RobotWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Robot çalışıyor");
        }

        public void GetSalary()
        {
            throw new NotImplementedException("Robot maaş almaz");
        }

        public void Eat()
        {
            throw new NotImplementedException("Robot yemek yemez");
        }
    }

    internal class NoISP
    {
    }
}
