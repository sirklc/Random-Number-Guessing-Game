using System;

namespace RandomTahminOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Rastgele Sayı Tahmin Oyunu ===");
            Console.WriteLine("Oyundan çıkmak için 'q' yazabilirsiniz.\n");

            while (true) // Oyunun tamamı bu döngüde yer alır
            {
                // Zorluk seviyesi seçimi
                int minSayi = 1, maxSayi = 100; // Varsayılan aralık
                Console.WriteLine("Zorluk seviyesini seçin:");
                Console.WriteLine("1. Kolay (1-50)");
                Console.WriteLine("2. Orta (1-100)");
                Console.WriteLine("3. Zor (1-500)");
                Console.Write("Seçiminizi yapın (1/2/3): ");
                string zorlukSecimi = Console.ReadLine();

                switch (zorlukSecimi)
                {
                    case "1":
                        maxSayi = 50;
                        break;
                    case "2":
                        maxSayi = 100;
                        break;
                    case "3":
                        maxSayi = 500;
                        break;
                    case "q":
                        Console.WriteLine("Oyundan çıkılıyor. Tekrar görüşmek üzere!");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Varsayılan seviye (Orta) ayarlandı.");
                        break;
                }

                Random random = new Random();
                int rastgeleSayi = random.Next(minSayi, maxSayi + 1); // Seçilen aralıkta sayı oluştur
                int tahmin = 0; // Kullanıcının tahmini
                int denemeSayisi = 0; // Deneme sayısı

                Console.WriteLine($"\n{minSayi} ile {maxSayi} arasında bir sayı tuttum. Tahmin etmeye başlayın!");

                while (true) // Doğru tahmine kadar sürecek döngü
                {
                    Console.Write("Tahmininizi girin: ");
                    string kullaniciGirdisi = Console.ReadLine();

                    // Çıkış kontrolü
                    if (kullaniciGirdisi.ToLower() == "q")
                    {
                        Console.WriteLine("Oyundan çıkılıyor. Tekrar görüşmek üzere!");
                        return; // Programı tamamen sonlandırır
                    }

                    // Geçerli giriş kontrolü
                    if (int.TryParse(kullaniciGirdisi, out tahmin))
                    {
                        denemeSayisi++; // Deneme sayısını artır

                        if (tahmin < rastgeleSayi)
                        {
                            Console.WriteLine("Daha büyük bir sayı tahmin edin.");
                        }
                        else if (tahmin > rastgeleSayi)
                        {
                            Console.WriteLine("Daha küçük bir sayı tahmin edin.");
                        }
                        else
                        {
                            Console.WriteLine($"\nTebrikler! {denemeSayisi} denemede doğru tahmin ettiniz.");
                            break; // İç döngüden çık
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir sayı girin.");
                    }
                }

                // Oyunu tekrar başlatma veya çıkış seçeneği
                Console.WriteLine("\nOyunu tekrar oynamak için 'r' tuşuna basın veya çıkmak için 'q' yazın.");
                string secim = Console.ReadLine().ToLower();

                if (secim == "q")
                {
                    Console.WriteLine("Oyundan çıkılıyor. Tekrar görüşmek üzere!");
                    break; // Dış döngüden çık ve programı sonlandır
                }
                else if (secim != "r")
                {
                    Console.WriteLine("Geçersiz seçim. Oyundan çıkılıyor.");
                    break;
                }
            }

            Console.WriteLine("\nOyundan çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
