using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpUyg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new Context();
            var kategori = new Kategori();
            var urun = new Urun();
            var satis = new Satis();
        X:
            Console.Clear();
            Console.WriteLine("Satış Takip Programı");
            Console.WriteLine("--------------------");
            Console.WriteLine("Anamenu");
            Console.WriteLine("--------------------");
            Console.WriteLine("Kategori Listele [1]");
            Console.WriteLine("Kategori Ekle [2]");
            Console.WriteLine("Kategori Güncelle [3]");
            Console.WriteLine("Kategori Sil [4]");
            Console.WriteLine("Ürün Listele [5]");
            Console.WriteLine("Ürün Ekle [6]");
            Console.WriteLine("Ürün Güncelle [7]");
            Console.WriteLine("Ürün Sil [8]");
            Console.WriteLine("Satış Listele [9]");
            Console.WriteLine("Satış Ekle [10]");
            Console.WriteLine("Çıkış [0]");
            Console.Write("Seçiminizi Belirtiniz: ");
            int Secim = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            switch (Secim)
            {
                case 1:
                    foreach (var item in _context.kategoris)
                    {
                        Console.WriteLine(item.KategoriId + ")" + item.KategoriAdi);
                    }
                    Console.ReadKey();
                    goto X;
                case 2:
                    Console.WriteLine("Kategori Adını Giriniz:");
                    kategori.KategoriAdi = Console.ReadLine();
                    _context.kategoris.Add(kategori);
                    _context.SaveChanges();
                    goto X;
                case 3:
                    Console.WriteLine("Kategori İd giriniz:");
                    kategori.KategoriId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Kategori Adını Giriniz:");
                    kategori.KategoriAdi = Console.ReadLine();
                    _context.kategoris.AddOrUpdate(kategori);
                    _context.SaveChanges();
                    goto X;
                case 4:
                    Console.WriteLine("Kategori İd giriniz:");
                    int b = Convert.ToInt32(Console.ReadLine());
                    var sil = _context.kategoris.Find(b);
                    _context.kategoris.Remove(sil);
                    _context.SaveChanges();
                    goto X;
                case 5:
                    foreach (var item in _context.uruns)
                    {
                        Console.WriteLine(item.UrunId + ")" +
                       item.UrunAd + "Stok:" + item.UrunStok + "Ürün Fiyatı:" + item.UrunFiyat
                        + "Kategori İd:" + item.KategoriId);
                    }
                    Console.ReadKey();
                    goto X;
                case 6:
                    Console.WriteLine("Urun Adını Giriniz:");
                    urun.UrunAd = Console.ReadLine();
                    Console.WriteLine("Urun Stok Giriniz:");
                    urun.UrunStok = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Urun Fiyatı Giriniz:");
                    urun.UrunFiyat = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Kategori id Giriniz:");
                    urun.KategoriId = Convert.ToInt32(Console.ReadLine());
                    _context.uruns.Add(urun);
                    _context.SaveChanges();
                    goto X;
                case 7:
                    Console.WriteLine("Ürün İd giriniz:");
                    urun.UrunId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Urun Adını Giriniz:");
                    urun.UrunAd = Console.ReadLine();
                    Console.WriteLine("Urun Stok Giriniz:");
                    urun.UrunStok = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Urun Adını Giriniz:");
                    urun.UrunFiyat = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Kategori id Giriniz:");
                    urun.KategoriId = Convert.ToInt32(Console.ReadLine());
                    _context.uruns.AddOrUpdate(urun);
                    _context.SaveChanges();
                    goto X;
                case 8:
                    Console.WriteLine("Ürün İd giriniz:");
                    int a = Convert.ToInt32(Console.ReadLine());
                    var silu = _context.uruns.Find(a);
                    _context.uruns.Remove(silu);
                    _context.SaveChanges();
                    goto X;
                case 9:
                    foreach (var item in _context.Satis)
                    {
                        Console.WriteLine(item.SatisId + ")" + "Satış Adeti:" +
                       item.SatisAdeti + "Toplam Fiyat:" + item.ToplamFiyat);
                    }
                    Console.ReadKey();
                    goto X;
                case 10:
                    Console.WriteLine("Ürün İd giriniz:");
                    satis.UrunId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Satis Adetini Giriniz:");
                    satis.SatisAdeti = Convert.ToInt32(Console.ReadLine());
                    var urunb = _context.uruns.Find(satis.UrunId);
                    satis.ToplamFiyat = satis.SatisAdeti * urunb.UrunFiyat;
                    urunb.UrunStok = urunb.UrunStok - satis.SatisAdeti;
                    _context.Satis.Add(satis);
                    _context.SaveChanges();
                    goto X;
                case 0:
                    break;
                default:
                    goto X;
            }
        }
    }
}
