using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DehasoftEntegrasyon.Class
{
   public class XmlConfiguration
    {
        public XmlConfiguration()
        {
            AkinsoftIp = ConfigurationManager.AppSettings["akinsoftIp"];
            AkinsoftUpdatePort = ConfigurationManager.AppSettings["akinsoftUpdatePort"]; ;
            AkinsoftCalismaYili = ConfigurationManager.AppSettings["akinsoftCalismaYili"]; ;
            AkinsoftSirketKodu = ConfigurationManager.AppSettings["akinsoftSirketKodu"]; ;
            AkinsoftKullanici = ConfigurationManager.AppSettings["akinsoftKullanici"]; ;
            AkinsoftSifre = ConfigurationManager.AppSettings["akinsoftSifre"]; ;
            PersUser = "";
            DbFileName = ConfigurationManager.AppSettings["dbFileName"]; ;
            dbSetType = "1";
            userName = ConfigurationManager.AppSettings["akinsoftKullanici"]; ;
            password = ConfigurationManager.AppSettings["akinsoftSifre"]; ;
            lcType = "";
            dbIsUniCode = "0";
            collate = "Turkish_CI_AI";
            osauthent = "0";
            prgLisans = "0";
            lisansliModuller = "";
            subeKodu = "";
            serverOmYuklu = "-1";
            serverByYuklu = "0";
            serverDmYuklu = "0";
            serverGmYuklu = "0";
            serverIkYuklu = "0";
            serverImYuklu = "0";
            SdkKullaniciAdi = "200507297";
            SdkSifre = "53E9D";
        }
        public string SdkSifre { get; set; }
        public string AkinsoftKullanici { get; set; }
        public string AkinsoftSifre { get; set; }
        public string AkinsoftIp { get; set; }
        public string AkinsoftUpdatePort { get; set; }
        public string AkinsoftCalismaYili { get; set; }
        public string AkinsoftSirketKodu { get; set; }
        public string SdkKullaniciAdi { get; set; }
        public string PersUser { get; set; }
        public string DbFileName { get; set; }
        public string dbSetType { get; set; }
        public string dbIsUniCode { get; set; }
        public string collate { get; set; }
        public string osauthent { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string lcType { get; set; }
        public string prgLisans { get; set; }
        public string lisansliModuller { get; set; }
        public string subeKodu { get; set; }
        public string serverOmYuklu { get; set; }
        public string serverGmYuklu { get; set; }
        public string serverByYuklu { get; set; }
        public string serverImYuklu { get; set; }
        public string serverDmYuklu { get; set; }
        public string serverIkYuklu { get; set; }
    }
}
