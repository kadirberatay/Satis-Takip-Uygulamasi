using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpUyg
{
    public class Satis
    {
        public int SatisId { get; set; }
        public int SatisAdeti { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }
}
