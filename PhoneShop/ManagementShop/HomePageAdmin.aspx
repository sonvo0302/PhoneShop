<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminArea.Master" AutoEventWireup="true" CodeBehind="HomePageAdmin.aspx.cs" Inherits="PhoneShop.ManagementShop.HomePageAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <h1 class="mt-4">Chào mừng bạn đến với trang dùng của admin</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <%-- <a href="PhanQuyen.aspx" class="list-group-item list-group-item-action bg-light list-group-item-success">Phân quyền</a>
        <a href="QuanLyTaiKhoan.aspx" class="list-group-item list-group-item-action bg-light">Quản lý tài khoản</a>--%>
    <asp:LinkButton ID="phanquyen" CssClass="list-group-item list-group-item-action bg-light " runat="server" OnClick="phanquyen_Click">Phân quyền</asp:LinkButton>
          <asp:LinkButton ID="qltaikhoan" CssClass="list-group-item list-group-item-action bg-light" runat="server" OnClick="qltaikhoan_Click">Quản lý tài khoản</asp:LinkButton>
</asp:Content>
