/*
 * Locking mekanizması sayesinde threadler arasındaki Race Conditions problemlerin önüne geçilebilir.
 * Sistem çalışma anında ilk hangi thread çalıştıysa bir referans tipli değişkeni lock eder. Bu sayede diğer lock kullanılan threadler bu kilidin açılmasını bekler.
 * Çalışan thread lock bloğu içerisinden çıktığında kilit açılmış olur. Ve lockdan dolayı bloklanmış thread çalışmasına devam eder.
 */

object _locking = new();
int i = 1;

Thread thread1 = new(() =>
{
    lock (_locking)
    {
        while (i < 10)
        {
            i++;
            Console.WriteLine($"Thread 1 : {i}");
        }
    }
});

Thread thread2 = new(() =>
{
    lock (_locking)
    {
        while (i > 0)
        {
            i--;
            Console.WriteLine($"Thread 2 : {i}");
        }
    }
});

thread1.Start();
thread2.Start();
