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
    public partial class FaturaAlisListesi : Form
    {
        public FaturaAlisListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tarih1, tarih2;
            tarih1 = Convert.ToDateTime(dateTimePicker1.Text);
            tarih2 = Convert.ToDateTime(dateTimePicker2.Text);
            faturaAlisUstTableAdapter.TarihlerArasi(cafeOtomasyonuDataSet.FaturaAlisUst, tarih1, tarih2);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRowView AktifKayit;
            AktifKayit = (DataRowView)faturaAlisUstBindingSource.Current;
            FaturaAlis.fustid = Convert.ToInt32(AktifKayit["fustid"].ToString());
            Close();
        }
    }
}
