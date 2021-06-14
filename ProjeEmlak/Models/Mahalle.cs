using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class Mahalle
    {
        public int MahalleId { get; set; }
        public string MahalleAd { get; set; }
        public int SemtId { get; set; }
        public string PK { get; set; }
        public virtual Semt Semt { get; set; }

    }
}