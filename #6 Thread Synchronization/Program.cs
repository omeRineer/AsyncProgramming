#region Description

#endregion


#region Spinner Synchronization
//bool condition1 = true;
//bool condition2 = false;
//int i = 0;

//Thread thread1 = new(() =>
//{
//    while (true)
//    {
//        if (condition1)
//        {
//            for (int j = 0; j < 10; j++)
//                Console.WriteLine($"Thread 1 Process : {i++}");

//            condition1 = false;
//            condition2 = true;
//        }
//    }
//});

//Thread thread2 = new(() =>
//{
//    while (true)
//    {
//        if (condition2)
//        {
//            for (int j = 0; j <= 10; j++)
//                Console.WriteLine($"Thread 2 Process : {i--}");

//            condition2 = false;
//        }
//    }
//});

//thread1.Start();
//thread2.Start();
#endregion

#region Monitor.Enter ve Monitor.Exit
///* 
// * Monitor.Enter ve Monitor.Exit fonksiyonlarıda lock bloğunun çalıştığı şekilde çalışır. 
// * Monitor.Enter ile değişken lock edilir. Bu durumda diğer threadler bloklanır. 
// * Monitor.Exit ile lock kilidi çözülerek bloklanan sıradaki thread çalışmasına başlar.
// * Bu yapılar bellek ve performansı etkilediği için threadin tüm çalışma süreci içerisinde kullanmasından ziyade daha çok kritik bölgeler için kullanılması tavsiye edilir. Ve kısa süreli senkronizasyon süreçleri için kullanılması önerilir. 
// * 
// * Bazı nadir durumlarda Monitor.Enter fonksiyonunun lock işlemi gecikmeli veya başarısız olabilir. Bu durumlara karşı önlem alabilmek için lockTaken parametresi kullanılır.
// */

//object _locking = new();
//int i = 1;

//Thread thread1 = new(() =>
//{
//    Monitor.Enter(_locking);

//    /* Thredin içerisinde bir exception alınması durumunda lock'un kaldırılması için tr-xatch-finally bloğu kullanabiliriz.
//     * lock scope kullanırken bu süreci kendisi ilerletirken, Monitor.Enter Exit kullanıldığında kendimiz manuel olarak yönetmemiz gerekir.
//     * Eğer bu işlemler manuel yapılmaz ise thread kilitli kalacak ve diğer du locka bağlı threadler bloklanacaktır
//     */
//    try
//    {
//        while (i < 10)
//        {
//            i++;
//            Console.WriteLine($"Thread 1 : {i}");
//        }
//    }
//    finally
//    {
//        Monitor.Exit(_locking);
//    }
//});

//Thread thread2 = new(() =>
//{
//    Monitor.Enter(_locking);

//    try
//    {
//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine($"Thread 2 : {i}");
//        }
//    }
//    finally
//    {
//        Monitor.Exit(_locking);
//    }
//});

//thread1.Start();
//thread2.Start();

#endregion

#region Monitor.TryEnter
///*
// * Monitor.TryEnter sayesinde ise lock objesinin ms cinsinden ne kadar sürede kilitlemesi gerektiğini verebilir, 
// * eğer bu süre içerisinde kilitlerse true kilitleyemezse false döndürecektir.
// * 
// * Öncelik riskini belirlemede kullanışlıdır
// */

//object _locking = new();
//int i = 0;

//Thread thread1 = new(() =>
//{
//    var isLock = Monitor.TryEnter(_locking, 1000);

//    if (isLock)
//        try
//        {
//            while (i < 10)
//            {
//                i++;
//                Console.WriteLine($"Thread 1 : {i}");
//            }
//        }
//        finally
//        {
//            Monitor.Exit(_locking);
//        }
//});

//Thread thread2 = new(() =>
//{
//    var isLock = Monitor.TryEnter(_locking, 2000);

//    if (isLock)
//        try
//        {
//            while (i > 0)
//            {
//                i--;
//                Console.WriteLine($"Thread 2 : {i}");
//            }
//        }
//        finally
//        {
//            Monitor.Exit(_locking);
//        }
//});

//thread1.Start();
//thread2.Start();

#endregion

#region Mutex (Uygulama seviyesinde kullanım)
///*
// * Mutex yapısıda diğer locking yapıları gibi aynı amaca hizmet eder. 
// */

//Mutex _mutex = new();
//int i = 0;

//Thread thread1 = new(() =>
//{
//    _mutex.WaitOne();

//    try
//    {
//        while (i < 10)
//        {
//            i++;
//            Console.WriteLine($"Thread 1 : {i}");
//        }
//    }
//    finally
//    {
//        _mutex.ReleaseMutex();
//    }
//});

//Thread thread2 = new(() =>
//{
//    _mutex.WaitOne();

//    try
//    {
//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine($"Thread 2 : {i}");
//        }
//    }
//    finally
//    {
//        _mutex.ReleaseMutex();
//    }
//});

//thread1.Start();
//thread2.Start();
#endregion

#region Mutex (Process seviyesinde kullanım)
/*
 * Mutex yapısıda diğer locking yapıları gibi aynı amaca hizmet eder. Fakat bu yapılardan farklı olarak diğerleri Thread seviyesinde
 * locking işlemi yaparken Mutex process seviyesinde locking işlemi gerçekleştirir. Buna örnek verecek olursak
 * 
 * Normal durumda bir uygulamadan birden fazla Instance oluşturulabilir. Fakat bir uygulamadan sadece tek bir instance oluşturmak istiyorsak (Single Instance App)
 * process seviyesinde locking yapmamız gerekir.
 */

Mutex _mutex;
string mutexName = "App Instance";
var isAvaibleMutex = Mutex.TryOpenExisting(mutexName, out _mutex);

if (isAvaibleMutex)
{
    _mutex.Close();
    Console.WriteLine("Aynı isimde bir mutex mevcut. Bu mutex kapatılabilir.");
}
else
{
    _mutex = new Mutex(true, mutexName);
    Console.WriteLine($"{mutexName} isminde Mutex çalışıyor");
}
Console.Read();

/*
   ? : Eğer zaten çalışan başka bir örnek varsa ve ben TryOpenExisting ile o mutex’i açtıysam, sonra Close() çağırmam, o çalışan uygulamanın mutex’ini kapatmaz mı?”

       Cevap: Hayır, kapatmaz.


       TryOpenExisting mevcut (başka bir process tarafından oluşturulmuş) mutex’e sadece bir referans almanı sağlar.
        
       Yani:

       O mutex hâlâ başka bir process (örneğin: çalışan başka bir uygulama örneği) tarafından tutuluyordur.
       Senin Close() yapman, sadece senin aldığın referansı serbest bırakır.
       Diğer uygulama hala mutex’e sahip olmaya devam eder.
 */
#endregion
