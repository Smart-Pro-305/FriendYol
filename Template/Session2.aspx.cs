using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Session2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = Session["il"].ToString();
                // 1- Connection strin için :
                // Web config içine  ...... yazan yere bir isim eklenecek.
                //           < connectionStrings >
                //             < add name = "........." connectionString = "Data Source=11.11.13.8;Initial Catalog=Friendyol;Persist Security Info=True;User ID=sa305;Password=sa305"
                //                providerName = "System.Data.SqlClient" />
                //            </ connectionStrings >
                // 2- Baglanması için BAGLAN (Köpru) oluşturalım
                SqlConnection Kopru = usak.baglan();
                string Sorgu = "SELECT [MusteriID],[MusteriTC],[MusteriAdi],[MusteriSoyadi],[Adresi],[Telefon],[MusteriE_Posta],[VergiNo],Iller.ilAdi as il,Ilceler.IlceAdi as ilce";
                Sorgu += " FROM[dbo].[Musteriler]inner join Iller on Musteriler.il = Iller.ilID";
                Sorgu += " inner join Ilceler on Musteriler.ilce = Ilceler.IlceId";
                Sorgu += " WHERE        (Musteriler.il =" + Session["il"].ToString() + ")";
                DataTable DtMusteri = usak.TabloOlustur(Kopru, Sorgu);

                GridView1.DataSource = DtMusteri;
                GridView1.DataBind();
                
            }
            catch (Exception)
            {

                Mesaj("Oturum zaman aşımına uğradı");
                Response.Redirect("tekrar.aspx");
            }
            string Plaka = Request.QueryString["Plaka"].ToString();

           




        }

        private void Mesaj(string v)
        {
            Page pageCurr = HttpContext.Current.Handler as Page;
            if (pageCurr != null)
            {
                ScriptManager.RegisterStartupScript(pageCurr, pageCurr.GetType(), "aKey", "alert('" + v + "');", true);
            }
        }
        
    }
}