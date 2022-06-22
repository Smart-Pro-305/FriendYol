using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Configuration;
using System.Data;

namespace Template
{
    public partial class tekrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                illeriGetir();
            }
        }

        private void illeriGetir()
        {
            // Sql Connection 
            SqlConnection SqlKonnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            //SqlConnection SqlCon = usak.baglan(); 
            // Eğer bir Class kullanılmış ise 27. satırdaki gibi de çağırabilirsiniz ..
            string SqlSorgu = "select ilID,ilAdi from Iller";
            // Yukarıdaki sorgudan gelecek veriler DataTable içine alınmalıdır.
            DataTable DtIl = new DataTable();
            // Eğer bir Class kullanılmış ise :
            //  DataTable DtIl = usak.TabloOlustur(SqlCon, SqlSorgu);
            // Şeklinde yazılabilinir ...
            // **************************** 
            // SqlCommand oluşturularak veriler çağırılır
            //SqlCommand SqlComm = new SqlCommand();
            //SqlComm.Connection = SqlCon;
            //SqlComm.CommandText = SqlSorgu;
            //SqlComm.CommandType = CommandType.Text;
            // 37,38,39,40,41. Satırların alternatif yazılım şekli 
            //43. satırdaki gibidir..
            SqlCommand SqlKomand =   new SqlCommand(SqlSorgu, SqlKonnect);
            // Hata olma olasılığına karşılık try komutu ile kontrol ediyoruz..

            try
            {
                SqlKonnect.Open(); // Veri Tabanını açarak
                SqlKomand.ExecuteNonQuery(); // Sorgu ile istediğimiz verileri allıyoruz
                SqlKonnect.Close(); // işimiz bittiğinde veri tabanını kapatıyoruz.. 
                Label1.Visible = false;
                // Sorgunun sonucunda oluşan SQL paketini C# objesi 
                // olan Data Table içine dolduruyoruz..
                SqlDataAdapter Adaptor = new SqlDataAdapter(SqlKomand);
                Adaptor.Fill(DtIl);
                if (DtIl.Rows.Count > 0)
                {
                    Label1.Visible = false;
                    // Eğer ilgili sorgudan sonuç veriler gelmiş ise.. 
                    DDil.DataSource = DtIl;
                    DDil.DataTextField = "ilAdi"; // Son KUllanıcı il adını görecektir
                    DDil.DataValueField = "ilID"; // Seçilen ilin ID değeri geri dönecektir..
                    DDil.DataBind();
                    DDil.Items.Insert(0, new ListItem("Seçiniz ...", "0")); 
                }
                else
                {
                    Label1.Text = "Veri Bulunamadı !";
                    Label1.Visible = true;
                }
            }
            catch (Exception Hata)
            {
                // Eğer bağlantıda harta olur ise ....
                // Oluşan Hatayı Label Aracılığı ile bildirelim..
                Label1.Text = Hata.ToString();
                Label1.Visible = true;
               
            }


        }

        protected void DDil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDil.SelectedIndex > 0)
            {
                string ilceSorgusu = "Select IlceId,IlceAdi from Ilceler";
                ilceSorgusu += " Where IlId = " + DDil.SelectedValue.ToString();
                DataTable Dtilce = usak.TabloOlustur(usak.baglan(), ilceSorgusu);
                if (Dtilce.Rows.Count > 0)
                {
                    Label1.Visible = false;
                    // Eğer ilgili sorgudan sonuç veriler gelmiş ise.. 
                    DDilce.DataSource = Dtilce;
                    DDilce.DataTextField = "IlceAdi"; // Son KUllanıcı il adını görecektir
                    DDilce.DataValueField = "IlceId"; // Seçilen ilin ID değeri geri dönecektir..
                    DDilce.DataBind();
                    DDilce.Items.Insert(0, new ListItem("Seçiniz ...", "0"));
                }
                else
                {
                    Label1.Text = "Kayıt Bulunamadı ..";
                    Label1.Visible = true;
                }
            }
        }

        protected void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlConnection SqlKaydetCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string kaydetsorgu = " Insert into Musteriler(MusteriTC,MusteriAdi,MusteriSoyadi,Adresi,Telefon,MusteriE_Posta,VergiNo,il,ilce) Values ('" + Txtmusteritc.Text + "','" + Txtmusteriadi.Text + "','" + Txtmusterisoyadi.Text + "','" + Txtadresi.Text + "','" + Txttelefon.Text + "','" + Txteposta.Text + "','" + Txtvergino.Text + "','" + DDil.SelectedValue.ToString() + "','" + DDilce.SelectedValue.ToString() + "')";
            SqlCommand Komut = new SqlCommand();
            Komut.Connection = SqlKaydetCon;
            Komut.CommandType = System.Data.CommandType.Text;
            Komut.CommandText = kaydetsorgu;
            try
            {
                SqlKaydetCon.Open();
                Komut.ExecuteNonQuery();
                SqlKaydetCon.Close();
                Label1.Text = "Kayıt Tamamlandı";
            }
            catch (Exception Hata)
            {
                Label1.Text = Hata.ToString();
            }
           


            //if (DDil.SelectedValue.ToString() > 0 && DDilce.SelectedValue.ToString() > 0)
            //{

            //}
            //else
            //{
            //    Lblmesaj.Visible = true;
            //    Lblmesaj.Text = "Eksik Bilgi Girdiniz..";

            //}


        }

        protected void DDilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection SqlGridCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string gridsorgu = " SELECT dbo.Musteriler.MusteriTC, dbo.Musteriler.MusteriAdi, dbo.Musteriler.MusteriSoyadi, dbo.Musteriler.Adresi, dbo.Musteriler.Telefon, dbo.Musteriler.MusteriE_Posta, dbo.Musteriler.VergiNo, dbo.Musteriler.il, dbo.Musteriler.ilce,dbo.Musteriler.MusteriID FROM dbo.Ilceler INNER JOIN dbo.Iller ON dbo.Ilceler.IlId = dbo.Iller.ilID INNER JOIN dbo.Musteriler ON dbo.Ilceler.IlceId = dbo.Musteriler.ilce AND dbo.Iller.ilID = dbo.Musteriler.il Where ilce = " + DDilce.SelectedValue.ToString();
            DataTable Dtilce = usak.TabloOlustur(usak.baglan(), gridsorgu);
            GWmust.DataSource = Dtilce;
            GWmust.DataBind();
           // İlçe değişince doldurduğum için il ve ilçe güncellemede hata alıyorum!!!


        }

        protected void GWmust_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        protected void GWmust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void GWmust_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            // Alltaki iki satırın nasıl çalışıtğını sor ????
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GWmust.Rows[index];
            Txtmusteritc.Text = GWmust.Rows[index].Cells[1].Text;
            Txtmusteriadi.Text = GWmust.Rows[index].Cells[2].Text;
            Txtmusterisoyadi.Text = GWmust.Rows[index].Cells[3].Text;
            Txtadresi.Text = GWmust.Rows[index].Cells[4].Text;
            Txttelefon.Text = GWmust.Rows[index].Cells[5].Text;
            Txteposta.Text = GWmust.Rows[index].Cells[6].Text;
            Txtvergino.Text = GWmust.Rows[index].Cells[7].Text;
            DDil.DataValueField = GWmust.Rows[index].Cells[8].Text;
            DDilce.DataValueField = GWmust.Rows[index].Cells[9].Text;
            Label1.Text = GWmust.Rows[index].Cells[10].Text;

        }

        protected void btnguncelle_Click(object sender, EventArgs e)
        {
            
            SqlConnection SqlGuncelleCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string GSorgu = " UPDATE Musteriler";
            GSorgu += " SET MusteriTC = '" + Txtmusteritc.Text + "',";
            GSorgu += " MusteriAdi = '" + Txtmusteriadi.Text + "',";
            GSorgu += "MusteriSoyadi ='" + Txtmusterisoyadi.Text + "',";
            GSorgu += "Adresi = '" + Txtadresi.Text + "',";
            GSorgu += " Telefon ='" + Txttelefon.Text + "',";
            GSorgu += "MusteriE_Posta ='" + Txteposta.Text + "',";
            GSorgu += "VergiNo ='" + Txtvergino.Text + "',";
            GSorgu += "il = '" + DDil.SelectedValue.ToString() + "',";
            GSorgu += "ilce ='" + DDilce.SelectedValue.ToString() + "'";
            GSorgu += " WHERE MusteriID =" + Label1.Text;

            SqlCommand Komut = new SqlCommand();
            Komut.Connection = SqlGuncelleCon;
            Komut.CommandType = System.Data.CommandType.Text;
            Komut.CommandText = GSorgu;
            try
            {
                SqlGuncelleCon.Open();
                Komut.ExecuteNonQuery();
                SqlGuncelleCon.Close();
                //Label1.Text = "Kayıt Tamamlandı";
            }
            catch (Exception Hata)
            {
                //Label1.Text = Hata.ToString();
            }
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            SqlConnection SqlGuncelleCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string Silsorgu = "Delete from Musteriler where MusteriID =" + Label1.Text;
            SqlCommand Komut = new SqlCommand();
            Komut.Connection = SqlGuncelleCon;
            Komut.CommandType = System.Data.CommandType.Text;
            Komut.CommandText = Silsorgu;
            try
            {
                SqlGuncelleCon.Open();
                Komut.ExecuteNonQuery();
                SqlGuncelleCon.Close();
                //Label1.Text = "Kayıt Tamamlandı";
            }
            catch (Exception Hata)
            {
                //Label1.Text = Hata.ToString();
            }

        }

        protected void btnsil_Command(object sender, CommandEventArgs e)
        {
         
        }

        protected void BtnSp_Click(object sender, EventArgs e)
        {
            string[] Par = {"@MusteriTC","@MusteriAdi","@MusteriSoyadi","@Adresi","@Telefon"
                           ,"@MusteriE_Posta","@VergiNo","@il","@ilce", };
            string[] Deg = { Txtmusteritc.Text, Txtmusteriadi.Text ,Txtmusterisoyadi.Text,Txtadresi.Text,
            Txttelefon.Text,Txteposta.Text,Txtvergino.Text,DDil.SelectedValue.ToString(),DDilce.SelectedValue.ToString(),};
            usak.KaydetSP("MusteriKaydet", Par, Deg);
        }

        protected void BtUpdateSP_Click(object sender, EventArgs e)
        {
            string[] Par = {"@MusteriTC","@MusteriAdi","@MusteriSoyadi","@Adresi","@Telefon"
                           ,"@MusteriE_Posta","@VergiNo","@il","@ilce","@MusteriID" };
            string[] Deg = { Txtmusteritc.Text, Txtmusteriadi.Text ,Txtmusterisoyadi.Text,Txtadresi.Text,
            Txttelefon.Text,Txteposta.Text,Txtvergino.Text,DDil.SelectedValue.ToString(),DDilce.SelectedValue.ToString(),Label1.Text};
            usak.KaydetSP("Turan_MusteriUpdate", Par, Deg);
        }

        protected void BtnSilSP_Click(object sender, EventArgs e)
        {
            string[] Par = { "@MusteriID" };
            string[] Deg = { Label1.Text };
            usak.KaydetSP("TE_SilMusteri", Par, Deg);
        }
    }
}