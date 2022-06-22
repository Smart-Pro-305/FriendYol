<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Template.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
         <h1>Kişisel Veriler</h1>
            <div class="container">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Adınız"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtAdi" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Soyadiniz"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtSoyadi" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/next.png" OnClick="ImageButton1_Click" />
                        </td>
                       
                    </tr>

                </table>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
           <h1> İş Bilgileri</h1>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <h1>Diğer </h1>
        </asp:View>
    </asp:MultiView>
</asp:Content>
