<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="Template.Session" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DDil" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="DDil_SelectedIndexChanged" Width="651px"></asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Session" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Request" />
</asp:Content>
