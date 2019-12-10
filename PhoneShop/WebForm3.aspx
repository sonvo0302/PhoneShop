<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="PhoneShop.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary btn-danger" OnClick="btnsave_Click" Text="Save" Style="width: 85px" />
                    <asp:Label ID="lblthongbao" runat="server"></asp:Label>
</asp:Content>
