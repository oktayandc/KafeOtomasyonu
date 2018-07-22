using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class FaturaSatisListesi : Form
    {
        public FaturaSatisListesi()
        {
            InitializeComponent();
        }
        public static int DoluMasaFatura;
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tarih1, tarih2;
            tarih1 = Convert.ToDateTime(dateTimePicker1.Text);
            tarih2 = Convert.ToDateTime(dateTimePicker2.Text);
            faturaSatisUstTableAdapter.TarihlerArasi(cafeOtomasyonuDataSet.FaturaSatisUst, tarih1, tarih2);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DoluMasaFatura = 0;
            DataRowView AktifKayit;
            AktifKayit = (DataRowView)faturaSatisUstBindingSource.Current;
            FaturaSatis.fustid = Convert.ToInt32(AktifKayit["fustid"].ToString());
            Close();
        }

        private void FaturaSatisListesi_Load(object sender, EventArgs e)
        {
            if (DoluMasaFatura == 1)
            {
                string Masano;
                Masano = AnaSayfa.MasaNumarasi.ToString();
                faturaSatisUstTableAdapter.DoluMasa(cafeOtomasyonuDataSet.FaturaSatisUst, Masano);              

            }
            
        }

        private void FaturaSatisListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoluMasaFatura = 0;
        }
    }
}
