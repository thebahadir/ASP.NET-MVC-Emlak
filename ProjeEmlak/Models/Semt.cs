using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class Semt
    {
        public int SemtId { get; set; }
        public string SemtAd { get; set; }
        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }
        public List<Mahalle> Mahalleler { get; set; }
    }
}