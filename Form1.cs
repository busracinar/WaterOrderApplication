using SuSatisOtomasyonu.DAL;
using SuSatisOtomasyonu.Entity;
using SuSatisOtomasyonu.Helpers;
using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SuSatisOtomasyonu.Model.SiparisModel;

namespace SuSatisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseYenile();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            m.Ad = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            m.Soyad = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            m.Tel = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            m.Adres = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            Form2 f = new Form2(m,0);
            f.Show();

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            var b = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (b == DialogResult.Yes)
            {
                var a = HelperMusteri.GetById(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                a.AktifMi = true;
                var c = HelperMusteri.Update(a);
                if (c.Item2)
                {
                    DatabaseYenile();
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kayıt silinemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kayıt silme iptal edildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DatabaseYenile()
        {
            dataGridView1.Rows.Clear();
            List<Musteri> musteriler = HelperMusteri.GetList();
            foreach (var item in musteriler)
            {
                if (!item.AktifMi)
                {
                    dataGridView1.Rows.Add(item.MusteriId, item.Ad, item.Soyad, item.Tel, item.Adres);
                }
            }
            dataGridView2.Rows.Clear();
            List<SiparisModel> siparisModels = HelperSiparis.GetList();
            foreach (var item in siparisModels)
            {
                if (!item.AktifMi)
                {
                    dataGridView2.Rows.Add(item.SiparisId, item.Musteri.Ad, item.Musteri.Soyad, item.Durum, item.Musteri.Adres, item.Tutar);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            List<Musteri> musteriler = new List<Musteri>();
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            musteriler = HelperMusteri.GetByNameAndSurname(ad, soyad);
            dataGridView1.Rows.Clear();
            foreach (var item in musteriler)
            {
                if (!item.AktifMi)
                {
                    dataGridView1.Rows.Add(item.MusteriId, item.Ad, item.Soyad, item.Tel, item.Adres);
                }
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(HelperMusteri.GetById(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value)), 1);
            f.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Siparis s = HelperSiparis.GetById(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            s.Durum = 1;
            var a = HelperSiparis.Update(s);
            if (a.Item2)
            {
                DatabaseYenile();
                MessageBox.Show("Durum değişimi başarıyla kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Durum değişimi kaydedilemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Siparis s = HelperSiparis.GetById(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            s.Durum = 2;
            var a = HelperSiparis.Update(s);
            if (a.Item2)
            {
                DatabaseYenile();
                MessageBox.Show("Durum değişimi başarıyla kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Durum değişimi kaydedilemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Siparis s = HelperSiparis.GetById(Convert.ToInt32(dataGridView2.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            s.AktifMi = true;
            var a = HelperSiparis.Update(s);
            if (a.Item2)
            {
                DatabaseYenile();
                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt silinemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Siparis> siparisler = HelperSiparis.GetJustSiparisList();
            foreach (var item in siparisler)
            {
                if (!item.AktifMi)
                {
                    item.AktifMi = true;
                    var a = HelperSiparis.Update(item);
                }
            }
            DatabaseYenile();
            MessageBox.Show("Tüm sipariş kayıtları silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<SiparisModel> siparisler = HelperSiparis.GetList();
            List<SiparisModel> siparisler2 = new List<SiparisModel>();
            foreach (var item in siparisler)
            {
                if ( item.Tarih.Year==DateTime.Now.Year && item.Tarih.Month == DateTime.Now.Month && item.Tarih.Day == DateTime.Now.Day)
                {
                    siparisler2.Add(item);
                }
            }
            dataGridView2.Rows.Clear();
            foreach (var item in siparisler2)
            {
                if (!item.AktifMi)
                {
                    dataGridView2.Rows.Add(item.SiparisId, item.Musteri.Ad, item.Musteri.Soyad, item.Durum, item.Musteri.Adres, item.Tutar);
                }
            }
        }

    }
}
