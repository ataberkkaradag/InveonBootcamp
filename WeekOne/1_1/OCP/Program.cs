// See https://aka.ms/new-console-template for more information
using OCP;




Console.WriteLine("Hello, World!");

IPaymentMethod creditCardPayment = new CreditCardPayment();
PaymentProcessor paymentProcessor = new PaymentProcessor();

paymentProcessor.ProcessPayment("PayPal");

var result = paymentProcessor.ProcessPaymentAsDelegate(creditCardPayment.ProcessPayment);
Console.WriteLine(result);

Console.ReadLine();
