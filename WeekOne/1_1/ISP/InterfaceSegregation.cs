using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public interface IWorkable
    {
        void Work();
    }

    public interface ISalaryReceivable
    {
        void GetSalary();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class OfficeWorker : IWorkable, ISalaryReceivable, IEatable
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

    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot çalışıyor");
        }
    }
    internal class InterfaceSegregation
    {
    }
}
