Thread simpleThread = new(() =>
{
    for (int i = 0; i < 999; i++)
        Console.WriteLine($"Worker Thread {i}");
});
simpleThread.IsBackground = true;
simpleThread.Start();

Console.WriteLine(simpleThread.ThreadState);