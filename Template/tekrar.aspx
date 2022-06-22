<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="tekrar.aspx.cs" Inherits="Template.tekrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--10 Field var. 2 tanesi Diğer tablolardan veri alacak ..--%>
    <div class ="container form-group">
        <div class="row">
            <asp:Label ID="Label1" CssClass="alert-danger" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-5 bg-info" >
               <%-- İller okunarak DD içinde gösterilecek ..--%>
                <asp:DropDownList ID="DDil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDil_SelectedIndexChanged" Width="100%"></asp:DropDownList>
            </div>
             <div class="col-md-5 bg-success">
               <%-- İlçeler okunarak DD içinde gösterilecek ..--%>
              <asp:DropDownList ID="DDilce" runat="server" AutoPostBack="True" Width="100%"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <asp:TextBox ID="TextBox1" placeholder="Musteri TC Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox2" placeholder="Musteri Adı Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox3" placeholder="Musteri Soyadı Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox4" placeholder="Musteri Adresi Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox5" placeholder="Musteri Telefon Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">

        </div>
        <div class="row">
             <asp:TextBox ID="TextBox6" placeholder="Musteri E-Posta Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox7" placeholder="Musteri Vergi No Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>
        <div class="row">
             <asp:TextBox ID="TextBox8" placeholder="Musteri TC Giriniz"  CssClass="form-text" runat="server"></asp:TextBox>
        </div>

    </div>
</asp:Content>
