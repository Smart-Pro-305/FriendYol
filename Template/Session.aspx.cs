using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Session : System.Web.UI.Page
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
            SqlCommand SqlKomand = new SqlCommand(SqlSorgu, SqlKonnect);
            // Hata olma olasılığına karşılık try komutu ile kontrol ediyoruz..

            try
            {
                SqlKonnect.Open(); // Veri Tabanını açarak
                SqlKomand.ExecuteNonQuery(); // Sorgu ile istediğimiz verileri allıyoruz
                SqlKonnect.Close(); // işimiz bittiğinde veri tabanını kapatıyoruz.. 
          
                // Sorgunun sonucunda oluşan SQL paketini C# objesi 
                // olan Data Table içine dolduruyoruz..
                SqlDataAdapter Adaptor = new SqlDataAdapter(SqlKomand);
                Adaptor.Fill(DtIl);
                if (DtIl.Rows.Count > 0)
                {
                     
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
            Label1.Text = DDil.SelectedValue.ToString() + " " + DDil.SelectedItem.Text.ToString();
            Session["il"] = DDil.SelectedValue.ToString();
            Session.Timeout = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Session2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Session2.aspx? Plaka= " + DDil.SelectedValue.ToString());

       

        }
    }
}