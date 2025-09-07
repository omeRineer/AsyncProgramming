#region Description

/*
 * IsBackground özelliği true ise worker thread, main threade bağlı olarak çalışır. 
 * Bu yüzden main thread sonlandığında worker thread çalışmasını bitirmesee dahi sonlanır. 
 * 
 * IsBackgorund özelliği false (default) ise workeer thread, main threadden bağımsız çalışır. 
 * Bu durumda main thread çalışmasını bitirse dahi worker thread çalışmasının bitirilmesi beklenir.
 */

#endregion

#region Example 1
Thread simpleThread = new(() =>
{
    for (int i = 0; i < 999; i++)
        Console.WriteLine($"Worker Thread {i}");
});
simpleThread.IsBackground = false;
simpleThread.Start();

for (int i = 0; i < 99; i++)
    Console.WriteLine($"Main Thread {i}");
#endregion



