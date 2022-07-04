using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class YemekKategori
    {
        public int ID { get; set; }

        public int YemekID { get; set; }

        public int KategoriID { get; set; }

        public Yemek Yemek { get; set; }

        public Kategori Kategori { get; set; }
    }
}
