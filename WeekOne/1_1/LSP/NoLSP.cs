using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Hayvan bir ses çıkarıyor.");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Köpek havlıyor");
        }
    }

    public class Fish : Animal
    {
        // Fish sınıfı ses çıkaramaz, ancak MakeSound'ı override etmek zorunda
        public override void MakeSound()
        {
            throw new NotSupportedException("Balıklar ses çıkaramaz");
        }
    }
    internal class NoLSP
    {
    }
}
