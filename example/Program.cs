using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class BaseMakine
{
    public DateTime UretimTarihi { get; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    // Constructor - Üretim tarihi nesne oluşturulduğunda atanır.
    public BaseMakine()
    {
        UretimTarihi = DateTime.Now;
    }

    // BilgileriYazdir metodu - Taban sınıfta
    public virtual void BilgileriYazdir()
    {
        Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
        Console.WriteLine($"Seri Numarası: {SeriNumarasi}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Açıklama: {Aciklama}");
        Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
    }

    // Soyut metod
    public abstract void UrunAdiGetir();
}

// Telefon sınıfı
class Telefon : BaseMakine
{
    public bool TrLisansliMi { get; set; }

    // BilgileriYazdir metodunu ezerek genişletiyoruz
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"TR Lisanslı mı?: {(TrLisansliMi ? "Evet" : "Hayır")}");
    }

    // UrunAdiGetir metodunu ezerek telefon adını yazdırıyoruz
    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Telefonunuzun adı ---> {Ad}");
    }
}

// Bilgisayar sınıfı
class Bilgisayar : BaseMakine
{
    private int _usbGirisSayisi;

    public int UsbGirisSayisi
    {
        get { return _usbGirisSayisi; }
        set
        {
            if (value == 2 || value == 4)
                _usbGirisSayisi = value;
            else
            {
                Console.WriteLine("Usb Giriş Sayısı 2 veya 4 olabilir! Varsayılan olarak -1 atanıyor.");
                _usbGirisSayisi = -1;
            }
        }
    }

    public bool BluetoothVarMi { get; set; }

    // BilgileriYazdir metodunu ezerek genişletiyoruz
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}");
        Console.WriteLine($"Bluetooth Var mı?: {(BluetoothVarMi ? "Evet" : "Hayır")}");
    }

    // UrunAdiGetir metodunu ezerek bilgisayar adını yazdırıyoruz
    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Bilgisayarınızın adı ---> {Ad}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("Telefon üretmek için 1, Bilgisayar üretmek için 2'ye basınız:");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                // Telefon oluşturma
                Telefon telefon = new Telefon();

                Console.Write("Seri Numarası: ");
                telefon.SeriNumarasi = Console.ReadLine();

                Console.Write("Ad: ");
                telefon.Ad = Console.ReadLine();

                Console.Write("Açıklama: ");
                telefon.Aciklama = Console.ReadLine();

                Console.Write("İşletim Sistemi: ");
                telefon.IsletimSistemi = Console.ReadLine();

                Console.Write("TR Lisanslı mı? (E/H): ");
                telefon.TrLisansliMi = Console.ReadLine().ToLower() == "e";

                Console.WriteLine("\nTelefon başarıyla üretildi!");
                telefon.UrunAdiGetir();
                telefon.BilgileriYazdir();
            }
            else if (secim == "2")
            {
                // Bilgisayar oluşturma
                Bilgisayar bilgisayar = new Bilgisayar();

                Console.Write("Seri Numarası: ");
                bilgisayar.SeriNumarasi = Console.ReadLine();

                Console.Write("Ad: ");
                bilgisayar.Ad = Console.ReadLine();

                Console.Write("Açıklama: ");
                bilgisayar.Aciklama = Console.ReadLine();

                Console.Write("İşletim Sistemi: ");
                bilgisayar.IsletimSistemi = Console.ReadLine();

                Console.Write("USB Giriş Sayısı: ");
                bilgisayar.UsbGirisSayisi = int.Parse(Console.ReadLine());

                Console.Write("Bluetooth var mı? (E/H): ");
                bilgisayar.BluetoothVarMi = Console.ReadLine().ToLower() == "e";

                Console.WriteLine("\nBilgisayar başarıyla üretildi!");
                bilgisayar.UrunAdiGetir();
                bilgisayar.BilgileriYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz bir seçim yaptınız.");
                continue;
            }

            // Kullanıcıya başka bir ürün üretmek isteyip istemediğini soruyoruz
            Console.Write("Başka bir ürün üretmek istiyor musunuz? (E/H): ");
            string devamCevap = Console.ReadLine().ToLower();
            devamEt = devamCevap == "e";
        }

        Console.WriteLine("İyi günler dileriz.");
    }
}
