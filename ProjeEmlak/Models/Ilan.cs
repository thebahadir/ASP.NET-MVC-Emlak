using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class Ilan
    {
        public int IlanId { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public string OdaSayisi { get; set; }
        public int BanyoSayisi { get; set; }
        public bool Kredi { get; set; }
        public int Alan { get; set; }
        public string Kat { get; set; }
        public string Isitma { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string KullaniciAdi { get; set; }
        public int SehirId { get; set; }
        public int SemtId { get; set; }
        public int DurumId { get; set; }
        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }
        public int EmlakId { get; set; }
        public Emlak Emlak { get; set; }
        public List<Resim> Resimler { get; set; }



    }
}