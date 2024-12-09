// See https://aka.ms/new-console-template for more information
using DIP.DIP;
using DIP;



Console.WriteLine("Hello, World!");



OrderModule orderModule = new OrderModule();
orderModule.ProcessOrder("IPhone");


INotifier emailNotifier = new DIP.DIP.EmailNotifier();
OrderProcessor orderProcessor = new OrderProcessor(emailNotifier);

orderProcessor.ProcessOrder("Laptop");
