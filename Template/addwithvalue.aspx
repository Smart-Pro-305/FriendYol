<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="addwithvalue.aspx.cs" Inherits="Template.addwithvalue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
       <div class="container">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GrdSiparis" runat="server" AutoGenerateColumns="False" DataKeyNames="SiparisID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GrdSiparis_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="SiparisID" HeaderText="SiparisID" InsertVisible="False" ReadOnly="True" SortExpression="SiparisID" />
                        <asp:BoundField DataField="MusteriID" HeaderText="MusteriID" SortExpression="MusteriID" />
                        <asp:BoundField DataField="SiparisTarihi" HeaderText="SiparisTarihi" SortExpression="SiparisTarihi" />
                        <asp:BoundField DataField="OdemeType" HeaderText="OdemeType" SortExpression="OdemeType" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Abuzer %>" SelectCommand="SELECT [SiparisID], [MusteriID], [SiparisTarihi], [OdemeType] FROM [Siparis]"></asp:SqlDataSource>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Veriler" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label1" runat="server" Text="Müşteri Seçiniz :"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="DDMusteri" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" Text="Sipariş Tarihi"></asp:Label>
                        &nbsp;</div>
                    <div class="col-md-1">
                        <asp:Button ID="BtnTarih" runat="server" Text="..." OnClick="BtnTarih_Click" />
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:Calendar ID="Calendar1" runat="server" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Tablolar" />
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label3" runat="server" Text="Ödeme Tipini Seçiniz :"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="DDOdeme" runat="server">
                            <asp:ListItem Value="1">Satış</asp:ListItem>
                            <asp:ListItem Value="11">Satış İadesi</asp:ListItem>
                            <asp:ListItem Value="2">Satın Alma</asp:ListItem>
                            <asp:ListItem Value="21">Satın Alma İadesi</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   
                </div>
                <div class="container">
                    <div class="col-3 align align-items-lg-start">
                        <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click" />
                    </div>
                    <div class="col-3 align-items-lg-start">
                          <asp:Button ID="BtnGuncelle" runat="server" Text="Güncelle" OnClick="BtnGuncelle_Click" />
                    </div>
                    <div class="col-3 align-content-lg-start">
                          <asp:Button ID="BtnSil" runat="server" Text="Sil" OnClick="BtnSil_Click" />
                    </div>
                    <div class="col-3 align-content-lg-start"> 
                          <asp:Button ID="BtnListe" runat="server" Text="Listele" />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
