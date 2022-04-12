using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DehasoftEntegrasyon.Class
{
  public  class XmlKapaliFaturaNakit
    {
        public Int16 IslemTuru { get; set; }
        public string KasaAdi { get; set; }
        public double KpbDvz { get; set; }
        public double KpbAtut { get; set; }
        public XmlKapaliFaturaNakit()
        {
            IslemTuru = 0;
            KasaAdi = "";
            KpbDvz = 0;
            KpbAtut = 0;
        }

    }
}
