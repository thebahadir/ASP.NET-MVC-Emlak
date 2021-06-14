using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class Durum
    {
        public int DurumId { get; set; }
        public string DurumAd { get; set; }
        public List<Emlak> Emlaklar { get; set; }
    }
}