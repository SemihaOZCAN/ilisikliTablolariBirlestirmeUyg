using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IliskiSorgulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantısı için SqlConnection nesnesi
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KIMUOA0\SQLEXPRESS;Initial Catalog=DbiliskiUygulama;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"
                SELECT  
                    HAREKETID, 
                    URUNAD, 
                    (AD + ' ' + SOYAD) AS 'MUSTERI', 
                    ADSOYAD, 
                    TblHareketler.FIYAT 
                FROM 
                    TblHareketler 
                INNER JOIN 
                    TblUrunler ON TblHareketler.URUN = TblUrunler.URUNID 
                INNER JOIN 
                    TblMusteriler ON TblHareketler.MUSTERI = TblMusteriler.MUSTERIID 
                INNER JOIN 
                    TblPersoneller ON TblHareketler.PERSONEL = TblPersoneller.PERSONELID;", baglanti);

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // dataGridView1 ismini kendi formundaki DataGridView kontrolü ile değiştir
            dataGridView1.DataSource = dataTable;

            baglanti.Close();
        }
    }
}
