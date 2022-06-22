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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // İller okunarak DD içine yüklenecek ..
                SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
                string SrIl = Sorgular.Sorgu(1,"");
                DataTable Dtil = usak.TabloOlustur(Kopru, SrIl);
                string TxtF = "ilAdi";
                string ValF = "ilID";
                usak.DropDownListDoldur(DDil, Dtil, TxtF, ValF);
            }
           
        }

        protected void DDil_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string SrMus = Sorgular.Sorgu(2,"");
            SrMus += " where il =" + DDil.SelectedValue.ToString();
            DataTable DtMus = usak.TabloOlustur(Kopru, SrMus);
            string TxtF = "MusteriAdi";
            string ValF = "MusteriID";
            usak.DropDownListDoldur(DDMusteri, DtMus, TxtF, ValF);
        }

        protected void DDMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            string Sart =  DDMusteri.SelectedValue.ToString();
            string SrSip = Sorgular.Sorgu(3, Sart ); 
            DataTable DtSip = usak.TabloOlustur(Kopru, SrSip);
            GrdSip.DataSource = DtSip;
            GrdSip.DataBind();
            
            
        }
    }
}