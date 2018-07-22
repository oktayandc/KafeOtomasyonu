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
    public partial class MusteriTanim : Form
    {
        public MusteriTanim()
        {
            InitializeComponent();
        }
        private void btnKontrol(Boolean deger)
        {
            button1.Enabled = deger;
            button2.Enabled = deger;
            button5.Enabled = deger;

            button3.Enabled = !deger;
            button4.Enabled = !deger;
            textBox1.Enabled = !deger;
            textBox2.Enabled = !deger;
            textBox3.Enabled = !deger;
            textBox5.Enabled = !deger;
            maskedTextBox1.Enabled = !deger;

        }

        private void MusteriTanim_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.MusteriTanim' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musteriTanimTableAdapter.Fill(this.cafeOtomasyonuDataSet.MusteriTanim);
            btnKontrol(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
            musteriTanimBindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            musteriTanimBindingSource.CancelEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            musteriTanimBindingSource.EndEdit();
            musteriTanimTableAdapter.Update(cafeOtomasyonuDataSet.MusteriTanim);
            cafeOtomasyonuDataSet.MusteriTanim.AcceptChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sil;
            sil = MessageBox.Show("Bu Kayıt Silinecek.Onaylıyormusunuz", "silme", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (sil == DialogResult.Yes)
            {
                musteriTanimBindingSource.RemoveCurrent();
                musteriTanimTableAdapter.Update(cafeOtomasyonuDataSet.MusteriTanim);
                cafeOtomasyonuDataSet.MusteriTanim.AcceptChanges();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            musteriTanimBindingSource.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            musteriTanimBindingSource.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            musteriTanimBindingSource.MovePrevious();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            musteriTanimBindingSource.MoveLast();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                musteriTanimTableAdapter.ad(cafeOtomasyonuDataSet.MusteriTanim, '%' + textBox6.Text + '%');
            else
                musteriTanimTableAdapter.soyad(cafeOtomasyonuDataSet.MusteriTanim, '%' + textBox6.Text + '%');
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataRowView AktifKayit;
            AktifKayit = (DataRowView)musteriTanimBindingSource.Current;
            MessageBox.Show(AktifKayit["ad"].ToString());
        }
    }
}
