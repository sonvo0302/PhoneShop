<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="ThongTinKhachHang.aspx.cs" Inherits="PhoneShop.ThongTinKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .strong_th {
            font-weight: bold;
        }

        .center_td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section group">
        <div class="heading_top">
            <h4>&nbsp;<img src="images/list-img.png" />Thông tin khách hàng</h4>
        </div>
        <br />
        <br />
        <table id="table" runat="server" class="table table-hover">

            <tr class="strong_th">
                <th>Họ Tên</th>
                <th>Password</th>
                <th>Ngày sinh</th>
                <th>Giới tính</th>
            </tr>
            <tr>

                <td>
                    <asp:Label runat="server" ID="txt_hoten"></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="matkhau"></asp:Label></td>
                <td>
                    <asp:Label ID="ngaysinh" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="gioitinh"></asp:Label></td>
            </tr>
            <tr class="strong_th">

                <th>Điện Thoại</th>     
                 <th>Email</th>
                <td>Địa chỉ</td>
                <th>Sở thích</th>
                
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="txt_dienthoai"></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="email"></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="Diachi"></asp:Label></td>
                <td>
                    <asp:Label ID="sothich" runat="server"></asp:Label></td>             
            </tr>
            <tr class="strong_th">

                <th>Thu Nhập</th>
                <th>Ngũ hành</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="thunhap" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="nguhanh" runat="server"></asp:Label></td>
            </tr>

        </table>
        <asp:Button ID="Button1" runat="server" Text="Sửa thông tin" class="btn btn-primary btn-danger" OnClick="Button1_Click" />
    </div>
</asp:Content>
