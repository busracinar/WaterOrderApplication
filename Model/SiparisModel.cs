using SuSatisOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.Model
{
    class SiparisModel
    {
        public int SiparisId { get; set; }
        public Musteri Musteri { get; set; }
        public int Tutar { get; set; }
        public System.DateTime Tarih { get; set; }
        public string Durum { get; set; }
        public bool AktifMi { get; set; }
        public enum durumlar
        {
            Hazırlanıyor, YolaÇıktı, TeslimEdildi
        }
    }
}
