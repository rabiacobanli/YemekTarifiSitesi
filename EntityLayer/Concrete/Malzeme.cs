using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Malzeme
    {
        public int MalzemeID { get; set; }
        public string MalzemeAdi { get; set; }
        public double MalzemeMiktar { get; set; }
        public string MiktarKategori { get; set; }


    }
}
