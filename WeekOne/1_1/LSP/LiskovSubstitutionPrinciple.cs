using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    public interface IMovable
    {
        void Move();
    }


    public interface IEatable
    {
        void Eat();
    }


    public interface IFlyable
    {
        void Fly();
    }


    public class Cat : IMovable, IEatable
    {
        public void Move()
        {
            Console.WriteLine("Köpek koşuyor");
        }

        public void Eat()
        {
            Console.WriteLine("Köpek yemek yiyor");
        }
    }


    public class Bird : IMovable, IEatable, IFlyable
    {
        public void Move()
        {
            Console.WriteLine("Kuş yürüyor");
        }

        public void Eat()
        {
            Console.WriteLine("Kuş yemek yiyor");
        }

        public void Fly()
        {
            Console.WriteLine("Kuş uçuyor");
        }
    }
    internal class LiskovSubstitutionPrinciple
    {
    }
}
