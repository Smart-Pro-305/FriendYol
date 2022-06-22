<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="tekrar.aspx.cs" Inherits="Template.tekrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- İlçeler okunarak DD içinde gösterilecek ..--%>
    <div class ="container form-group">
        <div class="row">
            <asp:Label ID="Label1" CssClass="alert-danger" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-5 bg-info" >
                <%-- İlçeler okunarak DD içinde gösterilecek ..--%>
                <asp:DropDownList ID="DDil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDil_SelectedIndexChanged" Width="100%"></asp:DropDownList>
            </div>
             <div class="col-md-5 bg-success">
               <%-- İlçeler okunarak DD içinde gösterilecek ..--%>
              <asp:DropDownList ID="DDilce" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="DDilce_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <asp:TextBox ID="Txtmusteritc" placeholder="Musteri TC Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="Txtmusteriadi" placeholder="Musteri Adı Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="Txtmusterisoyadi" placeholder="Musteri Soyadı Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="Txtadresi" placeholder="Musteri Adresi Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="Txttelefon" placeholder="Musteri Telefon Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">

        </div>
        <div class="row">
             <asp:TextBox ID="Txteposta" placeholder="Musteri E-Posta Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="Txtvergino" placeholder="Musteri Vergi No Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
       

        <div class="row">
            <asp:Button ID="btnkaydet" runat="server" Text="Kaydet" OnClick="btnkaydet_Click" /> <asp:Button ID="btnguncelle" runat="server" Text="Güncelle" OnClick="btnguncelle_Click" /> <asp:Button ID="btnsil" runat="server" Text="Sil" OnClick="btnsil_Click" OnCommand="btnsil_Command" />
            <asp:Button ID="BtnSp" runat="server" OnClick="BtnSp_Click" Text="SP" />
            <asp:Button ID="BtUpdateSP" runat="server" OnClick="BtUpdateSP_Click" Text="Update SP" />
            <asp:Button ID="BtnSilSP" runat="server" OnClick="BtnSilSP_Click" Text="Sil SP" />
        </div>

        <div class="row m-5">
            <div class=" container">
            <asp:GridView ID="GWmust" runat="server" OnRowCommand="GWmust_RowCommand1" OnSelectedIndexChanged="GWmust_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Guncelle" Text="Seç" />
                </Columns>
            </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
