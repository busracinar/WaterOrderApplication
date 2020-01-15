using SuSatisOtomasyonu.Entity;
using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuSatisOtomasyonu.Model.SiparisModel;

namespace SuSatisOtomasyonu.DAL
{
    class HelperSiparis
    {
        public static (Siparis, bool) Add(Siparis p)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                m.Siparis.Add(p);
                if (m.SaveChanges() > 0)
                {
                    return (p, true);
                }
                else
                {
                    return (p, false);
                }
            }
        }
        public static (Siparis, bool) Update(Siparis p)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                m.Entry(p).State = System.Data.Entity.EntityState.Modified;
                if (m.SaveChanges() > 0)
                {
                    return (p, true);
                }
                else
                {
                    return (p, false);
                }
            }
        }
        public static bool Delete(int SiparisId)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                var a = m.Siparis.Where(x => x.SiparisId == SiparisId).FirstOrDefault();
                m.Siparis.Remove(a);
                if (m.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static Siparis GetById(int SiparisId)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                return m.Siparis.Find(SiparisId);
            }
        }
        public static List<SiparisModel> GetList()
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                List<SiparisModel> siparisModeller = new List<SiparisModel>();
                List<Siparis> siparisler = m.Siparis.ToList();
                foreach (var item in siparisler)
                {
                    SiparisModel siparisModel = new SiparisModel();
                    siparisModel.SiparisId = item.SiparisId;
                    siparisModel.Tutar = item.Tutar;
                    siparisModel.Musteri = m.Musteri.Find(item.MusteriId);
                    siparisModel.Tarih = item.Tarih;
                    if (item.Durum==0)
                    {
                        siparisModel.Durum = "Hazırlanıyor";
                    }
                    else if (item.Durum == 1)
                    {
                        siparisModel.Durum = "Yola Çıktı";
                    }
                    else if (item.Durum == 2)
                    {
                        siparisModel.Durum = "Teslim Edildi";
                    }
                    siparisModel.AktifMi = item.AktifMi;
                    siparisModeller.Add(siparisModel);
                }
                return siparisModeller;
            }
        }
        public static List<Siparis> GetJustSiparisList()
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                return m.Siparis.ToList();
            }
        }
    }
}
