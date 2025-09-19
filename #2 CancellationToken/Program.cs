
async Task DoWorkAsync(CancellationToken cancellationToken)
{
	for (int i = 0; i < 100; i++)
	{
		cancellationToken.ThrowIfCancellationRequested();
        Console.WriteLine("Working...");

		await Task.Delay(1000);
	}
}

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

DoWorkAsync(cancellationTokenSource.Token);

await Task.Delay(3000);

cancellationTokenSource.Cancel();

Console.ReadLine();


