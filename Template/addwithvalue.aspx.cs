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
    public partial class addwithvalue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MusteriOku();
            }
           
        }

        private void MusteriOku()
        {
            string S = " Select MusteriID,(MusteriAdi + '  '  + MusteriSoyadi) as Adi from Musteriler";
            SqlConnection Cnn = usak.baglan();
            DataTable DtM = usak.TabloOlustur(Cnn, S);
            if (DtM.Rows.Count > 0)
            {
                DDMusteri.DataSource = DtM;
                DDMusteri.DataTextField = "Adi";
                DDMusteri.DataValueField = "MusteriID";
                DDMusteri.Items.Insert(0, new ListItem("Seçiniz ...", "0"));
                DDMusteri.DataBind();
            }


        }

        protected void BtnTarih_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            Label4.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            string KaydetAww = "Insert Into Siparis (MusteriID,SiparisTarihi,OdemeType) ";
            KaydetAww += " Values (@MusteriID,@SiparisTarihi,@OdemeType)";
            SqlConnection SqlCon = usak.baglan();
            SqlCommand Comm = new SqlCommand();
            Comm.Parameters.AddWithValue("@SiparisTarihi", Calendar1.SelectedDate.ToShortDateString());
            Comm.Parameters.AddWithValue("@MusteriID", DDMusteri.SelectedValue.ToString());
            Comm.Parameters.AddWithValue("@OdemeType",DDOdeme.SelectedValue.ToString());
            Comm.CommandText = KaydetAww;
            Comm.Connection = SqlCon;
            try
            {
                SqlCon.Open();
                Comm.ExecuteNonQuery();
                SqlCon.Close();
                Label4.Text = "Kayıt Tamamlandı";

            }
            catch (Exception Hata)
            {

                Label4.Text = Hata.ToString();
            }



        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //            UPDATE Siparis
            //SET SiparisTarihi = '2022-06-06', OdemeType = '1'
            //WHERE MusteriID = 40;
            //string update = "Update Siparis Set MüsteriID = '"++"'"
            string GuncelleAww = "UPDATE Siparis SET SiparisTarihi = @SiparisTarihi , OdemeType = @MusteriID WHERE MusteriID = @MusteriID";
            SqlConnection SqlCon = usak.baglan();
            SqlCommand Comm = new SqlCommand();
            Comm.Parameters.AddWithValue("@SiparisTarihi", Calendar1.SelectedDate.ToShortDateString());
            Comm.Parameters.AddWithValue("@MusteriID", DDMusteri.SelectedValue.ToString());
            Comm.Parameters.AddWithValue("@OdemeType", DDOdeme.SelectedValue.ToString());
            Comm.CommandText = GuncelleAww;
            Comm.Connection = SqlCon;


            try
            {
                SqlCon.Open();
                Comm.ExecuteNonQuery();
                SqlCon.Close();
                Label4.Text = "Kayıt Tamamlandı";
            }
            catch (Exception Hata)
            {
                Label4.Text = Hata.ToString();

            }

        }

        private void listele()
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void GrdSiparis_SelectedIndexChanged(object sender, EventArgs e)  
        {
            int sec = GrdSiparis.SelectedRow.RowIndex;

            string id =  GrdSiparis.Rows[sec].Cells[0].ToString();
            Label5.Text = id;


        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            //DELETE FROM table_name WHERE condition;
            string SilAww = "Delete FROM Siparis WHERE MusteriID =@MusteriID ";
            SqlConnection SqlCon = usak.baglan();
            SqlCommand Comm = new SqlCommand();
            Comm.Parameters.AddWithValue("@SiparisTarihi", Calendar1.SelectedDate.ToShortDateString());
            Comm.Parameters.AddWithValue("@MusteriID", DDMusteri.SelectedValue.ToString());
            Comm.Parameters.AddWithValue("@OdemeType", DDOdeme.SelectedValue.ToString());
            Comm.CommandText = SilAww;
            Comm.Connection = SqlCon;
            try
            {
                SqlCon.Open();
                Comm.ExecuteNonQuery();
                SqlCon.Close();
                Label4.Text = "Kayıt Silindi";
            }
            catch (Exception Hata)
            {
                Label4.Text = Hata.ToString();

            }
        }
    }
}