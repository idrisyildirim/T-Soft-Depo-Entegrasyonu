using System;
using System.Collections.Generic;

namespace DehasoftEntegrasyon.Class
{

    public class XmlStok
    {
        public long Blkodu { get; set; }
        public int Aktif { get; set; }
        public string Stokkodu { get; set; }
        public string StokAdi { get; set; }
        public string Barkodu { get; set; }
        public string Grubu { get; set; }
        public string AraGrubu { get; set; }
        public string AltGrubu { get; set; }
        public string Aciklama { get; set; }
        public string OzelKodu1 { get; set; }
        public string OzelKodu2 { get; set; }
        public string OzelKodu3 { get; set; }
        public string KdvOrani { get; set; }
        public int DovizKullan { get; set; }
        public int AnaStok { get; set; }
        public string AnaStokkodu { get; set; }
        public string Markasi { get; set; }
        public string Modeli { get; set; }
        public string Renk { get; set; }
        public string Beden { get; set; }
        public List<StokFiyat> Fiyatlar { get; set; }
        public string DepoAdi { get; set; }
        public string MuhAlis { get; set; }
        public string MuhSatisYi { get; set; }
        public string MuhSatisYd { get; set; }
        public string MuhIadeYi { get; set; }
        public string MuhIadeYd { get; set; }
        public string KdvAlis { get; set; }
        public string KdvSatisPrk { get; set; }
        public string StokAdiYd { get; set; }
        public string UrunMaddesi { get; set; }
        public string UrunKalinlik { get; set; }
        public string UrunUzunlugu { get; set; }
        public string UrunTopOlcu { get; set; }
        public string UrunTasRengi { get; set; }
        public string OzelKodu2O { get; set; }
        public string UrunRengi { get; set; }
        public string Birimi { get; internal set; }
        public string ResimYolu { get; set; }
        public string Kaydeden { get; set; }
        public string OzelAlanTanım_10 { get; set; }
        public string OzelAlanTanım_12 { get; set; }
        public string OzelAlanTanım_13 { get; set; }
        public string OzelAlanTanım_14 { get; set; }

        public XmlStok()
        {
            OzelAlanTanım_10 = "";
            OzelAlanTanım_12 = "";
            OzelAlanTanım_13 = "";
            OzelAlanTanım_14 = "";
            Kaydeden = "";
            ResimYolu = "";
            UrunRengi = "";
            OzelKodu2O = "";
            UrunMaddesi = "";
            UrunKalinlik = "";
            UrunUzunlugu = "";
            UrunTopOlcu = "";
            UrunTasRengi = "";
            MuhAlis = "";
            MuhIadeYd = "";
            MuhIadeYi = "";
            MuhSatisYd = "";
            MuhSatisYi = "";
            Stokkodu = "";
            StokAdi = "";
            Barkodu = "";
            Grubu = "";
            AraGrubu = "";
            AltGrubu = "";
            Aciklama = "";
            OzelKodu1 = "";
            OzelKodu2 = "";
            OzelKodu3 = "";
            KdvOrani = "0";
            DovizKullan = 0;
            AnaStok = 0;
            AnaStokkodu = "";
            Markasi = "";
            Modeli = "";
            Renk = "";
            Beden = "";
            Fiyatlar = new List<StokFiyat>();
            DepoAdi = "";
            Aktif = 1;
            KdvAlis = "0";
            KdvSatisPrk = "0";
            StokAdiYd = "";
            Birimi = "ADET";
        }

    }

    public enum FiyatTipi
    {
        Alis = 1,
        Satis = 2

    }

    public class StokFiyat
    {
        public int FiyatNo { get; set; }
        public string Fiyati { get; set; }
        public string Tanimi { get; set; }
        public FiyatTipi FiyatTipi { get; set; }
        public string Hesap { get; set; }
        public StokFiyat()
        {
            FiyatTipi = FiyatTipi.Satis;
            FiyatNo = 1;
            Fiyati = "0";
            Tanimi = "";
            Hesap = "TL";
        }
    }
}
