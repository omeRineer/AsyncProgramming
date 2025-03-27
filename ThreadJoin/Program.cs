int i = 1;

Thread thread1 = new(() =>
{
    while (i < 10)
    {
        i++;
        Console.WriteLine($"Thread 1 : {i}");
    }
});

Thread thread2 = new(() =>
{
    while (i > 0)
    {
        i--;
        Console.WriteLine($"Thread 2 : {i}");
    }
});

thread1.Start();
thread1.Join();
thread2.Start();