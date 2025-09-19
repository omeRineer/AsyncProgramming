
#region Create an instance
#region new Task
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"New Task : {i}");
//});
//task.Start();
#endregion

#region Task.Run
//Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task.Run : {i}");
//});
#endregion

#region Task.Factory.StartNew
//Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task.Factory.StartNew : {i}");
//});
#endregion
#endregion

#region Methods
#region Delay
//await Task.Delay(1000);
#endregion

#region WaitAll
/*
  WaitAll blocks the current thread until all tasks complete. Then the current thread continues working. It doesn't return anythings.
*/

//var task1 = Task.Run(() =>
//{
//    Thread.Sleep(10000);
//});
//var task2 = Task.Run(() =>
//{
//    Thread.Sleep(5000);
//});
//var task3 = Task.Run(() =>
//{
//    Thread.Sleep(3000);
//});

//Task.WaitAll(task1, task2, task3);

//Console.WriteLine("Tasks woke up :)");
#endregion

#region WaitAny
/*
  WaitAny blocks the current thread until one of the tasks completes. It doesn't wait for the others. Then the current thread continues working.
*/

var task1 = Task.Run(() =>
{
    Thread.Sleep(10000);
});
var task2 = Task.Run(() =>
{
    Thread.Sleep(5000);
});
var task3 = Task.Run(() =>
{
    Thread.Sleep(3000);
});

Task.WaitAny(task1, task2, task3);

Console.WriteLine("One of the tasks woke up :)");
#endregion

#region WhenAll
/*
 WhenAll waits for all of the tasks to complete. But it doesn't block current thread. It works asynchronously. It returns a task object.
*/

//var task1 = Task.Run(() =>
//{
//    Thread.Sleep(10000);
//});
//var task2 = Task.Run(() =>
//{
//    Thread.Sleep(5000);
//});
//var task3 = Task.Run(() =>
//{
//    Thread.Sleep(3000);
//});

//await Task.WhenAll(task1, task2, task3);

//Console.WriteLine("Task woke up :)");
#endregion

#region WhenAny
/*
  WhenAny waits for one of the tasks to complete. It doesn't wait for the others. Then the current thread continues working. It works asynchronously. It returns a task object.
*/

//var task1 = Task.Run(() =>
//{
//    Thread.Sleep(10000);
//});
//var task2 = Task.Run(() =>
//{
//    Thread.Sleep(5000);
//});
//var task3 = Task.Run(() =>
//{
//    Thread.Sleep(3000);
//});

//await Task.WhenAny(task1, task2, task3);

//Console.WriteLine("One of the tasks woke up :)");
#endregion
#endregion

Console.ReadLine();