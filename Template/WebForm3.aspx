<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Template.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border: 1px solid #95999C;
            background-color: #CCE5FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <table class="auto-style1 table table-responsive">
            <thead>
                <tr>
                <td> İl Seçiniz </td>
                <td>
                    <asp:DropDownList ID="DDil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDil_SelectedIndexChanged"></asp:DropDownList> </td>
                <td>Ürün ID Giriniz </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
            </tr>
            </thead>
            <tr>
                <td </td colspan="2">
                    &nbsp;İldeki Müşterile :&nbsp;&nbsp;
                    <asp:DropDownList ID="DDMusteri" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDMusteri_SelectedIndexChanged">
                    </asp:DropDownList>
                <td colspan="2">Sipariş Satırları</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GrdSip" runat="server">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Liste" Text="Listele" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="2"></td>
            </tr>
            </table>
        
    </div>
</asp:Content>
