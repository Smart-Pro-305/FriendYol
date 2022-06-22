using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template
{
    public class Sorgular
    {
        public static string Sorgu(int sorguno, string Kosul)
        {
            string query = "";
            switch (sorguno)
            {
                case 1: // İller tablosu listesi
                    query = "SELECT [ilID]      ,[ilAdi]        FROM[dbo].[Iller] ";
                    break;
                case 2: // Müşteriler listesi
                    query = " SELECT Musteriler.MusteriID, Musteriler.MusteriTC, Musteriler.MusteriAdi, Musteriler.MusteriSoyadi, Musteriler.Adresi, Musteriler.Telefon, Musteriler.MusteriE_Posta, Musteriler.VergiNo, Iller.ilAdi, Ilceler.IlceAdi";
                    query += " FROM Musteriler INNER JOIN Iller ON Musteriler.il = Iller.ilID INNER JOIN";
                    query += " Ilceler ON Musteriler.ilce = Ilceler.IlceId";
                    break;
                case 3:
                    query = "SELECT       Siparis.SiparisID, Siparis.MusteriID, Siparis.SiparisTarihi, Siparis.OdemeType, Musteriler.il";
                    query += " FROM Siparis INNER JOIN Musteriler ON Siparis.MusteriID = Musteriler.MusteriID";
 
                    if (Kosul != "")
                    {
                        query += " WHERE(Musteriler.il =" + Kosul + ")";
                    }
                    break;
                default:
                    break;
            }
            return query;

        }
    }
}