using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    internal interface IPaymentMethod
    {
        string ProcessPayment();
    }
    internal class PayPalPayment : IPaymentMethod
    {
        public string ProcessPayment()
        {
            return "Paypal ile ödeme işleniyor.";
        }
    }
    internal class CreditCardPayment : IPaymentMethod
    {
        public string ProcessPayment()
        {
            return "Kredi kartı ile ödeme işleniyor.";
        }
    }

    internal class BankTransferPayment : IPaymentMethod
    {
        public string ProcessPayment()
        {
            return "Banka transferi ile ödeme işleniyor.";
        }
    }
}


internal class PaymentProcessor
{


    public string ProcessPaymentAsDelegate(Func<string> paymentFunc)
    {
        return paymentFunc();
    }


    public void ProcessPayment(string paymentType) //OCP ye uymayan yapı
    {
        if (paymentType == "CreditCard")
        {
            Console.WriteLine("Kredi kartı ile ödeme işleniyor.");
        }
        else if (paymentType == "PayPal")
        {
            Console.WriteLine("PayPal ile ödeme işleniyor.");
        }
        else if (paymentType == "BankTransfer")
        {
            Console.WriteLine("Banka transferi ile ödeme işleniyor.");
        }
        else
        {
            throw new Exception("Geçersiz ödeme türü!");
        }
    }
}
