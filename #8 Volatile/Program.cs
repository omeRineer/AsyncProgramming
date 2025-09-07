
#region Description

/*
 * Normal şartlarda uygulamalarda değişken oluşturulduğunda mikroişlemci bu değişken ve değerini hem belleğe hem de derleyicinn kontrolü sayesinde belleğin DATA REGISTER alanına yazmaktadır.
 * Değişkenlerin değeri okunurken bu değer DATA REGISTER'dan okunarak, bellekten okumaya göre katbekat performans sağlamaktadır. 
 * Fakat asenkron ve multithread işlemlerinn yapıldığı senaryolarda birden fazla thread aynı değişkene erişmek istediğinde beklenen değer ile güncel değer arasında tutarsızlıklar meydana gelebilir.
 *      
 *      Yani;
 *          İki farklı thread aynı değişkene erişiyor. Bir thread değişkenin değerini değiştirdiğinde diğer threade okunan bu değer güncel değer olmayabilir. 
 *          Bunun sebebi değerin data register'den okunmasıdır. Mikroişlemci o anki çalışma durumundan dolayı değeri data registerde güncellesi gecikebilir. Değişken değeri bellekte güncellendikten bir süre sonra (mikro sürede) data registerde güncellemektedir. Fakat bu işlemler mikro zamanda yapıldığından farketmemiz çok zordur.
 *          
 *          İşte bu gibi durumlarda değer tutarsızlıklarının önüne geçmek için volatile keywordünü kullanırız. Fakat bunun avantaları olduğu gibi dezavantajlarıda vardır.
 *          
 * Volatile keywordü ile işaretlenen bir değişken, data registerden değil en güncel konumu olan bellekten okunur. Bu durumda mikroişlemci, değeri performanslı çalıştığı data registerdan değil, bellekten okuyacaktır. Veri tutarsızlığının garantisi vardır fakat daha az performansta çalışır.
 * 
 * Volatile, performansın önemsenmediği asenkron işlemlerde, değişkenin çok fazla threadde kullanılmadığı-güncellenmediği yerlerde kullanılması önerilir.
 * 
 */

#endregion


#region Volatile Keyword

//internal class Program
//{
//    volatile static int i = 0;
//    private static void Main(string[] args)
//    {
//        Thread thread1 = new Thread(() =>
//        {
//            while (true) { i++; }
//        });

//        Thread thread2 = new Thread(() =>
//        {
//            while (true) { i--; }
//        });

//        Thread thread3 = new Thread(() =>
//        {
//            while (true) { Console.WriteLine(i); }
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }

//}

#endregion

#region Volatile Class

/*
 * Bazı senaryolarda ihtiyaca göre sadece belli bir yerde volatile davranışına ihtiyaç duyabiliriz.
 * Örneğin değişkeni farklı bir yerde data register'den okumak isteyebiliriz. Bu yüzden değişkeni işaretlemeden sadece istediğimiz yerlerde bellekten okuyabiliriz.
 */

internal class Program
{
    static int i = 0;
    private static void Main(string[] args)
    {
        Thread thread1 = new Thread(() =>
        {
            while (true)
                Volatile.Write(ref i, Volatile.Read(ref i) + 1);
        });

        Thread thread2 = new Thread(() =>
        {
            while (true)
                Volatile.Write(ref i, Volatile.Read(ref i) - 1);
        });

        Thread thread3 = new Thread(() =>
        {
            while (true)
                Console.WriteLine(Volatile.Read(ref i));
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }

}

#endregion