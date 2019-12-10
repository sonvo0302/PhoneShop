<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="QuanLyThongTinKhachHang.aspx.cs" Inherits="PhoneShop.Staffs.QuanLyThongTinKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Mangement_Style/css_table/style.css" rel="stylesheet" />
   <link href="../UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
    <link href="../UserStyle/css/LoginStyle/font-awesome.css" rel="stylesheet" />
    <script src="../UserStyle/js/LoginJS/bootstrap.min.js"></script>
    <script src="../UserStyle/js/LoginJS/jquery-1.9.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="#">Thông tin khách hàng</a>
            </header>
            <asp:DataList ID="DataList1" CssClass="table table-striped table-advance table-hover" runat="server">
                <HeaderTemplate>

                    <th><i></i>Mã khách hàng</th>
                    <th><i></i>Họ tên </th>
                    <th><i></i>Ngày sinh </th>
                    <th><i></i>Giới tính</th>
                    <th><i></i>Điện thoại</th>
                    <th><i></i>Email </th>
                    <th><i></i>DiaChi</th>
                    <th><i></i>Sở thích</th>
                    <th><i></i>Ngũ hành</th>
                    <th><i></i>Thu nhập</th>
                    <th><i></i>Lớp tuổi</th>
                </HeaderTemplate>
                <ItemTemplate>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("User_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("HoTen") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("NgaySinh") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("TenGioiTinh") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("SoDienThoai") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("DiaChi") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("TenSoThich") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("TenNguHanh") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("LoaiThuNhap") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("Tuoi") %>'></asp:Label></td>
                </ItemTemplate>
            </asp:DataList>


        </section>

    </div>
</asp:Content>
