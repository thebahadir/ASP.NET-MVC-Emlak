using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class Emlak
    {
        public int EmlakId { get; set; }
        public string EmlakAd { get; set; }
        public int DurumId { get; set; }
        public virtual Durum Durum { get; set; }
    }
}