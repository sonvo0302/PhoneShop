<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="QuanLyThongTin.aspx.cs" Inherits="PhoneShop.QuanLyThongTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="section group">
        <div class="heading_top">
            <h4>&nbsp;<img src="images/list-img.png" />Chỉnh sửa</h4>
        </div>
        <br /><br />
                   <table id="table" runat="server" class ="table table-hover">
                        <tr>
                            <th>Họ Tên</th>
                            <td><asp:TextBox ID="txt_TenKhachHang" runat="server" Text='<%#Eval("HoTen") %>'></asp:TextBox></td>
                            <th>Mật khẩu</th>
                            <td><asp:TextBox ID="txt_matkhau" runat="server" Text='<%#Eval("Password") %>'></asp:TextBox></td>
                            <th>Ngày sinh</th>
                            <td><asp:TextBox ID="txt_ngaySinh" TextMode="DateTime" runat="server" Text='<%#Eval("NgaySinh") %>'></asp:TextBox></td>                            
                        </tr>
                        <tr>
                            <th>Giới tính</th>
                            <td><asp:DropDownList ID="drop_gioitinh" runat="server"></asp:DropDownList></td>
                            <th>Điện Thoại</th>
                            <td><asp:TextBox ID="txt_DienThoai" runat="server" Text='<%#Eval("SoDienThoai") %>'></asp:TextBox></td>
                           
                        </tr>
                        <tr>
                            <th>Email</th>
                            <td><asp:TextBox ID="txt_Email" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox></td>
                            <th>Địa chỉ</th>
                            <td><asp:TextBox ID="txt_DiaChi" runat="server" Text='<%#Eval("DiaChi") %>'></asp:TextBox></td> 
                        </tr>
                        <tr>
                            <th>Sở thích</th>
                        <td>
                            <asp:DropDownList ID="dropdown_Sothich" runat="server"></asp:DropDownList></td>
                        </tr>
                       <tr>
                            <th>Thu nhập</th>
                        <td>
                            <asp:DropDownList ID="drp_thunhap" runat="server"></asp:DropDownList></td>
                        </tr>
                </table>
                   
           
                
                <asp:Button ID="Button1" runat="server" Text="Lưu thông tin" class="btn btn-primary btn-danger" OnClick="Button1_Click"/>
                 <asp:Button ID="Button2" runat="server" Text="Trở lại" class="btn btn-primary btn-danger" OnClick="Button2_Click"/>
         </div>
</asp:Content>
