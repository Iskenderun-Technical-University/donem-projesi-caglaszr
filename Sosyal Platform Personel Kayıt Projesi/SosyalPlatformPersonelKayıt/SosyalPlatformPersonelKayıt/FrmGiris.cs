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

namespace SosyalPlatformPersonelKayıt
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CFOCL17\\SQLEXPRESS;Initial Catalog=PersonelKyt;Integrated Security=True");
        
        
        private void Btngirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullanciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read()) 
            {
                Form1 frm= new Form1 ();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şİfre");
            }
            baglanti.Close();
        }
    }
}
