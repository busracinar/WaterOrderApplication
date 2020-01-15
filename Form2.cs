using SuSatisOtomasyonu.DAL;
using SuSatisOtomasyonu.Entity;
using SuSatisOtomasyonu.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuSatisOtomasyonu
{
    public partial class Form2 : Form
    {
        int secim=2;
        Musteri ma;

        public Form2()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Musteri m = HelperMusteri.GetById(ma.MusteriId);
            m.Ad = textBox1.Text;
            m.Soyad = textBox2.Text;
            m.Tel = textBox3.Text;
            m.Adres = textBox4.Text;
            var a = HelperMusteri.Update(m);
            if (a.Item2)
            {
                MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi gerçekleştirilemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Siparis s = new Siparis();
            s.Tutar = int.Parse(textBox5.Text);
            s.MusteriId = ma.MusteriId;
            s.Tarih = DateTime.Now;
            s.Durum = 0;
            s.AktifMi = false;
            var a = HelperSiparis.Add(s);
            if (a.Item2)
            {
                MessageBox.Show("Siparişiniz başarıyla kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Siparişiniz kaydedilemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.DatabaseYenile();
        }

        public Form2(Musteri m, int a)
        {
            this.ma = m;
            secim = a;
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.Ad = textBox1.Text;
            m.Soyad = textBox2.Text;
            m.Tel = textBox3.Text;
            m.Adres = textBox4.Text;
            m.AktifMi = false;
            var a = HelperMusteri.Add(m);
            if (a.Item2)
            {
                MessageBox.Show("Kayıt başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kayıt eklenemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            
            if (secim==0)
            {
                textBox1.Text = ma.Ad;
                textBox2.Text = ma.Soyad;
                textBox3.Text = ma.Tel;
                textBox4.Text = ma.Adres;
                label5.Visible = false;
                textBox5.Visible = false;
                pictureBox2.Visible = true;
                
            }
            else if(secim==1)
            {
                textBox1.Text = ma.Ad;
                textBox2.Text = ma.Soyad;
                textBox3.Text = ma.Tel;
                textBox4.Text = ma.Adres;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                label5.Visible = true;
                textBox5.Visible = true;
                label3.Visible = false;
                textBox3.Visible = false;
                pictureBox3.Visible = true;
            }
            else if(secim == 2)
            {
                label5.Visible = false;
                textBox5.Visible = false;
                pictureBox1.Visible = true;
            }
        }
    }
}
