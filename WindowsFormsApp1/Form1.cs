using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable tablo=new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        void PersonelGetir()
        {
            baglanti=new SqlConnection("server=(localdb)\\MSSQLLocalDB;Initial Catalog=sirket;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM personel", baglanti);
            DataTable tablo=new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PersonelGetir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT Max(@maas) FROM personel";
            komut = new SqlCommand(sorgu, baglanti);
            //komut.Parameters.AddWithValue("@personel_no", txtNo.Text);
            //komut.Parameters.AddWithValue("@ad", txtAd.Text);
            //komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            //komut.Parameters.AddWithValue("@dogum_tarihi", dateDogumT.Value);
            komut.Parameters.AddWithValue("@maas", txtMaas.Text);
            //komut.Parameters.AddWithValue("@cinsiyet", txtCinsiyet.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateDogumT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMaas.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtCinsiyet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO personel(ad,soyad,dogum_tarihi,maas,cinsiyet) VALUES(@ad,@soyad,@dogum_tarihi,@maas,@cinsiyet)";
            komut = new SqlCommand(sorgu,baglanti);
            //komut.Parameters.AddWithValue("@personel_no", txtNo.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@dogum_tarihi", dateDogumT.Value);
            komut.Parameters.AddWithValue("@maas", txtMaas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", txtCinsiyet.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();

        }

        private void dateDogumT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM personel where personel_no=@personel_no";
            komut=new SqlCommand(sorgu,baglanti);
            komut.Parameters.AddWithValue("@personel_no", Convert.ToInt32(txtNo.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE personel set ad=@ad,soyad=@soyad,dogum_tarihi=@dogum_tarihi,maas=@maas,cinsiyet=@cinsiyet where personel_no=@personel_no";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@personel_no", Convert.ToInt32(txtNo.Text));
            komut.Parameters.AddWithValue("@ad",txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@dogum_tarihi", dateDogumT.Value);
            komut.Parameters.AddWithValue("@maas", txtMaas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", txtCinsiyet.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            PersonelGetir();
        }

        private void txtNameFol_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            komut = new SqlCommand("AdFiltrele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("Ad",txtNameFol.Text);    
            da = new SqlDataAdapter(komut);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            komut = new SqlCommand("den44", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(komut);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            komut = new SqlCommand("den45", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(komut);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            komut = new SqlCommand("den46", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(komut);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
