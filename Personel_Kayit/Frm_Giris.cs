using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Frm_Giris : Form
    {
        public Frm_Giris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LQUHLSH\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Frm_Personel frm = new Frm_Personel();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yapıldı");
            }
            baglanti.Close();
        }
    }
}
