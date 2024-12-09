// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");


var stopwatch = Stopwatch.StartNew();

var task1 = TaskExample("Task1", 3000);
var task2 = TaskExample("Task2", 5000);

await Task.WhenAll(task1, task2);


stopwatch.Stop();
Console.WriteLine($"{stopwatch.ElapsedMilliseconds}");


Console.WriteLine("---------------------");

await Task.WhenAny(task1, task2);  //Tamamlanan ilk işlemi döner.
static async Task TaskExample(string taskTitle, int delay)
{
    Console.WriteLine($"{taskTitle} başladı");
    await Task.Delay(delay);
    Console.WriteLine($"{taskTitle} sonlandı");
}
