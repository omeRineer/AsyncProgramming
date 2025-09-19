var numbers = Enumerable.Range(0, 100);

Parallel.For(0, numbers.Count(), number =>
{
    Thread.Sleep(3000);
    Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} - Core : {Thread.GetCurrentProcessorId()}");
});

Console.Read();
