Thread simpleThread = new(() =>
{
    for (int i = 0; i < 999; i++)
        Console.WriteLine($"Worker Thread {i}");
});
simpleThread.Name = "Worker Thread";
simpleThread.Start();

for (int i = 0; i < 999; i++)
    Console.WriteLine($"Main Thread {i}");


Console.WriteLine("-------------------------");

Console.WriteLine($"Main Thread Id : {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Worker Thread Id : {simpleThread.ManagedThreadId}");
