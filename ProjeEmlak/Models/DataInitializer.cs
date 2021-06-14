using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjeEmlak.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehir = new List<Sehir>()
            {
                new Sehir(){SehirAd="İSTANBUL"},
                new Sehir(){SehirAd="ANKARA"},
                new Sehir(){SehirAd="İZMİR"}
            };
            foreach (var item in sehir)
            {
                context.Sehirs.Add(item);
            }
            context.SaveChanges();

            var semt = new List<Semt>
            {
                new Semt(){SemtAd="KADIKÖY", SehirId=1},
                new Semt(){SemtAd="ÇANKAYA", SehirId=2},
                new Semt(){SemtAd="KARŞIYAKA", SehirId=3}
            };
            foreach (var item in semt)
            {
                context.Semts.Add(item);
            }
            context.SaveChanges();

            var mahalle = new List<Mahalle>
            {
                new Mahalle(){MahalleAd="GÖZTEPE", SemtId=1},
                new Mahalle(){MahalleAd="KIZILAY", SemtId=2},
                new Mahalle(){MahalleAd="BAHARİYE", SemtId=3},
            };
            foreach (var item in mahalle)
            {
                context.Mahalles.Add(item);
            }
            context.SaveChanges();

            var durum = new List<Durum>
            {
               new Durum(){DurumAd="SATILIK"},
               new Durum(){DurumAd="KİRALIK"}
            };
            foreach (var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();

            var emlak = new List<Emlak>
            {
                new Emlak(){EmlakAd="Ev", DurumId=1},
                new Emlak(){EmlakAd="Dükkan", DurumId=1},
                new Emlak(){EmlakAd="Arsa", DurumId=1},
                new Emlak(){EmlakAd="Ev", DurumId=2},
                new Emlak(){EmlakAd="Dükkan", DurumId=2},
                new Emlak(){EmlakAd="Arsa", DurumId=2}
            };
            foreach (var item in emlak)
            {
                context.Emlaks.Add(item);
            }
            context.SaveChanges();

            var ilan = new List<Ilan>
            {
                new Ilan(){EmlakId=1, DurumId=2, SehirId=1, SemtId=1, MahalleId=1, Adres="Bahtlı sokak", Fiyat=3100, Alan=110, Kredi=true, Kat="5. Kat", OdaSayisi="3+1", BanyoSayisi=2, Isitma="Kombi", Telefon="0530 999 45 34", Aciklama="Asdfghdfd", KullaniciAdi="Ahmet"},
                new Ilan(){EmlakId=4, DurumId=2, SehirId=2, SemtId=2, MahalleId=2, Adres="Küme sokak", Fiyat=2250, Alan=90, Kredi=true, Kat="2. Kat", OdaSayisi="2+1", BanyoSayisi=1, Isitma="Merkezi", Telefon="0542 334 56 45", Aciklama="Asdf gfgdfgfHdg sfdgfg", KullaniciAdi="Mehmet"}
            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();

            var resim = new List<Resim>
            {
                new Resim(){ResimAd="img_1.jpg", IlanId=1},
                new Resim(){ResimAd="img_5.jpg", IlanId=1},
                new Resim(){ResimAd="img_7.jpg", IlanId=2}
            };
            foreach (var item in resim)
            {
                context.Resims.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}