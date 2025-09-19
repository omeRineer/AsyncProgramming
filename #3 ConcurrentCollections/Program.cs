using System.Collections.Concurrent;


#region BlockingCollection


BlockingCollection<int> collection = new();

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        collection.Add(i);
        Console.WriteLine($"Producer has added a number : {i}");

        await Task.Delay(1000);
    }

    collection.CompleteAdding();
});

Task consumer = Task.Run(() =>
{
    while (true)
    {
        var result = collection.Take();
        Console.WriteLine($"Producer has consumed a number : {result}");

    }
});

await Task.WhenAll(producer, consumer);

#endregion
#region ConcurrencyBag

#endregion
#region ConcurrencyQueue

#endregion
#region ConcurrencyStack

#endregion
#region ConcurrencyDictionary

#endregion