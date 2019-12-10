<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminManagement.Master" AutoEventWireup="true" CodeBehind="Vidu.aspx.cs" Inherits="PhoneShop.ManagementShop.Vidu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server"></asp:DataList>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%
        Response.Write(strMenu);
            %>
</asp:Content>
