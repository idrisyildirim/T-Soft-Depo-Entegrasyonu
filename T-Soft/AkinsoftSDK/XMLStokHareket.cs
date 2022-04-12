using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DehasoftEntegrasyon.Akinsoft
{
    public class XMLStokHareket
    {
        public XMLStokHareket()
        {
            Kpb_Tutari = 0;
            Kpb_Gmik = 0;
            Tarihi = DateTime.Now.ToShortDateString();
            Miktari = 0;
        }
        public long Blstkodu { get; set; }
        public float Kpb_Tutari { get; set; }
        public float Kpb_Gmik { get; set; }
        public float Miktari { get; set; }
        public string Ozel_kodu { get; set; }
        public string Tarihi { get; set; }
        public short Tutar_Turu { get; set; }
        public string DepoAdi { get; set; }
    }

}
