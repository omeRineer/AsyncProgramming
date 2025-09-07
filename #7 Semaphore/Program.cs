#region Description

#endregion


#region Semaphore

Semaphore semaphore = new Semaphore(2, 2);
int i = 0;

Thread thread1 = new(() =>
{
    semaphore.WaitOne();
    try
    {
        while (0 <= i && i < 10)
        {
            i++;
            Console.WriteLine($"Thread 1 : {i}");
        }
    }
    finally
    {
        semaphore.Release();
    }
});

Thread thread2 = new(() =>
{
    semaphore.WaitOne();
    try
    {
        while (10 <= i && i < 20)
        {
            i++;
            Console.WriteLine($"Thread 2 : {i}");
        }
    }
    finally
    {
        semaphore.Release();
    }
});

Thread thread3 = new(() =>
{
    semaphore.WaitOne();
    try
    {
        while (20 <= i && i < 30)
        {
            i++;
            Console.WriteLine($"Thread 3 : {i}");
        }
    }
    finally
    {
        semaphore.Release();
    }
});

thread1.Start();
thread2.Start();
thread3.Start();

#endregion