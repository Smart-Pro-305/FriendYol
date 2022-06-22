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
                Session["ID"]  = DDil.SelectedValue.ToString();
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
    }
}