using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class YemekTarifModel
    {
        public IEnumerable<Yemek> Yemek { get; set; }
        public IEnumerable<Malzeme> Malzeme { get; set; }
        public IEnumerable<YemekMalzeme> YemekMalzeme { get; set; }
        public IEnumerable<YemekKategori> YemekKategori { get; set; }

    }
}
