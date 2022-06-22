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

        public static void DropDownListDoldur(DropDownList dDil, DataTable dtil, string TextField, string ValueField)
        {
            dDil.DataSource = dtil;
            dDil.DataValueField = ValueField;
            dDil.DataTextField = TextField;
            dDil.DataBind();
            dDil.Items.Insert(0, new ListItem("Seçiniz ...", "0"));
        }

        public static void KaydetSP(string islev, string[] par, string[] deg)
        {
            string mesaj = "";
            string mes2 = "";
            //  string degeri;
            SqlConnection cnn = baglan();
            SqlCommand Komut = new SqlCommand();
            Komut.CommandType = CommandType.StoredProcedure;
            Komut.CommandText = islev;
            Komut.Connection = cnn;
            int parsay = par.Count();
            for (int i = 0; i < parsay; i++)
            {


                Komut.Parameters.AddWithValue(par[i].ToString(), deg[i].ToString());
            }
            try
            {
                cnn.Open();
                Komut.ExecuteNonQuery();
                cnn.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
                {
                    mes2 += "\n" + e.Message;
                };
                cnn.Close();
                mesaj = "1";

            }
            catch (Exception ex)
            {
                mesaj = ex.Message.ToString();
            }

            
        }

        //public static string Kaydet_Guncelle_Sil(string islev)
        //{
        //    string Mesaj = "";
        //    SqlConnection Kopru = baglan();
        //    SqlCommand Komut = new SqlCommand();
        //    Komut.Connection = Kopru;
        //    Komut.CommandType = System.Data.CommandType.Text;
        //    Komut.CommandText = islev;
        //    try
        //    {
        //        Kopru.Open();
        //        Komut.ExecuteNonQuery();
        //        Kopru.Close();
        //        Mesaj = "Kayıt Tamamlandı";
        //    }
        //    catch (Exception Hata)
        //    {
        //        Mesaj = Hata.ToString();
        //    }
        //    return Mesaj;
        //}
    }
}
