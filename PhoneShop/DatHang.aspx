<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="DatHang.aspx.cs" Inherits="PhoneShop.DatHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_top">
        <div class="heading_top">
            <h3>Đơn đặt hàng</h3>
        </div>
        <div class="see">
            <p><a href="#">Tất cả đơn hàng</a></p>
        </div>
        <div class="clear"></div>
    </div>
    <div class="section group">
        <div class="heading_top">
            <h4>&nbsp;<img src="images/list-img.png" />Sản Phẩm Đã Chọn Mua</h4>
        </div>
        <br />
        <asp:GridView ID="grdDatHang" CssClass="table" runat="server" AutoGenerateColumns="False"  Width="100%" AllowPaging="True" PageSize="5" >
            <Columns>
                 <asp:BoundField DataField="SanPham_ID" HeaderText="Mã Sản Phẩm"  />
                 <asp:BoundField DataField="TenSanPham" HeaderText="Tên Sản Phẩm"  />
                 <asp:TemplateField>
                     <ItemTemplate>
                          <asp:Image ID="lb1" style="float:left" Width="50%" runat="server" ImageUrl='<%# "/images/AnhDT/"+Eval("HinhAnh") %>'>
                      </asp:Image> 
                     </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="TenMau" HeaderText="Màu"/>
                 <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />   
                 <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" /> 
                 <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" />   
            </Columns>
        </asp:GridView>
        <div style="float:right">
            <asp:Label ID="Label1" runat="server" CssClass="label1" Text="Tổng tiền : "></asp:Label><asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label><asp:Label ID="Label3" style="font-size: 20px;
            font-style:italic;color: #ff006e;" runat="server" CssClass="label3" Text="VND"></asp:Label>
        </div>
        <div class="clear"></div>
        <div class="heading_top">
            <h4>&nbsp;<img src="images/list-img.png" />Thông Tin Đơn Hàng</h4>
                    <table class="table">
                        <tr>
                            <td>Tên Khách Hàng</td>
                            <td><asp:TextBox ID="txt_TenKhachHang" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Điện Thoại</td>
                            <td><asp:TextBox ID="txt_DienThoai" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Địa chỉ giao hàng</td>
                            <td><asp:TextBox ID="txt_DiaChi" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Thời Gian Đặt Hàng</td>
                            <td><asp:TextBox ID="txt_ThoiGianDH" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Thanh Toán</td>
                            <td><asp:DropDownList ID="dropdown_thanhtoan" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" ID="btn_DatHang" Text="Đặt Hàng" CssClass="btn btn-primary btn-danger" OnClick="btn_DatHang_Click"/></td>
                        </tr>
                    </table>
        </div>
    </div>
</asp:Content>
