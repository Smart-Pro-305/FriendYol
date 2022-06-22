using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Template
{
    public class usak
    {
        public static SqlConnection baglan()
        {
             SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Abuzer"].ConnectionString);
            return Con;
        }

        public static DataTable TabloOlustur(SqlConnection kopru, string sorgu)
        {

            SqlCommand Komut = new SqlCommand(sorgu, kopru);
            DataTable DtMusteri = new DataTable(); 
            try
            {
                kopru.Open();
                Komut.ExecuteNonQuery();
                kopru.Close();
            }
            catch (Exception)
            {

                throw;
            }

            SqlDataAdapter Adap = new SqlDataAdapter(Komut);
            Adap.Fill(DtMusteri);
            return DtMusteri;

        }

        public static void DropDownListDoldur(DropDownList dDil, DataTable dtil,string TextField,string ValueField)
        {
            dDil.DataSource = dtil;
            dDil.DataValueField = ValueField;
            dDil.DataTextField = TextField;
            dDil.DataBind();
            dDil.Items.Insert(0, new ListItem("Seçiniz ...", "0"));
        }
    }
}