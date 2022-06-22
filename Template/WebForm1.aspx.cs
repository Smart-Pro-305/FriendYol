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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
         //   ElleOku();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        private void ElleOku()
        {

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
                   Sorgu +=" inner join Ilceler on Musteriler.ilce = Ilceler.IlceId";
            Sorgu += " WHERE        (Musteriler.il = 34)";
            DataTable DtMusteri = usak.TabloOlustur(Kopru, Sorgu);
            GridView2.DataSource = DtMusteri;
            GridView2.DataBind();


        }

        protected void View2_Activate(object sender, EventArgs e)
        {
            ElleOku();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SecilenIl = DropDownList1.SelectedValue.ToString();
            ElleOkuParametrik(SecilenIl);
        }

        private void ElleOkuParametrik(string secilenIl)
        {
            // 1- Connection strin için :
            // Web config içine  ...... yazan yere bir isim eklenecek.
            //           < connectionStrings >
            //             < add name = "........." connectionString = "Data Source=11.11.13.8;Initial Catalog=Friendyol;Persist Security Info=True;User ID=sa305;Password=sa305"
            //                providerName = "System.Data.SqlClient" />
            //            </ connectionStrings >
            // 2- Baglanması için BAGLAN (Köpru) oluşturalım
            SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string Sorgu = "SELECT [MusteriID],[MusteriTC],[MusteriAdi],[MusteriSoyadi],[Adresi],[Telefon],[MusteriE_Posta],[VergiNo],Iller.ilAdi as il,Ilceler.IlceAdi as ilce";
            Sorgu += " FROM[dbo].[Musteriler]inner join Iller on Musteriler.il = Iller.ilID";
            Sorgu += " inner join Ilceler on Musteriler.ilce = Ilceler.IlceId";
            Sorgu += " WHERE        (Musteriler.il =" +secilenIl +")";
            SqlCommand Komut = new SqlCommand(Sorgu, Kopru);
            DataTable DtMusteri = new DataTable();
            try
            {
                Kopru.Open();
                Komut.ExecuteNonQuery();
                Kopru.Close();
            }
            catch (Exception)
            {

                throw;
            }

            SqlDataAdapter Adap = new SqlDataAdapter(Komut);
            Adap.Fill(DtMusteri);

            GridView2.DataSource = DtMusteri;
            GridView2.DataBind();
        }
    }
}