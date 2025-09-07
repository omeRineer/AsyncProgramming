#region Description

/*
 * Join metodu, threadin sonlanmasını beklemeyi sağlar. Debug ile Join metodu incelenirse ilgili threadin işlemini bitirdikten sonra bir alt satıra ilerlendiği görülebilir.
 * 
 */

#endregion


#region Example 1
//int i = 1;

//Thread thread1 = new(() =>
//{
//    while (i < 10)
//    {
//        i++;
//        Console.WriteLine($"Thread 1 : {i}");
//    }
//});

//Thread thread2 = new(() =>
//{
//    while (i > 0)
//    {
//        i--;
//        Console.WriteLine($"Thread 2 : {i}");
//    }
//});

//thread1.Start();
//thread1.Join();
//thread2.Start();
#endregion

#region Example 2
List<Thread> workerThreads = new List<Thread>();
List<int> results = new List<int>();

for (int i = 0; i < 5; i++)
{
    Thread thread = new Thread(() =>
    {
        Thread.Sleep(new Random().Next(1000, 5000));
        lock (results)
        {
            results.Add(new Random().Next(1, 10));
        }
    });
    workerThreads.Add(thread);
    thread.Start();
}

foreach (Thread thread in workerThreads)
{
    thread.Join();
}

Console.WriteLine("Sum of results: " + results.Sum());
#endregion


