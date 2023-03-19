using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpUyg
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public int UrunStok { get; set; }
        public decimal UrunFiyat { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public List<Satis> Satis { get; set; }
    }
}
