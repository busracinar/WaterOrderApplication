using SuSatisOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.Helpers
{
    class HelperMusteri
    {
        public static (Musteri, bool) Add(Musteri p)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                m.Musteri.Add(p);
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
        public static (Musteri, bool) Update(Musteri p)
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
        public static bool Delete(int MusteriId)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                var a = m.Musteri.Where(x => x.MusteriId == MusteriId).FirstOrDefault();
                m.Musteri.Remove(a);
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
        public static Musteri GetById(int MusteriId)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                return m.Musteri.Find(MusteriId);
            }
        }
        public static List<Musteri> GetList()
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                return m.Musteri.ToList();
            }
        }
        public static List<Musteri> GetByNameAndSurname(string a, string b)
        {
            using (SuSatisDbEntities m = new SuSatisDbEntities())
            {
                return m.Musteri.Where(x => x.Ad.Contains(a)&&x.Soyad.Contains(b)).ToList();
            }
        }
    }
}
