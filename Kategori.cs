using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpUyg
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public List<Urun> uruns { get; set; }
    }
}

