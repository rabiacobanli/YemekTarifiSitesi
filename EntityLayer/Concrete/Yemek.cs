using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yemek
    {
        public int YemekID { get; set; }
        public string YemekAdi { get; set; }
        public string? Malzemeler { get; set; }
        public string Tarif { get; set; }
        public string Fotograf { get; set; }
    }
}
