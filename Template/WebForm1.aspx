<%@ Page Title="" Language="C#" MasterPageFile="~/Tmp.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Template.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Bizim.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--MultiView--%>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="MusteriID" DataSourceID="TestConnection">
                <Columns>
                    <asp:BoundField DataField="MusteriID" HeaderText="MusteriID" InsertVisible="False" ReadOnly="True" SortExpression="MusteriID" />
                    <asp:BoundField DataField="MusteriTC" HeaderText="MusteriTC" SortExpression="MusteriTC" />
                    <asp:BoundField DataField="MusteriAdi" HeaderText="MusteriAdi" SortExpression="MusteriAdi" />
                    <asp:BoundField DataField="MusteriSoyadi" HeaderText="MusteriSoyadi" SortExpression="MusteriSoyadi" />
                    <asp:BoundField DataField="Adresi" HeaderText="Adresi" SortExpression="Adresi" />
                    <asp:BoundField DataField="Telefon" HeaderText="Telefon" SortExpression="Telefon" />
                    <asp:BoundField DataField="MusteriE_Posta" HeaderText="MusteriE_Posta" SortExpression="MusteriE_Posta" />
                    <asp:BoundField DataField="VergiNo" HeaderText="VergiNo" SortExpression="VergiNo" />
                    <asp:BoundField DataField="il" HeaderText="il" SortExpression="il" />
                    <asp:BoundField DataField="ilce" HeaderText="ilce" SortExpression="ilce" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="TestConnection" runat="server" ConnectionString="<%$ ConnectionStrings:Abuzer %>" SelectCommand="SELECT * FROM [Musteriler]"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Elle Sorgu" />
        </asp:View>
        <asp:View ID="View2" runat="server" OnActivate="View2_Activate">
           
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sihirbaz" />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="illerConnection" DataTextField="ilAdi" DataValueField="ilID" Height="22px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="335px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="illerConnection" runat="server" ConnectionString="<%$ ConnectionStrings:Abuzer %>" SelectCommand="SELECT * FROM [Iller]"></asp:SqlDataSource>
            <div class="container table-responsive">
            <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MusteriID" HeaderText="Müşteri no" />
                    <asp:BoundField DataField="MusteriTC" HeaderText="TC" />
                    <asp:BoundField DataField="MusteriAdi" HeaderText="Müşteri Adı / Ünvanı" />
                    <asp:BoundField DataField="il" HeaderText="İli" />
                    <asp:BoundField DataField="ilce" HeaderText="İlçe" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <EmptyDataTemplate>
                    Aranan özelliklerde kayıt bulunamadı
                </EmptyDataTemplate>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                </div>
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="MusteriID" DataSourceID="Sihirbaz">
                <Columns>
                    <asp:BoundField DataField="MusteriID" HeaderText="MusteriID" InsertVisible="False" ReadOnly="True" SortExpression="MusteriID" />
                    <asp:BoundField DataField="MusteriTC" HeaderText="MusteriTC" SortExpression="MusteriTC" />
                    <asp:BoundField DataField="MusteriAdi" HeaderText="MusteriAdi" SortExpression="MusteriAdi" />
                    <asp:BoundField DataField="MusteriSoyadi" HeaderText="MusteriSoyadi" SortExpression="MusteriSoyadi" />
                    <asp:BoundField DataField="Adresi" HeaderText="Adresi" SortExpression="Adresi" />
                    <asp:BoundField DataField="Telefon" HeaderText="Telefon" SortExpression="Telefon" />
                    <asp:BoundField DataField="MusteriE_Posta" HeaderText="MusteriE_Posta" SortExpression="MusteriE_Posta" />
                    <asp:BoundField DataField="VergiNo" HeaderText="VergiNo" SortExpression="VergiNo" />
                    <asp:BoundField DataField="il" HeaderText="il" SortExpression="il" />
                    <asp:BoundField DataField="ilce" HeaderText="ilce" SortExpression="ilce" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <asp:SqlDataSource ID="Sihirbaz" runat="server" ConnectionString="<%$ ConnectionStrings:Abuzer %>" SelectCommand="SELECT * FROM [Musteriler] WHERE ([il] = @il)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="il" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:View>
    </asp:MultiView>

</asp:Content>
